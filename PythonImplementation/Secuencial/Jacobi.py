import numpy as np
from ReadData import readMatrix, readVector
import time



'''
Método que calcula (haciendo uso del paralelismo) la solución a un sistema de ecuaciones lineales por medio del método iterativo de Jacobi.
Entradas: Matriz Diagonalmente Dominante A, vector independiente b, tolerancia y maximo de iteraciones.
Salida: Vector de solución x.
'''
def jacobi(a, b, x, tolerance=1e-10, kmax=500):
    
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

    return x

#Se crea la matriz A
A = readMatrix()

# initialize the RHS vector
b = readVector()
x = np.zeros_like(b, dtype=np.double)
result = jacobi(A,b,x)
print(result)


