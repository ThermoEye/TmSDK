package kr.co.thermoeye.android;

import android.annotation.SuppressLint;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Typeface;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import java.util.List;
import java.util.Objects;

import kr.co.thermoeye.android.databinding.FragmentSingleViewBinding;
import kr.co.thermoeye.tmsdk.Line;
import kr.co.thermoeye.tmsdk.Point;
import kr.co.thermoeye.tmsdk.Rectangle;
import kr.co.thermoeye.tmsdk.RoiEllipse;
import kr.co.thermoeye.tmsdk.RoiLine;
import kr.co.thermoeye.tmsdk.RoiObject;
import kr.co.thermoeye.tmsdk.RoiRect;
import kr.co.thermoeye.tmsdk.RoiSpot;
import kr.co.thermoeye.tmsdk.RoiType;
import kr.co.thermoeye.tmsdk.TmCamera;
import kr.co.thermoeye.tmsdk.TmRoiManager;

/**
 * SingleViewFragment class is responsible for displaying the camera feed, allowing the user to draw and manage
 * regions of interest (ROI), and displaying temperature values for each ROI.
 * This fragment primarily updates the screen by handling touch events and managing ROI interactions.
 */
public class SingleViewFragment extends Fragment {
    private FragmentSingleViewBinding bindingSingleView;
    private CameraViewModel cameraViewModel;
    private RemoteCameraListItem currentCamera;
    private TmCamera tmCamera;
    private TmRoiManager roiManager;
    private boolean drawing = false;
    private int imageViewWidth = -1;
    private int imageViewHeight = -1;
    private int cameraWidth = -1;
    private int cameraHeight = -1;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        cameraViewModel = new ViewModelProvider(requireActivity()).get(CameraViewModel.class);
    }

    /**
     * Initializes the fragment's view. It observes the camera frame and handles touch events for drawing ROIs.
     *
     * @param inflater LayoutInflater to inflate the view.
     * @param container The parent view group.
     * @param savedInstanceState Previous saved instance state.
     * @return The root view of the fragment.
     */
    @SuppressLint("ClickableViewAccessibility")
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        bindingSingleView = FragmentSingleViewBinding.inflate(inflater, container, false);
        currentCamera = cameraViewModel.getRemoteCameraItem();
        roiManager = currentCamera.getTmRoiManager();
        tmCamera = currentCamera.getTmCamera();

        if (getArguments() != null) {
            int cameraIndex = getArguments().getInt("cameraIndex", -1);

            // Observe the camera frame and update the bitmap when a new frame is available.
            cameraViewModel.getBitmapFrame(cameraIndex).observe(getViewLifecycleOwner(), bitmap -> {
                if (bitmap != null) {
                    Bitmap mutableBitmap = bitmap.copy(Bitmap.Config.ARGB_8888, true);
                    cameraWidth = mutableBitmap.getWidth();
                    cameraHeight = mutableBitmap.getHeight();

                    // Draw the ROI objects on the bitmap.
                    DrawShapeObjects(mutableBitmap);
                    // Update the temperature labels.
                    UpdateDrawingLabel(mutableBitmap);


                    bindingSingleView.imageView.setImageBitmap(mutableBitmap);
                    bindingSingleView.imageView.invalidate();
                }
            });
        }

        // Handle touch events to manage the drawing of ROIs.
        bindingSingleView.imageView.setOnTouchListener(new View.OnTouchListener() {
//            private static final long DOUBLE_CLICK_TIME_DELTA = 300; // 300ms 이내면 더블클릭
//            private long lastClickTime = 0;

            @SuppressLint("ClickableViewAccessibility")
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                int width = bindingSingleView.imageView.getWidth();
                int height = bindingSingleView.imageView.getHeight();

                int scaledX = (int)(event.getX() * cameraWidth / width);
                int scaledY = (int)(event.getY() * cameraHeight / height);

                switch (event.getAction()) {
                    case MotionEvent.ACTION_DOWN:
                        roiManager.mouseDown((int) scaledX, (int) scaledY);
                        drawing = true;
                        break;
                    case MotionEvent.ACTION_MOVE:
                        roiManager.mouseMove((int) scaledX, (int) scaledY);
                        break;
                    case MotionEvent.ACTION_UP:
                        roiManager.mouseUp((int) scaledX, (int) scaledY);
                        drawing = false;
                        cameraViewModel.setRoiActionDone(true);

//                        long clickTime = System.currentTimeMillis();
//                        if (clickTime - lastClickTime < DOUBLE_CLICK_TIME_DELTA) {
//                            // Double Touch
//                            Log.d("TouchEvent:", "Double Click detected");
//                            onDoubleClick(v);
//                        }
//                        lastClickTime = clickTime;
//                        v.performClick();
                        break;
                }
                return true;
            }
        });

        bindingSingleView.imageView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
            }
        });

        return bindingSingleView.getRoot();
    }

    /**
     * Initializes the dimensions of the image view. This is called on the UI thread after the view is created.
     *
     * @param view The view.
     * @param savedInstanceState Previous saved instance state.
     */
    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        ImageView imageView = view.findViewById(R.id.imageView);

        imageView.post(new Runnable() {
            @Override
            public void run() {
                imageViewWidth = imageView.getWidth();
                imageViewHeight = imageView.getHeight();
            }
        });
    }

    public void onDoubleClick(View v) {
        cameraViewModel.setSelectedSingleCameraId(-1);
        getParentFragmentManager().popBackStack();
    }

    /**
     * Draws the ROI objects on the provided bitmap. Each ROI is drawn with a corresponding temperature marker.
     *
     * @param bitmap The camera frame bitmap to draw on.
     */
    public void DrawShapeObjects(Bitmap bitmap) {
        Canvas canvas = new Canvas(bitmap);
        Paint paint = new Paint(Paint.ANTI_ALIAS_FLAG);
        Paint textPaint = new Paint(Paint.ANTI_ALIAS_FLAG);
        textPaint.setTypeface(Typeface.create("Verdana", Typeface.NORMAL));
        textPaint.setTextSize(30);

        Paint crimsonPaint = new Paint(Paint.ANTI_ALIAS_FLAG);
        crimsonPaint.setColor(Color.rgb(220, 20, 60)); // #dc143c

        Paint bluePaint = new Paint(Paint.ANTI_ALIAS_FLAG);
        bluePaint.setColor(Color.rgb(100, 149, 237)); // #6495ed

        Paint greenPaint = new Paint(Paint.ANTI_ALIAS_FLAG);
        greenPaint.setColor(Color.GREEN);

        List<RoiObject> roiObjects = roiManager.getItems();
        String avgTemp;

        assert roiObjects != null;
        for (RoiObject roiObj : roiObjects) {
            switch (Objects.requireNonNull(roiObj.getType())) {
                case SPOT:
                    RoiSpot spot = new RoiSpot(roiObj);
                    Point point = spot.getSpot();
                    paint.setColor(Color.CYAN);
                    paint.setStyle(Paint.Style.STROKE);
                    canvas.drawCircle(point.getX(), point.getY(), 2, paint);

                    String text = "ROI" + spot.getIndex();
                    textPaint.setColor(Color.CYAN);
                    canvas.drawText(text, point.getX() - textPaint.measureText(text) / 2, point.getY() + 40, textPaint);

                    drawTempMarker(canvas, greenPaint, textPaint,
                            point.getX(),
                            point.getY() + 10,
                            Objects.requireNonNull(spot.getAvgLocItem()).getValue());
                    break;

                case LINE:
                    RoiLine shapeLine = new RoiLine(roiObj);
                    Line line = shapeLine.getLine();
                    paint.setColor(Color.YELLOW);
                    canvas.drawLine(line.getStartX(), line.getStartY(), line.getEndX(), line.getEndY(), paint);

                    String lineText = "ROI" + shapeLine.getIndex();
                    textPaint.setColor(Color.CYAN);
                    canvas.drawText(lineText, line.getStartX(), line.getStartY() - 4, textPaint);

                    drawTempMarker(canvas, crimsonPaint, textPaint,
                            Objects.requireNonNull(shapeLine.getMaxLocItem()).getLocation().getX(),
                            shapeLine.getMaxLocItem().getLocation().getY(),
                            shapeLine.getMaxLocItem().getValue());
                    drawTempMarker(canvas, bluePaint, textPaint,
                            Objects.requireNonNull(shapeLine.getMinLocItem()).getLocation().getX(),
                            shapeLine.getMinLocItem().getLocation().getY(),
                            shapeLine.getMinLocItem().getValue());

                    textPaint.setColor(Color.GREEN);
                    avgTemp = getTempStringUnit(Objects.requireNonNull(shapeLine.getAvgLocItem()).getValue());
                    canvas.drawText(avgTemp, (float) (line.getStartX() + line.getEndX()) / 2, (float) (line.getStartY() + line.getEndY()) / 2, textPaint);
                    break;

                case RECT:
                    RoiRect shapeRect = new RoiRect(roiObj);
                    Rectangle rect = shapeRect.getRect();
                    paint.setColor(Color.YELLOW);
                    paint.setStyle(Paint.Style.STROKE);
                    canvas.drawRect(rect.getX(), rect.getY(), rect.getX() + rect.getWidth(), rect.getY() + rect.getHeight(), paint);

                    String rectText = "ROI" + shapeRect.getIndex();
                    textPaint.setColor(Color.CYAN);
                    canvas.drawText(rectText, rect.getX(), rect.getY() - 4, textPaint);

                    drawTempMarker(canvas, crimsonPaint, textPaint,
                            Objects.requireNonNull(shapeRect.getMaxLocItem()).getLocation().getX(),
                            shapeRect.getMaxLocItem().getLocation().getY(),
                            shapeRect.getMaxLocItem().getValue());
                    drawTempMarker(canvas, bluePaint, textPaint,
                            Objects.requireNonNull(shapeRect.getMinLocItem()).getLocation().getX(),
                            shapeRect.getMinLocItem().getLocation().getY(),
                            shapeRect.getMinLocItem().getValue());

                    textPaint.setColor(Color.GREEN);
                    avgTemp = getTempStringUnit(Objects.requireNonNull(shapeRect.getAvgLocItem()).getValue());
                    canvas.drawText(avgTemp,
                            rect.getX() + (float) rect.getWidth() / 2,
                            rect.getY() - 10,
                            textPaint);
                    break;

                case ELLIPSE:
                    RoiEllipse shapeEllipse = new RoiEllipse(roiObj);
                    Rectangle ellipse = shapeEllipse.getEllipse();
                    paint.setColor(Color.YELLOW);
                    paint.setStyle(Paint.Style.STROKE);
                    canvas.drawOval(ellipse.getX(), ellipse.getY(), ellipse.getX() + ellipse.getWidth(), ellipse.getY() + ellipse.getHeight(), paint);

                    String ellipseText = "ROI" + shapeEllipse.getIndex();
                    textPaint.setColor(Color.CYAN);
                    canvas.drawText(ellipseText, ellipse.getX(), ellipse.getY() - 4, textPaint);

                    drawTempMarker(canvas, crimsonPaint, textPaint,
                            Objects.requireNonNull(shapeEllipse.getMaxLocItem()).getLocation().getX(),
                            shapeEllipse.getMaxLocItem().getLocation().getY(),
                            shapeEllipse.getMaxLocItem().getValue());
                    drawTempMarker(canvas, bluePaint, textPaint,
                            Objects.requireNonNull(shapeEllipse.getMinLocItem()).getLocation().getX(),
                            shapeEllipse.getMinLocItem().getLocation().getY(),
                            shapeEllipse.getMinLocItem().getValue());

                    textPaint.setColor(Color.GREEN);
                    avgTemp = getTempStringUnit(Objects.requireNonNull(shapeEllipse.getAvgLocItem()).getValue());
                    canvas.drawText(avgTemp,
                            ellipse.getX() + (float) ellipse.getWidth() / 2,
                            ellipse.getY() - 10,
                            textPaint);

                    break;
            }
        }
    }

    /**
     * Draws a temperature marker at a specified position on the canvas.
     * A circle is drawn at the provided coordinates, and the temperature value is displayed next to it.
     *
     * @param canvas The canvas where the marker will be drawn.
     * @param markerPaint The paint used to draw the marker (circle).
     * @param textPaint The paint used to draw the text (temperature).
     * @param x The x-coordinate for the marker.
     * @param y The y-coordinate for the marker.
     * @param tempValue The temperature value to be displayed next to the marker.
     */
    private void drawTempMarker(Canvas canvas, Paint markerPaint, Paint textPaint, int x, int y, double tempValue) {
        canvas.drawCircle(x, y, 5, markerPaint);
        String tempText = getTempStringUnit(tempValue);
        textPaint.setColor(markerPaint.getColor());
        canvas.drawText(tempText, x - textPaint.measureText(tempText) / 2, y - 10, textPaint);
    }

    /**
     * Converts a raw temperature value into a string representation, including the correct unit.
     * The temperature value is formatted according to the camera's temperature unit setting (RAW, CELSIUS, FAHRENHEIT, or KELVIN).
     *
     * @param raw The raw temperature value to be converted.
     * @return A string representing the temperature with the appropriate unit.
     */
    @SuppressLint("DefaultLocale")
    private String getTempStringUnit(double raw) {
        StringBuilder strTemp = new StringBuilder();

        switch (Objects.requireNonNull(tmCamera.getTempUnit())) {
            case RAW:
                strTemp.append(String.format("%.0f %s", raw, tmCamera.getTempUnitSymbol()));
                break;
            case CELSIUS:
            case FAHRENHEIT:
            case KELVIN:
                strTemp.append(String.format("%.1f %s", tmCamera.getTemperature(raw), tmCamera.getTempUnitSymbol()));
                break;
            default:
                throw new IllegalStateException("Unknown temperature unit");
        }

        return strTemp.toString();
    }

    /**
     * Updates the drawing of temperature markers and ROI shapes on the given bitmap.
     * This method is called on the main thread to ensure UI updates happen properly.
     * The temperature markers and ROI shapes (Spot, Line, Rect, Ellipse) are drawn based on the current state.
     *
     * @param frameBitmap The bitmap to update with the temperature markers and ROI shapes.
     */
    public void UpdateDrawingLabel(Bitmap frameBitmap) {
        if (Thread.currentThread() != Looper.getMainLooper().getThread()) {
            new Handler(Looper.getMainLooper()).post(() -> UpdateDrawingLabel(frameBitmap));
            return;
        }

        // Get the current ROI manager and initialize the canvas for drawing
        TmRoiManager roiManager = currentCamera.getTmRoiManager();

        Canvas canvas = new Canvas(frameBitmap);
        Paint paint = new Paint();
        paint.setAntiAlias(true);
        // Get the currently selected ROI object
        RoiObject roiObj = roiManager.selectedItem();
        if (drawing && roiObj != null) {
            paint.setColor(Color.YELLOW);
            paint.setStyle(Paint.Style.STROKE);
            RoiType roiType = roiObj.getType();
            switch (Objects.requireNonNull(roiType)) {
                case HAND:
                    break;
                case SPOT:
                    RoiSpot shapeSpot = new RoiSpot(roiObj);
                    Point pt = shapeSpot.getSpot();
                    canvas.drawCircle(pt.getX() - 1, pt.getY() - 1, 1, paint);
                    break;
                case LINE:
                    RoiLine shapeLine = new RoiLine(roiObj);
                    Line line = shapeLine.getLine();
                    canvas.drawLine(line.getStartX(), line.getStartY(),
                            line.getEndX(), line.getEndY(), paint);
                    break;
                case RECT:
                    RoiRect rectShape = new RoiRect(roiObj);
                    Rectangle rect = rectShape.getRect();
                    canvas.drawRect(rect.getX(), rect.getY(),
                            rect.getX() + rect.getWidth(),
                            rect.getY() + rect.getHeight(), paint);
                    break;
                case ELLIPSE:
                    RoiEllipse ellipseShape = new RoiEllipse(roiObj);
                    Rectangle ellipse = ellipseShape.getEllipse();
                    canvas.drawOval(ellipse.getX(), ellipse.getY(),
                            ellipse.getX() + ellipse.getWidth(),
                            ellipse.getY() + ellipse.getHeight(), paint);
                    break;
            }
        }
    }

    public int getImageViewWidth() {
        return imageViewWidth;
    }

    public int getImageViewHeight() {
        return imageViewHeight;
    }
}
