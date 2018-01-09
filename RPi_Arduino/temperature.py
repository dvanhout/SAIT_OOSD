#!/usr/bin/python

import os
import glob
import time
import re

os.system('modprobe w1-gpio');
os.system('modprobe w1-therm');

base_dir = '/sys/bus/w1/devices';

device_dir = glob.glob(base_dir + "/28*")[0];
device_file = device_dir + "/w1_slave";

def readTemp():
    f = open(device_file, 'r');
    lines = f.readlines();
    f.close();
    m = re.search("t=(\d+)", lines[1]);
    return float(m.group(1)) / 1000.0;


if __name__ == "__main__":
    print("starting");
    try:
        while True:
            print(readTemp());
            time.sleep(1);
    except (KeyboardInterrupt):
        print("shutting down");
