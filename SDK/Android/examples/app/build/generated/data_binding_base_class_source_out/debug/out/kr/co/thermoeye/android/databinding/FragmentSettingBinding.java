// Generated by view binder compiler. Do not edit!
package kr.co.thermoeye.android.databinding;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ExpandableListView;
import android.widget.LinearLayout;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.viewbinding.ViewBinding;
import androidx.viewbinding.ViewBindings;
import java.lang.NullPointerException;
import java.lang.Override;
import java.lang.String;
import kr.co.thermoeye.android.R;

public final class FragmentSettingBinding implements ViewBinding {
  @NonNull
  private final ConstraintLayout rootView;

  @NonNull
  public final Button buttonBack;

  @NonNull
  public final ExpandableListView expandableListViewSetting;

  @NonNull
  public final TextView expandableListViewTitle;

  @NonNull
  public final LinearLayout fragmentSetting;

  private FragmentSettingBinding(@NonNull ConstraintLayout rootView, @NonNull Button buttonBack,
      @NonNull ExpandableListView expandableListViewSetting,
      @NonNull TextView expandableListViewTitle, @NonNull LinearLayout fragmentSetting) {
    this.rootView = rootView;
    this.buttonBack = buttonBack;
    this.expandableListViewSetting = expandableListViewSetting;
    this.expandableListViewTitle = expandableListViewTitle;
    this.fragmentSetting = fragmentSetting;
  }

  @Override
  @NonNull
  public ConstraintLayout getRoot() {
    return rootView;
  }

  @NonNull
  public static FragmentSettingBinding inflate(@NonNull LayoutInflater inflater) {
    return inflate(inflater, null, false);
  }

  @NonNull
  public static FragmentSettingBinding inflate(@NonNull LayoutInflater inflater,
      @Nullable ViewGroup parent, boolean attachToParent) {
    View root = inflater.inflate(R.layout.fragment_setting, parent, false);
    if (attachToParent) {
      parent.addView(root);
    }
    return bind(root);
  }

  @NonNull
  public static FragmentSettingBinding bind(@NonNull View rootView) {
    // The body of this method is generated in a way you would not otherwise write.
    // This is done to optimize the compiled bytecode for size and performance.
    int id;
    missingId: {
      id = R.id.button_back;
      Button buttonBack = ViewBindings.findChildViewById(rootView, id);
      if (buttonBack == null) {
        break missingId;
      }

      id = R.id.expandableListView_setting;
      ExpandableListView expandableListViewSetting = ViewBindings.findChildViewById(rootView, id);
      if (expandableListViewSetting == null) {
        break missingId;
      }

      id = R.id.expandableListView_title;
      TextView expandableListViewTitle = ViewBindings.findChildViewById(rootView, id);
      if (expandableListViewTitle == null) {
        break missingId;
      }

      id = R.id.fragment_setting;
      LinearLayout fragmentSetting = ViewBindings.findChildViewById(rootView, id);
      if (fragmentSetting == null) {
        break missingId;
      }

      return new FragmentSettingBinding((ConstraintLayout) rootView, buttonBack,
          expandableListViewSetting, expandableListViewTitle, fragmentSetting);
    }
    String missingId = rootView.getResources().getResourceName(id);
    throw new NullPointerException("Missing required view with ID: ".concat(missingId));
  }
}
