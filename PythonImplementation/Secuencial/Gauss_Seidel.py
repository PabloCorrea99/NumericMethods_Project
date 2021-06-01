import numpy as np
import time
from ReadData import readMatrix, readVector

'''
Método que calcula la solución a un sistema de ecuaciones lineales por medio del método iterativo de Gauss-Seidel.
Entradas: Matriz Diagonalmente Dominante A, vector independiente b, tolerancia y maximo de iteraciones.
Salida: Vector de solución x.
'''

def gauss_seidel(A, b, tolerance=1e-10, max_iterations=100):
    t0 = time.time()
    x = np.zeros_like(b, dtype=np.double)
    
    #Ciclo para revisar iteraciones maximas
    for k in range(max_iterations):
        
        x_old  = x.copy()
        
        #Se itera en cada fila
        for i in range(A.shape[0]):
            x[i] = (b[i] - np.dot(A[i,:i], x[:i]) - np.dot(A[i,(i+1):], x_old[(i+1):])) / A[i,i]
            
        #Condición de Parada 
        if np.linalg.norm(x - x_old, ord=np.inf) / np.linalg.norm(x, ord=np.inf) < tolerance:
            break
    
    t1 = time.time()

    total = t1-t0
    print(total)        
    return x

#Se crea la matriz A
matrixA = readMatrix()
#Se crea el vector b
vectorB = readVector()
x = gauss_seidel(matrixA, vectorB)
print(x)
