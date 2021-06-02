import numpy as np
from ReadData import readMatrix, readVector
import time

'''
Método que calcula la solución a un sistema de ecuaciones lineales por medio del método iterativo de Jacobi.
Entradas: Matriz Diagonalmente Dominante A, vector independiente b, tolerancia y maximo de iteraciones.
Salida: Vector de solución x.
'''

def jacobi(A, b, tolerance=1e-10, max_iterations=500):
    t0 = time.time()
    x = np.zeros_like(b, dtype=np.double)
    #x = Tx + C
    T = A - np.diag(np.diagonal(A)) #Se crea la matriz de iteraciones
    
    for k in range(max_iterations):
        
        x_old  = x.copy() #Se copia la x vieja para el calculo de la convergencia
        
        x = (b - np.dot(T, x)) / np.diagonal(A) #Se calcula el x -> b-suma/aii 
        
        if np.linalg.norm(x - x_old, ord=np.inf) / np.linalg.norm(x, ord=np.inf) < tolerance: #se verifica la tolerancia para ver si hubo convergencia
            break
    t1 = time.time()     
    total = t1-t0
    print(total)     
    return x

#Se crea la matriz A
matrixA = readMatrix()
#Se crea el vector b
vectorB = readVector()
x = jacobi(matrixA, vectorB)
print(x)