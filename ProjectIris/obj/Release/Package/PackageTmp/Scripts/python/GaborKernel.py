#import matplotlib.pyplot as plt
#import numpy
#import cv2
#from scipy import signal as sg
#import math

#def gaborConvolve(img):
     
#    #filters = gaborFilters(0.2, 90, 4, 0, 0.02)
    
#    Sigma = 0.2
#    Lambda = 0.5 + 50 / 100
#    Theta = 0 * math.pi/180
#    Psi = 90 * math.pi/180
#    Gamma = 0.02
#    filters = gaborFilters(Sigma, Theta, Lambda, Psi, Gamma)
#    cimg = convolveImage(img, filters)

#    plt.imshow(cimg)
#    plt.show()

#    return cimg

##Sigma = Spatial Scaling (width of the filter)
##Lambda = Aspect Ratio (determines the directionality of the filter/s)
##Theta = Direction of filter
#def gaborFilters(sigma,theta,Lambda,psi,gamma):
#    sigma_x = sigma;
#    sigma_y = float(sigma)/gamma;
    
#    # Bounding box
#    nstds = 3;
#    xmax = max(abs(nstds*sigma_x*numpy.cos(theta)),abs(nstds*sigma_y*numpy.sin(theta)));
#    xmax = numpy.ceil(max(1,xmax));
#    ymax = max(abs(nstds*sigma_x*numpy.sin(theta)),abs(nstds*sigma_y*numpy.cos(theta)));
#    ymax = numpy.ceil(max(1,ymax));
#    xmin = -xmax; ymin = -ymax;
#    (x,y) = numpy.meshgrid(numpy.arange(xmin,xmax+1),numpy.arange(ymin,ymax+1 ));
#    (y,x) = numpy.meshgrid(numpy.arange(ymin,ymax+1),numpy.arange(xmin,xmax+1 ));
    
#    # Rotation 
#    x_theta=x*numpy.cos(theta)+y*numpy.sin(theta);
#    y_theta=-x*numpy.sin(theta)+y*numpy.cos(theta);
    
#    gb= numpy.exp(-.5*(x_theta**2/sigma_x**2+y_theta**2/sigma_y**2))*numpy.cos(2*numpy.pi/Lambda*x_theta+psi);
#    return gb


#def convolveImage(img, filters):
#    cimg = img.mean(axis=-1)
#    print filters
#    return sg.convolve(cimg, filters, "valid")


#--------------------------------------------------------------------------------------------------------------------------------


import matplotlib.pyplot as plt
import math
import numpy as np
from scipy import signal as sg
import cv2
from skimage import data
from skimage.filters import threshold_otsu, threshold_adaptive

def gaborConvolve(img):
    filters = build_filters()
    cimg = convolveImage(img, filters)

    #Image Inverse Thresholding
    #thresh = 127
    #maxValue = 255
    #th, cimg = cv2.threshold(cimg, thresh, maxValue, cv2.THRESH_BINARY_INV)

    #plt.imshow(cimg)
    #plt.show()

    return cimg

def build_filters():
    filters = []
    #Kernel Size - (Odd and Square for optimum results)
    ksize = 31
    #Width of Gaussian Envelope used in the gabor Kernel
    sigma = 4.5 
    #Wavelength of Sine Carrier
    lambd = 9
    #Controls the ellipticity of the gaussian. When gamma = 1, the gaussian envelope is circular
    gamma = 0.5
    #Phase offset
    psi =   0
    for theta in np.arange(0, np.pi, np.pi/16):
        kern = cv2.getGaborKernel((ksize, ksize), sigma, theta, lambd, gamma, psi, ktype=cv2.CV_32F)
        kern /= 1.5*kern.sum()
        filters.append(kern)
    return filters

def convolveImage(img, filters):
    accum = np.zeros_like(img)
    for kern in filters:
        fimg = cv2.filter2D(img, cv2.CV_8UC3, kern)
        np.maximum(accum, fimg, accum)
        #plt.imshow(cimg)
        #plt.show()
    return accum


#--------------------------------------------------------------------------------------------------------------------------------

#import matplotlib.pyplot as plt
#import math
#import numpy as np
#from scipy import signal as sg
#import cv2
#from skimage.filters import gabor_filter

#def gaborConvolve(img):
#    #Sigma = 0.02
#    #Lambda = 0.5 + 50 / 100
#    #Theta = 0 * math.pi/180
#    #Psi = 90 * math.pi/180
#    #Gamma = 50
#    filters = build_filters(img)
#    cimg = convolveImage(img, filters)

#    #cimg = cv2.threshold(cimg, 127, 255, cv2.THRESH_BINARY)
    
#    plt.imshow(cimg,'gray')
#    plt.show()

#def build_filters(img):
#    filters = []
#    sigma = (5.09030 * 8.0) / (3.0 / math.pi)
#    lambd = 0.1  #16/3
#    gamma = 0  #50
#    psi =   90 * math.pi / 180  #math.pi / 2
#    ksize = 11
#    for theta in np.arange(0, 180, 45):
#        #kern = gabor_filter(img, lambd, theta, 1, sigma_x=None, sigma_y=None, n_stds=3, offset = 0, mode='reflect', cval=0)
#        #filters.append(kern)
#        kern = cv2.getGaborKernel((ksize, ksize), sigma, theta, lambd, gamma, psi, ktype=cv2.CV_32F)
#        kern /= 1.5*kern.sum()
#        filters.append(kern)
#    return filters

#def convolveImage(img, filters):
#    #cimg = img.mean(axis=-1)
#    return sg.convolve(img, filters, "valid")