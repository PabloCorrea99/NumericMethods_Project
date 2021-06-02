import os
import numpy as np
from ReadData import readMatrix, readVector
import time
import threading
from multiprocessing import Pool

'''
Método que calcula (haciendo uso del paralelismo) la solución a un sistema de ecuaciones lineales por medio del método iterativo de Jacobi.
Entradas: Matriz Diagonalmente Dominante A, vector independiente b, tolerancia y maximo de iteraciones.
Salida: Vector de solución x.
'''
def jacobi(A, b, c, n, m):
    for i in range(n,m):
        suma = 0 
        for j in range(len(A[0])):
            if j != i:
                
                suma += A[i,j] * c[j]
        
        c[i] = (b[i] - suma) / A[i,i] 
    

if __name__ == '__main__':

    with Pool(processes=2) as pool:

        #Se crea la matriz A
        matrix = pool.apply_async(readMatrix,())
        
        # Se crea el vector B
        vector = pool.apply_async(readVector,())
        matrix.wait(50)
        vector.wait(5)
        A = matrix.get()
        b = vector.get()
        x = np.zeros_like(b, dtype=np.double)

        tolerance=1e-10
        max_iterations=500
        t0 = time.time()
        bloques = int(len(A[0]))/10

        if (len(A[0])%10 == 0):
            hilos = 10

        elif (len(A[0])<10):
            hilos = 1
            

        elif (len(A[0])==1):
            print("No es una matriz")
            exit(1)
            
        else:
            hilos = 11
        
        for k in range(max_iterations):
            x_old = x.copy()
            list_threads = []
            i=0
            j=1
            #Numero Maximo de Procesos es p-1, Ya que la maquina cuenta con 12 procesadores logicos
            for num_thread in range(1, hilos+1):
                if( num_thread == 11 ):
                    t = threading.Thread(target=jacobi, args=(A,b,x,int(bloques*j),len(A[0]),))
                    list_threads.append(t)
                    t.start()
                elif(len(A[0])<10):
                    t = threading.Thread(target=jacobi, args=(A,b,x,0,len(A[0]),))
                    list_threads.append(t)
                    t.start()
                    break
                else:
                    t = threading.Thread(target=jacobi, args=(A,b,x,int(bloques*i),int(bloques*j),))
                    list_threads.append(t)
                    t.start()
                i+=1
                j+=1
            

            for t in list_threads:
                t.join() #Termina los procesos de cada procesador       

            if np.linalg.norm(x - x_old, ord=np.inf) / np.linalg.norm(x, ord=np.inf) < tolerance: #se verifica la tolerancia para ver si hubo convergencia
                break


        t1 = time.time()     
        total = t1-t0
        print(total)     
        print(x)
        