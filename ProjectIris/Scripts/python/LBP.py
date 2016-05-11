from skimage import feature
import numpy as np
import cv2
 
class LocalBinaryPatterns:
    def __init__(self, numPoints, radius):
		# store the number of points and radius
		self.numPoints = numPoints
		self.radius = radius

    def describe(self, image, eps=1e-7):
        image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
        lbp = feature.local_binary_pattern(image, self.numPoints, self.radius, method="uniform")
        return lbp