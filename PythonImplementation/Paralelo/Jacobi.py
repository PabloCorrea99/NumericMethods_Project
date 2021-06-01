import os
import numpy as np
from ReadData import readMatrix, readVector
import time
from multiprocessing import Pool, TimeoutError, cpu_count, Process

'''
Método que calcula (haciendo uso del paralelismo) la solución a un sistema de ecuaciones lineales por medio del método iterativo de Jacobi.
Entradas: Matriz Diagonalmente Dominante A, vector independiente b, tolerancia y maximo de iteraciones.
Salida: Vector de solución x.
'''
'''
def jacobi(A, b, x, n, m, tolerance=1e-10, max_iterations=500):
    t0 = time.time()
    
  
    for k in range(max_iterations):
        x_old = x.copy() 
        
        for i in range(n,m):
            jacobi
        if np.linalg.norm(x - x_old, ord=np.inf) / np.linalg.norm(x, ord=np.inf) < tolerance: #se verifica la tolerancia para ver si hubo convergencia
            break

    t1 = time.time()     
    total = t1-t0
    print(total)     
    return x
'''
def jacobiTask(A, b, x, n, m):
    for i in range(n,m):
        suma = 0 
        for j in range(len(A[0])):
            if j != i:
                
                suma += A[i,j] * x[j]
        
        x[i] = (b[i] - suma) / A[i,i] 
    
    return x

if __name__ == '__main__':
    #Se crea la matriz A
    A = np.array([[10., -1., 2., 0.],
                [-1., 11., -1., 3.],
                [2., -1., 10., -1.],
                [0.0, 3., -1., 8.]])

    # initialize the RHS vector
    b = np.array([6., 25., -11., 15.])
    x = np.zeros_like(b, dtype=np.double)
    tolerance=1e-10
    max_iterations=30
    new_x = x
    with Pool(processes=2) as pool:
        t0 = time.time()
        
        for k in range(max_iterations):
            #x_old = new_x.copy() 
            n = pool.apply_async(jacobiTask, (A,b,new_x,0,2,))
            m = pool.apply_async(jacobiTask, (A,b,new_x,2,4,))      
            n.wait()
            m.wait()
            print(n.get())
            print(m.get())
            new_x = np.add(n.get(),m.get())
            #print(new_x)
            #if np.linalg.norm(x - x_old, ord=np.inf) / np.linalg.norm(x, ord=np.inf) < tolerance: #se verifica la tolerancia para ver si hubo convergencia
               #break

        t1 = time.time()     
        total = t1-t0
        print(total)     
        print(x)
        