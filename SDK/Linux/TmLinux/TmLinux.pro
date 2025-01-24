QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

CONFIG += c++11

# The following define makes your compiler emit warnings if you use
# any Qt feature that has been marked deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0


SOURCES += \
    main.cpp \
    TmLinux.cpp \
    Camera.cpp \
    CameraControl.cpp \
    SensorControl.cpp \
    FirmwareWorker.cpp

HEADERS += \
    TmLinux.h \
    Camera.h \
    CameraControl.h \
    SensorControl.h \
    FirmwareWorker.h

FORMS += \
    TmLinux.ui

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target

win32:CONFIG(release, debug|release): LIBS += -L$$PWD/../../../build/x64/release/ -llibTmCore
else:win32:CONFIG(debug, debug|release): LIBS += -L$$PWD/../../../build/x64/debug/ -llibTmCore


INCLUDEPATH += ./include

LIBS += -lTmCore.1.1.0
LIBS += -lTmRtspClient.1.1.0
LIBS += -lopencv_world
LIBS += -L./lib

win32 {
    message("Windows detected")
} else:unix {
    QMAKE_HOST_ARCH = $$system(uname -m)
    QMAKE_HOST_OS = $$system(lsb_release -is)
    QMAKE_HOST_VERSION = $$system(lsb_release -rs)

    message("OS: $$QMAKE_HOST_OS $$QMAKE_HOST_VERSION, Arch: $$QMAKE_HOST_ARCH")

    contains(QMAKE_HOST_OS, Ubuntu) {
        contains(QMAKE_HOST_VERSION, 24.04):contains(QMAKE_HOST_ARCH, x86_64) {
            LIBS += -L./lib/ubuntu_24.04/x86_64
            QMAKE_PRE_LINK += ln -sf libopencv_world.so.410 lib/ubuntu_24.04/x86_64/libopencv_world.so
        } else:contains(QMAKE_HOST_VERSION, 20.04|22.04):contains(QMAKE_HOST_ARCH, aarch64) {
            LIBS += -L./lib/ubuntu_20.04/aarch64
            QMAKE_PRE_LINK += ln -sf libopencv_world.so.407 lib/ubuntu_20.04/aarch64/libopencv_world.so
        } else:contains(QMAKE_HOST_VERSION, 20.04|22.04):contains(QMAKE_HOST_ARCH, x86_64) {
            LIBS += -L./lib/ubuntu_20.04/x86_64
            QMAKE_PRE_LINK += ln -sf libopencv_world.so.407 lib/ubuntu_20.04/x86_64/libopencv_world.so
        } else {
            message("Unsupported combination of OS and architecture")
        }
    } else {
        message("Unsupported OS: $$QMAKE_HOST_OS $$QMAKE_HOST_VERSION")
    }
}
