plugins {
    alias(libs.plugins.android.application)
}

android {
    namespace = "kr.co.thermoeye.android"
    compileSdk = 35

    defaultConfig {
        applicationId = "kr.co.thermoeye.android"
        minSdk = 24
        targetSdk = 35
        versionCode = 1
        versionName = "1.0"

        testInstrumentationRunner = "androidx.test.runner.AndroidJUnitRunner"
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(
                getDefaultProguardFile("proguard-android-optimize.txt"),
                "proguard-rules.pro"
            )
        }
    }
    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_11
        targetCompatibility = JavaVersion.VERSION_11
    }

    buildFeatures {
        viewBinding = true
    }
}

dependencies {

    implementation(libs.appcompat)
    implementation(libs.material)
    implementation(libs.activity)
    implementation(libs.constraintlayout)
    testImplementation(libs.junit)
    androidTestImplementation(libs.ext.junit)
    androidTestImplementation(libs.espresso.core)
    
    // AAR 파일을 버전 변수로 동적으로 참조 (gradle.properties에서 관리)
    val tmSdkVersion: String by project
    val aarFile = file("src/main/libs/TmSDK-${tmSdkVersion}.aar")
    if (aarFile.exists()) {
        debugImplementation(files(aarFile))
        releaseImplementation(files(aarFile))
    } else {
        // 파일이 없으면 자동으로 찾기 (fallback)
        val libsDir = file("src/main/libs")
        if (libsDir.exists()) {
            libsDir.listFiles { _, name -> name.startsWith("TmSDK-") && name.endsWith(".aar") }?.forEach { foundAar ->
                debugImplementation(files(foundAar))
                releaseImplementation(files(foundAar))
            }
        }
    }
}