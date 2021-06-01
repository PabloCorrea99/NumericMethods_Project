import numpy as np
import time
def readMatrix():
    inicio = time.time()
    matriz = np.zeros((10000, 10000), dtype=int)
    archivo = open("C:/Users/Usuario/Desktop/Universidad/7SEMESTRE/NumericMethods_Project/matriz.txt").read()
    i = 0
    for item in archivo.split('\n')[:-1]:
        linea = item.split(",")
        for numero in range(len(linea)):
            matriz[i, numero]=int(linea[numero])
        i+=1   
    final = time.time()
    print(final-inicio)
    return matriz



def readVector():
    inicio = time.time()
    vector = np.zeros(10000, dtype=int)
    archivo = open("C:/Users/Usuario/Desktop/Universidad/7SEMESTRE/NumericMethods_Project/vector.txt").read()
    linea = archivo.split(",")
    for numero in range(len(linea)):
        vector[numero]=int(linea[numero]) 
        final = time.time()
    print(final-inicio)
    return vector
