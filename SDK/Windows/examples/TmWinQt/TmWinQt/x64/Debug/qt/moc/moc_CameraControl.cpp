/****************************************************************************
** Meta object code from reading C++ file 'CameraControl.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.14.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include <memory>
#include "../../../../../CameraControl.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'CameraControl.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.14.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_CameraControl_t {
    QByteArrayData data[15];
    char stringdata0[411];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_CameraControl_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_CameraControl_t qt_meta_stringdata_CameraControl = {
    {
QT_MOC_LITERAL(0, 0, 13), // "CameraControl"
QT_MOC_LITERAL(1, 14, 40), // "pushButton_GetProductInformat..."
QT_MOC_LITERAL(2, 55, 0), // ""
QT_MOC_LITERAL(3, 56, 39), // "pushButton_GetSensorInformati..."
QT_MOC_LITERAL(4, 96, 43), // "pushButton_SoftwareUpdateFile..."
QT_MOC_LITERAL(5, 140, 38), // "pushButton_StartSoftwareUpdat..."
QT_MOC_LITERAL(6, 179, 42), // "pushButton_GetNetworkConfigur..."
QT_MOC_LITERAL(7, 222, 42), // "pushButton_SetNetworkConfigur..."
QT_MOC_LITERAL(8, 265, 49), // "pushButton_SetDefaultNetworkC..."
QT_MOC_LITERAL(9, 315, 31), // "pushButton_SystemReboot_Clicked"
QT_MOC_LITERAL(10, 347, 21), // "UpdateProgressChanged"
QT_MOC_LITERAL(11, 369, 8), // "progress"
QT_MOC_LITERAL(12, 378, 24), // "UpdateRunWorkerCompleted"
QT_MOC_LITERAL(13, 403, 3), // "ret"
QT_MOC_LITERAL(14, 407, 3) // "msg"

    },
    "CameraControl\0pushButton_GetProductInformation_Clicked\0"
    "\0pushButton_GetSensorInformation_Clicked\0"
    "pushButton_SoftwareUpdateFileBrowse_Clicked\0"
    "pushButton_StartSoftwareUpdate_Clicked\0"
    "pushButton_GetNetworkConfiguration_Clicked\0"
    "pushButton_SetNetworkConfiguration_Clicked\0"
    "pushButton_SetDefaultNetworkConfiguration_Clicked\0"
    "pushButton_SystemReboot_Clicked\0"
    "UpdateProgressChanged\0progress\0"
    "UpdateRunWorkerCompleted\0ret\0msg"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_CameraControl[] = {

 // content:
       8,       // revision
       0,       // classname
       0,    0, // classinfo
      10,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    0,   64,    2, 0x0a /* Public */,
       3,    0,   65,    2, 0x0a /* Public */,
       4,    0,   66,    2, 0x0a /* Public */,
       5,    0,   67,    2, 0x0a /* Public */,
       6,    0,   68,    2, 0x0a /* Public */,
       7,    0,   69,    2, 0x0a /* Public */,
       8,    0,   70,    2, 0x0a /* Public */,
       9,    0,   71,    2, 0x0a /* Public */,
      10,    1,   72,    2, 0x0a /* Public */,
      12,    2,   75,    2, 0x0a /* Public */,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void, QMetaType::Int,   11,
    QMetaType::Void, QMetaType::Bool, QMetaType::QString,   13,   14,

       0        // eod
};

void CameraControl::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        auto *_t = static_cast<CameraControl *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->pushButton_GetProductInformation_Clicked(); break;
        case 1: _t->pushButton_GetSensorInformation_Clicked(); break;
        case 2: _t->pushButton_SoftwareUpdateFileBrowse_Clicked(); break;
        case 3: _t->pushButton_StartSoftwareUpdate_Clicked(); break;
        case 4: _t->pushButton_GetNetworkConfiguration_Clicked(); break;
        case 5: _t->pushButton_SetNetworkConfiguration_Clicked(); break;
        case 6: _t->pushButton_SetDefaultNetworkConfiguration_Clicked(); break;
        case 7: _t->pushButton_SystemReboot_Clicked(); break;
        case 8: _t->UpdateProgressChanged((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 9: _t->UpdateRunWorkerCompleted((*reinterpret_cast< bool(*)>(_a[1])),(*reinterpret_cast< QString(*)>(_a[2]))); break;
        default: ;
        }
    }
}

QT_INIT_METAOBJECT const QMetaObject CameraControl::staticMetaObject = { {
    QMetaObject::SuperData::link<QObject::staticMetaObject>(),
    qt_meta_stringdata_CameraControl.data,
    qt_meta_data_CameraControl,
    qt_static_metacall,
    nullptr,
    nullptr
} };


const QMetaObject *CameraControl::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *CameraControl::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_CameraControl.stringdata0))
        return static_cast<void*>(this);
    return QObject::qt_metacast(_clname);
}

int CameraControl::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QObject::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 10)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 10;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 10)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 10;
    }
    return _id;
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
