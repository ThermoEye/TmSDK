package kr.co.thermoeye.android;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);

        if (savedInstanceState == null) {
            CameraListFragment cameraListFragment = new CameraListFragment();
            MultiViewFragment multiViewFragment = new MultiViewFragment();

            FragmentTransaction transaction = getSupportFragmentManager().beginTransaction();
            transaction.replace(R.id.fragment_container_ctrl, cameraListFragment);
            transaction.replace(R.id.fragment_container_view, multiViewFragment, "MULTI_VIEW_FRAGMENT");
            transaction.commit();
            getSupportFragmentManager().beginTransaction()
                    .replace(R.id.fragment_container_view, new MultiViewFragment(), MultiViewFragment.class.getSimpleName())
                    .commit();
        }
    }

    public void replaceLeftFragment(Fragment newFragment) {
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.fragment_container_ctrl, newFragment)
                .addToBackStack(null)
                .commit();
    }

    private void enableEdgeToEdge() {
        // If you want to enable edge-to-edge behavior manually
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.R) {
            getWindow().setDecorFitsSystemWindows(false);
        }
    }
}