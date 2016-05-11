#Class Container for entire image encoding process
import LocalizeIris as li
import SegmentIris as si
import NormalizeIris as ni
import GaborKernel as gk
import Encode as en
import sys
import cv2
from LBP import LocalBinaryPatterns
import matplotlib.pyplot as plt

imagePath = "C:\\Users\\eldra\\Documents\\Visual Studio 2015\\Projects\\ProjectIris\\ProjectIris\\Content\\img\\irisimages\\" + sys.argv[1]
#imagePath = "C:\\Users\\eldra\\Desktop\\Stuff\\University\\FYP\\UBIRIS_800_600\\Sessao_1\\8\\Img_8_1_1.jpg"

#Draw circles around iris borders, and calculate pupil centre
li.localizeIris(imagePath)

#Segment the iris by applying masks over schelera and pupil, rendering only the iris visible
image, pupil, radius = si.segmentIris(imagePath)

#Normalization of the Iris image from cartesian plain to polar coordinates
image = ni.normalizeIris(image, pupil, radius)

#plt.imshow(image)
#plt.show()

#Convolve Image with Gabor Filter Bank
image = gk.gaborConvolve(image)

#Apply LBP Window to convolved image
desc = LocalBinaryPatterns(24, 1)
hist = desc.describe(image)

#Convert LBP output into binary
print en.getBitPattern(hist)



