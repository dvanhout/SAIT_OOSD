#!/usr/bin/env python

import base64, re, email.utils
from imaplib import IMAP4_SSL as IMAP

import RPi.GPIO as GPIO
import time

HOSTNAME = 'imap.gmail.com'
USERNAME = 'oosddemo3@gmail.com'
PASSWORD = 'OOSDP@$$w0rd2'
MAILBOX = 'INBOX'



outpin1 = 13;
outpin2 = 15;

GPIO.setmode(GPIO.BOARD);
GPIO.setup(outpin1, GPIO.OUT);
GPIO.setup(outpin2, GPIO.OUT);

def loop():
    server = IMAP(HOSTNAME, 993)
    server.login(USERNAME, PASSWORD)
    server.select(MAILBOX, readonly=True)
    result,folder_status = server.status(MAILBOX, '(UNSEEN)')
    #print(folder_status)
    m = re.search('UNSEEN (\d+)', folder_status[0].decode(encoding='UTF-8'))
    #print(m.group(0))
    #print(m.group(1))

    print("You have " + m.group(1) + " unread emails.")
    if (int(m.group(1)) > 0):
        GPIO.output(outpin1, True)
        GPIO.output(outpin2, False)
    else:
        GPIO.output(outpin1, False)
        GPIO.output(outpin2, True)
        
    
    time.sleep(3);

#if __name__ == "__main__":
print("starting");

try:
    while True:
        loop();
except KeyboardInterrupt:
    print("stopping");
    GPIO.cleanup();


