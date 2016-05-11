import numpy as np

#Draws circle boundaries
def drawCircles(cv2, circles, cimg):
    if circles is None:
        print "No circles found"
    else:
        circles = np.uint16(np.around(circles))
        for i in circles[0, :]:
            #Drawing the outer circle
            cv2.circle(cimg, (i[0], i[1]), i[2], (0, 255, 0), 1)

            #Drawing the center of the circle
            cv2.circle(cimg, (i[0], i[1]), 2, (0, 0, 255), 3)
        return cimg

#Returns circle centre coordinate based on value. x=1, y=0
def getCircleCentre(circles, value):
    if circles is not None:
        for i in circles[0, :]:
            return i[value]

#Returns circle radius
def getCircleRadius(circles):
    if circles is not None:
        for i in circles[0, :]:
            return i[2]

#Returns circular mask
def sector_mask(shape, centre, radius, angle_range):
    """"Return a boolean mask for a circular sector. The start/stop angles in `angle_range` should be given in clockwise order."""

    x, y = np.ogrid[:shape[0], :shape[1]]
    cx, cy = centre
    tmin, tmax = np.deg2rad(angle_range)

    # ensure stop angle > start angle
    if tmax < tmin:
        tmax += 2 * np.pi

    # convert cartesian --> polar coordinates
    r2 = (x-cx)*(x-cx) + (y-cy)*(y-cy)
    theta = np.arctan2(x-cx, y-cy) - tmin

    # wrap angles between 0 and 2*pi
    theta %= (2*np.pi)

    # circular mask
    circmask = r2 <= radius*radius

    # angular mask
    anglemask = theta <= (tmax-tmin)

    return circmask * anglemask
