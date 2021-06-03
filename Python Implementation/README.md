# Python Methods

Implementation of secuential and parallel Jacobi and secuential Gauss-Seidel Method's for solving systems of linear equations using Python language.

## What Packages are needed?

### numpy

This package is for measuring the execution time of each method.

To install it

```
pip install numpy
```

## How to run it?

### Run everything from the main (in the Python Implementation folder), the args are explain below

```
python Main.py option1 option2 matrixA_direction matrixB_direction tolerance iterations 
```
option1: -h for HPC methods (Gauss seidel, Jacobi HPC, Jacobi Parallel) and -n for secuential method(Jacobi)

option2(just for -h): -gs (Gauss Seidel), -jh (Jacobi HPC), -jp (Jacobi Parallel)
