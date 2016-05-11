def getBitPattern(imgarray):
    bitpattern = ""
    for i in range(0, len(imgarray)):
        for j in range(0, len(imgarray[i])):
            bitpattern += convertBinary(imgarray[i][j])
    return bitpattern

def convertBinary(num):
    return "%08d" % int(bin(int(num))[2:])
