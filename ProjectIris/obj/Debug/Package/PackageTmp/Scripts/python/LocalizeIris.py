import matplotlib.pyplot as plt
import cv2
import cv2.cv as cv
import Circles as circ
import sys
import base64

def localizeIris(path):
    #img = cv2.imread("C:\Users\eldrad294\Desktop\eyePNG.png", 0)
    img = cv2.imread(path, 0)

    #Image resizing
    r = 600.0 / img.shape[1]
    dim = (600, int(img.shape[0] * r))
    img = cv2.resize(img, dim, interpolation=cv2.INTER_AREA)

    #Image Blur/Gaussian Filter
    bimg = cv2.medianBlur(img, 9)

    #Convert to BGR Image
    cimg = cv2.cvtColor(img, cv2.COLOR_GRAY2BGR)

    #Hough Transform
    inner_iris = cv2.HoughCircles(bimg, cv.CV_HOUGH_GRADIENT, 1, 390, param1=15, param2=30, minRadius=0, maxRadius=0)
    outer_iris = cv2.HoughCircles(bimg, cv.CV_HOUGH_GRADIENT, 1, 390, param1=15, param2=30, minRadius=100, maxRadius=140)

    #Drawing Edge Circles
    Cinner_iris = circ.drawCircles(cv2, inner_iris, cimg)
    Couter_iris = circ.drawCircles(cv2, outer_iris, cimg)

    # cv2.imshow("Detected Circles", cimg)
    # cv2.waitKey(0)
    # cv2.destroyAllWindows()

    #plt.imshow(cimg)
    #plt.show()

    return cimg


#SOBEL EDGE DETECTION
# from scipy import misc
# from scipy import ndimage
# import numpy as np
# import matplotlib.pyplot as plt
#
# eye = misc.imread("C:/Users/eldrad294/PycharmProjects/IrisEncoder/resources/eye.jpg")
# eye = ndimage.gaussian_filter(eye, 8)
# sx = ndimage.sobel(eye, axis=0, mode='constant')
# sy = ndimage.sobel(eye, axis=1, mode='constant')
# sob = np.hypot(sx, sy)
#
# plt.imshow(sob)
# plt.axis('off')
# plt.title('Eye Image', fontsize=40)
# plt.show()


#CANNY EDGE DETECTION









