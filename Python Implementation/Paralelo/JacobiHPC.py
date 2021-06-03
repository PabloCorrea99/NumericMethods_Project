import numpy as np
from .ReadData import readMatrix, readVector
import time
from multiprocessing import Pool

'''
Método que calcula la solución a un sistema de ecuaciones lineales por medio del método iterativo de Jacobi. Haciendo uso de la forma Matricial x = Tx + C.
Entradas: Matriz Diagonalmente Dominante A, vector independiente b, tolerancia y maximo de iteraciones.
Salida: Vector de solución x.
'''

def jacobi(A, b, tolerance, max_iterations):
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
    # return x
    return total


def start(direccionA, direccionB, tolerancia=1e-10, iteraciones=500):

    with Pool(processes=2) as pool:
        #Se crea la matriz A
        matrix = pool.apply_async(readMatrix,(direccionA,))
        
        # Se crea el vector B
        vector = pool.apply_async(readVector,(direccionB,))
        matrix.wait(50)
        vector.wait(5)
        A = matrix.get()
        b = vector.get()
        for i in range(0,10):
            result = jacobi(A, b, float(tolerancia), int(iteraciones))
            f = open("valoresPuntoPy.csv", "a")
            f.write("Jacobi HPC #,"+i+","+result+"\n")
            f.close()