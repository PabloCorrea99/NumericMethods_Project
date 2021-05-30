import pandas as pd

def readMatrix():
    matrix = open('myfile.txt').read()
    matrix = [item.split(",") for item in matrix.split('\n')[:-1]]
    

def readVector():
    data = pd.read_csv('vector.txt', delimiter = "\t")
    return data