#include "TmLinux.h"

#include <QApplication>
int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    TmLinux w;
    w.show();
    return a.exec();
}
