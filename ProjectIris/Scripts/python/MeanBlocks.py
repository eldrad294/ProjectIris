import matplotlib.pyplot as plt
import math
import numpy as np
from scipy import signal as sg
from skimage.util import img_as_float
from PIL import Image
import cv2

def get_mean_values(imageReal, imageImaginary):
    "Splits normalized iris into 50 blocks, and calculates pixel mean for every block and returns all values as a list, for both Real and Imaginary Images"
    height, width, depth = imageReal.shape
    meanReal = []
    meanImaginary = []
    for i in range(0, width, 25):
        for j in range(0, height, 25):
            cropR = imageReal[j: j + 25, i: i + 25]
            cropI = imageImaginary[j: j + 25, i: i + 25]
            threshR = image_threshold(cropR)
            threshI = image_threshold(cropI)
            meanR = get_pixel_mean(threshR)
            meanI = get_pixel_mean(threshI)
            meanReal.append(meanR)
            meanImaginary.append(meanI)

    return meanReal, meanImaginary

def image_threshold(image):
    "Thresholding image"
    #Image Inverse Thresholding
    thresh = 100
    maxValue = 255
    th, image = cv2.threshold(image, thresh, maxValue, cv2.THRESH_BINARY_INV)
    return image

#def getPhaseOffset(meanReal, meanImaginary):
#    "Returns a single list containing all angles in preparation for the phase demodulator"
#    theta_list = []
#    for i in range(0, len(meanReal)):
#        theta_list.append(calculate_theta(meanReal[i], meanImaginary[i]))
#    return theta_list
   
#def calculate_theta(valueR, valueI):
#    return math.degrees(np.arctan(valueI/valueR))

def get_pixel_mean(image):
    height, width, depth = image.shape
    mean = 0
    for i in range(0, width):
        for j in range(0, height):
            try:
                if image[i][j][0] == 255:
                    mean += 1
                else: mean -= 1
            except:
                pass        
    return mean

def generate_iriscode(listR, listI):
    iriscode = ""
    for i in range(0, len(listR)):
        real = listR[i]
        imagine = listI[i]
        if real <= 0:
            iriscode += str(0)
        else:
            iriscode += str(1)

        if imagine <= 0:
            iriscode += str(0)
        else:
            iriscode += str(1)

    return iriscode

    