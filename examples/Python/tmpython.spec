# -*- mode: python ; coding: utf-8 -*-
import os
from PyInstaller.utils.hooks import collect_submodules

a = Analysis(
    ['TmPython.py'],
    pathex=[],
    binaries=[],
    datas=[('mainwindow.ui', '.')],
    hiddenimports=collect_submodules('TmCore'),
    hookspath=[],
    hooksconfig={},
    runtime_hooks=[],
    excludes=[],
    noarchive=False,
    optimize=0,
)

# The pip PyQt5 wheel ships VC++ 14.26 beside Qt5Core.dll. PyInstaller packs
# that copy, and the frozen exe loads it instead of the system runtime
# (14.5x on this PC). libTmCore then crashes in Connect with a null read.
# Leave these out so Windows uses the runtime already installed with TmSDK.
_bundled_crt = {
    'concrt140.dll',
    'msvcp140.dll',
    'msvcp140_1.dll',
    'msvcp140_2.dll',
    'vcruntime140.dll',
    'vcruntime140_1.dll',
}
a.binaries = [
    entry for entry in a.binaries
    if os.path.basename(entry[0]).lower() not in _bundled_crt
]
pyz = PYZ(a.pure)

exe = EXE(
    pyz,
    a.scripts,
    a.binaries,
    a.datas,
    [],
    name='tmpython',
    debug=False,
    bootloader_ignore_signals=False,
    strip=False,
    upx=False,
    upx_exclude=[],
    runtime_tmpdir=None,
    console=True,
    disable_windowed_traceback=False,
    argv_emulation=False,
    target_arch=None,
    codesign_identity=None,
    entitlements_file=None,
)
