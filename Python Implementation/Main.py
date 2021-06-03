import Secuencial.Jacobi as jacobiS
import Secuencial.ReadData
from Paralelo import Jacobi, JacobiHPC, Gauss_Seidel, ReadData
import os
import sys

def correrPrograma():
    if(sys.argv[1]=='-h'):
        if(sys.argv[2]=='-jp'):
            if(len(sys.argv[3])>4 and len(sys.argv[4])>4):
                    for i in range(0,10):
                        result = Jacobi.start(sys.argv[3], sys.argv[4], sys.argv[5], sys.argv[6])
                        f = open("valoresPuntoPy.csv", "a")
                        f.write("Jacobi Paralelo #,"+i+","+result+"\n")
                        f.close()
        elif(sys.argv[2]=='-jh'):
            if(len(sys.argv[3])>4 and len(sys.argv[4])>4):
                JacobiHPC.start(sys.argv[3], sys.argv[4], sys.argv[5], sys.argv[6])
        elif(sys.argv[2]=='-gs'):
            if(len(sys.argv[3])>4 and len(sys.argv[4])>4):
                Gauss_Seidel.start(sys.argv[3], sys.argv[4], sys.argv[5], sys.argv[6])
        else:
            ("No eligio ninguna opcion!")
            exit(1)
    elif(sys.argv[1]=='-n'):
        if(len(sys.argv[2])>4 and len(sys.argv[3])>4):
            jacobiS.start(sys.argv[2], sys.argv[3], sys.argv[4], sys.argv[5])

    else:
        ("No eligio ninguna opcion valida!")

if __name__ == '__main__':
    correrPrograma()