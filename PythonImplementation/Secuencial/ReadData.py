import numpy as np

def readMatrix():
    matriz = np.zeros((10000, 10000), dtype=int)
    archivo = open("C:/Users/Usuario/Desktop/Universidad/7SEMESTRE/NumericMethods_Project/matriz.txt").read()
    i = 0
    for item in archivo.split('\n')[:-1]:
        linea = item.split(",")
        for numero in range(len(linea)):
            matriz[i, numero]=int(linea[numero])
        i+=1   

    return matriz



def readVector():
    vector = np.zeros(10000, dtype=int)
    archivo = open("C:/Users/Usuario/Desktop/Universidad/7SEMESTRE/NumericMethods_Project/vector.txt").read()
    linea = archivo.split(",")
    for numero in range(len(linea)):
        vector[numero]=int(linea[numero]) 

    return vector
