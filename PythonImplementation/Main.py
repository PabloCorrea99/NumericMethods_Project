import Secuencial.Jacobi as jacobiS
import Secuencial.ReadData
from Paralelo import Jacobi, JacobiHPC, Gauss_Seidel, ReadData
import os
import sys

def correrPrograma():
    if(sys.argv[1]=='-h'):
        if(sys.argv[2]=='-jp'):
            Jacobi.start("C:/Users/Usuario/Desktop/Universidad/7SEMESTRE/NumericMethods_Project/vector.txt")
        elif(sys.argv[2]=='jh'):
        elif(sys.argv[2]=='gs'):
    elif(sys.argv[1]=='-n'):
        



if __name__ == '__main__':
    correrPrograma()