#################################################################
# Company: Thermoeye, Inc
# Project: TmSDK
# File: FirmwareWorker.py
# Creation date: 2024-08-19
# Version: 1.0.0
#
# Description: This file contains the following implementations:
#  - Thread class for updating camera firmware.
#
# History: 2024-08-19: Initial version.
#
#################################################################
from PyQt5.QtCore import QThread, pyqtSignal
from PyQt5.QtCore import QObject

class FirmwareWorker(QThread):
    progressChanged = pyqtSignal(int)
    workCompleted = pyqtSignal(bool, str)

    def __init__(self, parent):
        super().__init__();
        self.stopFlag = False
        self.parent = parent
        self.tmCamera = parent.camera.tmCamera

    def run(self):
        percent = 0
        if self.tmCamera is not None:
            while percent < 100 and not self.stopFlag:
                percent = self.tmCamera.tmControl.update_firmware()
                if percent >= 0:
                    self.progressChanged.emit(percent)
                else:
                    self.workCompleted.emit(False, "Error during download firmware.")
                    return

            if self.stopFlag:
                self.workCompleted.emit(False, "Update cancelled.")
            else:
                self.workCompleted.emit(True, "Update completed.")

    def stop(self):
        self.stopFlag = True
