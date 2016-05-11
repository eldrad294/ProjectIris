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
import cv2

def gaborConvolve(img):
    filters = build_filters(0)
    filters2 = build_filters(1)
    cimgReal = convolveImage(img, filters)
    cimgImagine = convolveImage(img, filters2)

    #img = img[:,:,0]
    #cimgReal, cimgImagine = gabor_filter(img, frequency=0.8, theta=0, bandwidth=1, sigma_x=None, sigma_y=None, n_stds=3, offset=0, mode='reflect', cval=0)
    
    #Convert to Gray Scale
    cimgReal = cimgReal[:,:,0]
    cimgImagine = cimgImagine[:,:,0]
    cimgReal = cv2.cvtColor(cimgReal, cv2.COLOR_GRAY2BGR)
    cimgImagine = cv2.cvtColor(cimgImagine, cv2.COLOR_GRAY2BGR)

    #Image Inverse Thresholding
    #thresh = 127
    #maxValue = 255
    #th, cimgReal = cv2.threshold(cimgReal, thresh, maxValue, cv2.THRESH_BINARY_INV)
    #th, cimgImagine = cv2.threshold(cimgImagine, thresh, maxValue, cv2.THRESH_BINARY_INV)
    
    #plt.imshow(cimgReal, origin='lower')
    #plt.show()
    #plt.imshow(cimgImagine, origin='lower')
    #plt.show()

    return cimgReal, cimgImagine

#When Phase = 0, we get Real Image. When Phase = 1, we get Imaginary Image
def build_filters(phase):
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
    if phase == 0:
        psi = math.sin(90)
    else:
        psi = math.cos(90)

    for theta in np.arange(0, 180, 20):
        kern = cv2.getGaborKernel((ksize, ksize), sigma, theta, lambd, gamma, psi, ktype=cv2.CV_32F)
        kern /= 1.5*kern.sum()
        filters.append(kern)
    return filters

def convolveImage(img, filters):
    accum = np.zeros_like(img)
    for kern in filters:
        #plt.imshow(kern)
        #plt.show()
        fimg = cv2.filter2D(img, cv2.CV_8UC3, kern)
        np.maximum(accum, fimg, accum)
    return accum
