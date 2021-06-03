import numpy as np
from .ReadData import readMatrix, readVector
import time



'''
Método que calcula (haciendo uso del paralelismo) la solución a un sistema de ecuaciones lineales por medio del método iterativo de Jacobi.
Entradas: Matriz Diagonalmente Dominante A, vector independiente b, tolerancia y maximo de iteraciones.
Salida: Vector de solución x.
'''
def jacobi(a, b, x, tolerance, kmax):
    t0 = time.time()
    n = a.shape[0]
    k = 1

    while k < kmax:
        x_old  = x.copy()
        for i in range(n):
            suma = 0
            for j in range(n):
                if j != i:
                    suma += a[i,j]*x[j]
            x[i] = (b[i] - suma) / a[i,i]        
        k += 1
        if np.linalg.norm(x - x_old, ord=np.inf) / np.linalg.norm(x, ord=np.inf) < tolerance: #se verifica la tolerancia para ver si hubo convergencia
            break
    t1 = time.time()     
    total = t1-t0
    print(total)
    return total   
    # return x

def start(direccionA, direccionB, tolerancia=1e-10, iteraciones=500):
    #Se crea la matriz A
    A = readMatrix(direccionA)

    #Se crea el vector independiente b
    b = readVector(direccionB)
    x = np.zeros_like(b, dtype=np.double)
    for i in range(0,10):
        result = jacobi(A,b,x, float(tolerancia), int(iteraciones))
        f = open("valoresPuntoPy.csv", "a")
        f.write("Jacobi #,"+i+","+result+"\n")
        f.close()