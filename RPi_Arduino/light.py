#!/usr/bin/python

import time, spidev

spi = spidev.SpiDev();

spi.open(0,0);

def read_sensor():
    r = spi.xfer2([1,(8+0)<<4, 0]);
    output = ((r[1]&3)<<8)+r[2];
    return output;

try:
    print("Starting up");
    while (True):
        print(read_sensor());
except:
    print("Shutting down");
