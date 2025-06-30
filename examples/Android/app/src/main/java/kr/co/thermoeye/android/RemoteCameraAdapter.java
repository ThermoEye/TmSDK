package kr.co.thermoeye.android;

import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.core.content.ContextCompat;

import java.util.List;

/**
 * Adapter for displaying a list of remote cameras.
 */
public class RemoteCameraAdapter extends BaseAdapter {
    private final Context context;
    private final List<RemoteCameraListItem> itemList;
    private OnItemClickListener itemClickListener;
    private OnItemLongClickListener itemLongClickListener;
    private int selectedPosition = -1;

    /**
     * Constructor for initializing the adapter with context and a list of camera items.
     *
     * @param context The context in which the adapter is used.
     * @param itemList The list of remote camera items.
     */
    public RemoteCameraAdapter(Context context, List<RemoteCameraListItem> itemList) {
        this.context = context;
        this.itemList = itemList;
    }

    /**
     * Interface for handling item click events.
     */
    public interface OnItemClickListener{
        void onItemClick(View v, int pos);
    }

    /**
     * Interface for handling item long-click events.
     */
    public interface OnItemLongClickListener {
        void onItemLongClick(View v, int position);
    }

    /**
     * Sets the item click listener.
     *
     * @param listener The listener to handle item click events.
     */
    public void setOnItemClickListener(OnItemClickListener listener) {
        this.itemClickListener = listener;
    }

    /**
     * Sets the item long-click listener.
     *
     * @param listener The listener to handle item long-click events.
     */
    public void setOnItemLongClickListener(OnItemLongClickListener listener) {
        this.itemLongClickListener = listener;
    }

    @Override
    public int getCount() {
        return itemList.size();
    }

    @Override
    public RemoteCameraListItem getItem(int position) {
        return itemList.get(position);
    }

    public List<RemoteCameraListItem> getItemList() { return itemList; }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View view = convertView;
        if (view == null) {
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            view = inflater.inflate(R.layout.camera_list_item, parent, false);
        }

        // Find UI components within the item view.
        TextView textTitle = view.findViewById(R.id.textViewTitle);
        TextView textSubtitle = view.findViewById(R.id.textViewSubtitle);
        ImageView imageViewStatus = view.findViewById(R.id.imageViewStatus);

        // Get the camera item at the given position.
        RemoteCameraListItem item = itemList.get(position);
        // Set the camera's nickname and IP address.
        textTitle.setText(item.getNickName());
        textSubtitle.setText(item.getIp());

        // Set the connection status icon based on whether the camera is connected.
        if (item.isConnected()) {
            imageViewStatus.setImageResource(R.drawable.ic_connected);
        } else {
            imageViewStatus.setImageResource(R.drawable.ic_disconnected);
        }

        // Highlight the selected item with a green background.
        if (position == selectedPosition) {
            view.setBackgroundColor(ContextCompat.getColor(context, R.color.green));
        } else {
            view.setBackgroundColor(Color.TRANSPARENT);
        }

        // Set click listener for selecting an item.
        view.setOnClickListener(v -> {
            selectedPosition = position;
            notifyDataSetChanged();
            if (itemClickListener != null) {
                itemClickListener.onItemClick(v, position);
            }
        });

        // Set long-click listener for selecting an item.
        view.setOnLongClickListener(v -> {
            selectedPosition = position;
            notifyDataSetChanged();
            if (itemLongClickListener != null) {
                itemLongClickListener.onItemLongClick(v, position);
            }
            return false;
        });

        return view;
    }

    /**
     * Returns the currently selected camera item.
     *
     * @return The selected RemoteCameraListItem or null if no selection is made.
     */
    public RemoteCameraListItem getSelectedItem() {
        return selectedPosition != -1 ? itemList.get(selectedPosition) : null;
    }
}
