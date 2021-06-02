# Julia Methods

Implementation of secuential and parallel Jacobi and secuential Gauss-Seidel Method's for solving systems of linear equations using Julia language.

## What Packages are needed?

### TickTock

This package is for measuring the execution time of each method.

To install it enter to the Julia Command-Line, also known as the REPL(read-eval-print-loop) and execute this lines

```
using Pkg
Pkg.add("TickTock")
```

## How to run it?

### Secuentials Methods

1. Jacobi

```
julia jacobi.jl
```

2. Gauss-Seidel

```
julia gauss-seidel.jl
```

### Parallel Method

1. Jacobi

```
julia -t <number of threads> jacobi.jl
```