import numpy as np
from .ReadData import readMatrix, readVector
import time
from multiprocessing import Pool

'''
Método que calcula la solución a un sistema de ecuaciones lineales por medio del método iterativo de Jacobi. Haciendo uso de la forma Matricial x = Tx + C.
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


def start():

    with Pool(processes=2) as pool:
        #Se crea la matriz A
        matrix = pool.apply_async(readMatrix,())
        
        # Se crea el vector B
        vector = pool.apply_async(readVector,())
        matrix.wait(50)
        vector.wait(5)
        A = matrix.get()
        b = vector.get()
        x = jacobi(A, b)
        print(x)