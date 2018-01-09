#!/usr/bin/python

import RPi.GPIO as GPIO
import time
from http.server import BaseHTTPRequestHandler, HTTPServer
from socketserver import ThreadingMixIn

HOST = "10.163.101.128"
PORT = 8088
TRIG = 18
ECHO = 23

GPIO.setmode(GPIO.BCM)

GPIO.setup(TRIG, GPIO.OUT)
GPIO.setup(ECHO, GPIO.IN)

class ThreadedHTTPServer(ThreadingMixIn, HTTPServer):
    """creating a threaded server"""

class MyHandler (BaseHTTPRequestHandler):
    def do_GET(self):
        self.send_response(200)
        self.send_header("Content-type", "text/html")
        self.end_headers()

        distance = str(getDist())
        self.wfile.write(("<h1 style='color:orange'>Distance: " + distance + "</h1>").encode("utf-8"))
        return

def getDist():
    GPIO.output(TRIG, False)
    time.sleep(2)
    GPIO.output(TRIG, True)
    time.sleep(0.00001)
    GPIO.output(TRIG, False)

    while (GPIO.input(ECHO) == 0):
        pulse_start = time.time()

    while (GPIO.input(ECHO) == 1):
        pulse_end = time.time()

    pulse_duration = pulse_end - pulse_start
    print("Duration: " + str(pulse_duration))
    distance = pulse_duration * 17150
    distance = round(distance, 2)
    print("Distance: " + str(distance))
    return distance
    
    


if __name__ == "__main__":
    server_class = ThreadedHTTPServer
    httpd = server_class((HOST, PORT), MyHandler)

    try:
        httpd.serve_forever()
    except KeyboardInterrupt:
        pass
    finally:
        httpd.server_close()
        GPIO.cleanup()
    
