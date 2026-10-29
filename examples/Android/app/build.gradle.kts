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
    
    // Reference the AAR through the version variable managed in gradle.properties
    val tmSdkVersion: String by project
    val aarFile = file("src/main/libs/TmSDK-${tmSdkVersion}.aar")
    if (aarFile.exists()) {
        debugImplementation(files(aarFile))
        releaseImplementation(files(aarFile))
    } else {
        // Fall back to searching for the file when it is missing
        val libsDir = file("src/main/libs")
        if (libsDir.exists()) {
            libsDir.listFiles { _, name -> name.startsWith("TmSDK-") && name.endsWith(".aar") }?.forEach { foundAar ->
                debugImplementation(files(foundAar))
                releaseImplementation(files(foundAar))
            }
        }
    }
}