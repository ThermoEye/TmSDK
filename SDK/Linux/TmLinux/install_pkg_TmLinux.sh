#!/bin/sh
# install gcc-11, g++-11
sudo add-apt-repository ppa:ubuntu-toolchain-r/test
sudo apt-get install -y gcc-11 g++-11 
sudo update-alternatives --install /usr/bin/gcc gcc /usr/bin/gcc-11 110 --slave /usr/bin/g++ g++ /usr/bin/g++-11 

# install Qt5
sudo apt install -y qtbase5-dev mesa-common-dev qtcreator

# install others packages
sudo apt install -y openexr libdc1394-dev libavcodec-dev libavformat-dev libswscale-dev make libgstreamer-plugins-base1.0-dev


