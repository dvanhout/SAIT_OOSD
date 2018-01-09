#!/usr/bin/python3

import RPi.GPIO as GPIO
import time

inpin = 7;
outpin = 11;


GPIO.setmode(GPIO.BOARD);
GPIO.setup(inpin, GPIO.IN);
GPIO.setup(outpin, GPIO.OUT);

def loop():
    if (GPIO.input(inpin)):
        GPIO.output(outpin, 0);
        print("Button is up");
    else:
        GPIO.output(outpin, 1);
        print("Button is down");
    time.sleep(.5);

#if __name__ == "__main__":
print("starting");

try:
    while True:
        loop();
except KeyboardInterrupt:
    print("stopping");
    GPIO.cleanup();


