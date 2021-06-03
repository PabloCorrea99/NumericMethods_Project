import numpy as np
import time
def readMatrix(direccion):
    print("Empieza Lectura de Matriz")
    archivo = open(direccion).read()
    i = 0
    doc = archivo.split('\n')[:-1]
    matriz = np.zeros((len(doc), len(doc)), dtype=int)
    for item in doc:
        linea = item.split(",")
        for numero in range(len(linea)):
            matriz[i, numero]=int(linea[numero])
        i+=1   
    print("Termina Lectura de Matriz")
    return matriz



def readVector(direccion):
    print("Empieza Lectura de Vector")
    archivo = open(direccion).read()
    linea = archivo.split(",")
    vector = np.zeros(len(linea), dtype=int)
    for numero in range(len(linea)):
        vector[numero]=int(linea[numero]) 

    print("Termina Lectura de Vector")
    return vector
