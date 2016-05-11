import cv2
import cv2.cv as cv
import matplotlib.pyplot as plt
import Circles as circ
import sys

def segmentIris(path):
    #img = cv2.imread('C:\Users\eldrad294\Desktop\eye.jpg', 0)
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
    #Cinner_iris = circ.drawCircles(cv2, inner_iris, cimg)
    #Couter_iris = circ.drawCircles(cv2, outer_iris, cimg)

    #Retrieving center coordiantes of pupil and storing in a list
    pupil = [circ.getCircleCentre(inner_iris, 0), circ.getCircleCentre(inner_iris, 1)]

    #Creating mask over image, leaving the only the iris
    innerRadius = circ.getCircleRadius(inner_iris)
    outerRadius = circ.getCircleRadius(outer_iris)
    mask = circ.sector_mask(cimg.shape, (circ.getCircleCentre(outer_iris, 1), circ.getCircleCentre(outer_iris, 0)), outerRadius, (0, 360)) - circ.sector_mask(cimg.shape, (pupil[1], pupil[0]), innerRadius, (0, 360))
    cimg[~mask] = 0

    # cv2.imshow("Detected Circles", cimg)
    # cv2.waitKey(0)
    # cv2.destroyAllWindows()

    #plt.imshow(cimg)
    #plt.show()

    return cimg, pupil, outerRadius