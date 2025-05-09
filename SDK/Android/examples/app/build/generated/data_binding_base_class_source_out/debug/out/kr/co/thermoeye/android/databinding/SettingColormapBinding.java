// Generated by view binder compiler. Do not edit!
package kr.co.thermoeye.android.databinding;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.Spinner;
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

public final class SettingColormapBinding implements ViewBinding {
  @NonNull
  private final ConstraintLayout rootView;

  @NonNull
  public final LinearLayout settingColormap;

  @NonNull
  public final Spinner spinnerColorMap;

  @NonNull
  public final TextView textViewColorMap;

  private SettingColormapBinding(@NonNull ConstraintLayout rootView,
      @NonNull LinearLayout settingColormap, @NonNull Spinner spinnerColorMap,
      @NonNull TextView textViewColorMap) {
    this.rootView = rootView;
    this.settingColormap = settingColormap;
    this.spinnerColorMap = spinnerColorMap;
    this.textViewColorMap = textViewColorMap;
  }

  @Override
  @NonNull
  public ConstraintLayout getRoot() {
    return rootView;
  }

  @NonNull
  public static SettingColormapBinding inflate(@NonNull LayoutInflater inflater) {
    return inflate(inflater, null, false);
  }

  @NonNull
  public static SettingColormapBinding inflate(@NonNull LayoutInflater inflater,
      @Nullable ViewGroup parent, boolean attachToParent) {
    View root = inflater.inflate(R.layout.setting_colormap, parent, false);
    if (attachToParent) {
      parent.addView(root);
    }
    return bind(root);
  }

  @NonNull
  public static SettingColormapBinding bind(@NonNull View rootView) {
    // The body of this method is generated in a way you would not otherwise write.
    // This is done to optimize the compiled bytecode for size and performance.
    int id;
    missingId: {
      id = R.id.setting_colormap;
      LinearLayout settingColormap = ViewBindings.findChildViewById(rootView, id);
      if (settingColormap == null) {
        break missingId;
      }

      id = R.id.spinner_colorMap;
      Spinner spinnerColorMap = ViewBindings.findChildViewById(rootView, id);
      if (spinnerColorMap == null) {
        break missingId;
      }

      id = R.id.textView_colorMap;
      TextView textViewColorMap = ViewBindings.findChildViewById(rootView, id);
      if (textViewColorMap == null) {
        break missingId;
      }

      return new SettingColormapBinding((ConstraintLayout) rootView, settingColormap,
          spinnerColorMap, textViewColorMap);
    }
    String missingId = rootView.getResources().getResourceName(id);
    throw new NullPointerException("Missing required view with ID: ".concat(missingId));
  }
}
