#include "TmWinQt.h"
#include <QtWidgets/QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    TmWinQt w;
    w.show();
    return a.exec();
}
