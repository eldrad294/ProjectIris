#Class Container for entire image encoding process
import LocalizeIris as li
import SegmentIris as si
import NormalizeIris as ni
import GaborKernel as gk
import Encode as en
import sys
import cv2
import matplotlib.pyplot as plt
import MeanBlocks as mb

imagePath = "C:\\inetpub\\wwwroot\\ProjectIris\\ProjectIris\\Content\\img\\irisimages\\" + sys.argv[1]
#imagePath = "C:\\Users\\eldrad\\Desktop\\Img_17_1_1.jpg"
#imagePath = "C:\\Users\\eldra\\Desktop\\Stuff\\University\\FYP\\UBIRIS_800_600\\heye.jpg"

#Draw circles around iris borders, and calculate pupil centre
li.localizeIris(imagePath)

#Segment the iris by applying masks over schelera and pupil, rendering only the iris visible
image, pupil, radius = si.segmentIris(imagePath)

#Normalization of the Iris image from cartesian plain to polar coordinates
image = ni.normalizeIris(image, pupil, radius)

#Convolve Image with Gabor Filter Bank. We get 2 seperate Images after convolment (Real and Imaginary) Images
imageReal, imageImaginary = gk.gaborConvolve(image)

#Extract phase information from Real and Imaginary images
meanReal, meanImaginary = mb.get_mean_values(imageReal, imageImaginary)

#Generate iriscode from combined phase information
iriscode = mb.generate_iriscode(meanReal, meanImaginary)

print iriscode



