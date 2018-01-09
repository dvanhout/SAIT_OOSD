#!/usr/bin/python3

import RPi.GPIO as GPIO
import time

pin = [7, 11, 13, 15];

GPIO.setmode(GPIO.BOARD);
GPIO.setup(pin, GPIO.OUT);

for i in range(0, 4):
    GPIO.output(pin[i], GPIO.HIGH);
    time.sleep(i);
    GPIO.output(pin[i], GPIO.HIGH);
    time.sleep(i);
    GPIO.output(pin[i], GPIO.HIGH);
    time.sleep(i);
    GPIO.output(pin[i], GPIO.HIGH);
    time.sleep(i);
    GPIO.output(pin[i], False);
    time.sleep(i);
    GPIO.output(pin[i], False);
    time.sleep(i);
    GPIO.output(pin[i], False);
    time.sleep(i);
    GPIO.output(pin[i], False);
    time.sleep(i);

GPIO.cleanup();


