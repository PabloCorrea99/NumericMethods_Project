# Julia Methods

Implementation of secuential and parallel Jacobi and secuential Gauss-Seidel Method's for solving systems of linear equations using Julia language.

## What Packages are needed?

### TickTock

This package is for measuring the execution time of each method.

To install it enter to the Julia Command-Line, also known as the REPL(read-eval-print-loop) and execute this lines.

```
using Pkg
Pkg.add("TickTock")
```

### ArgParse

This package is for take arguments from the command line when executing a method.

To install it enter to the Julia Command-Line, also known as the REPL(read-eval-print-loop) and execute this lines.

```
using Pkg
Pkg.add("ArgParse")
```

## How to run it?

### Secuentials Methods

1. Jacobi

```
julia jacobi.jl -a <path_to_matrix_a> -b <path_to_vector_b>
```

2. Gauss-Seidel

```
julia gauss-seidel.jl -a <path_to_matrix_a> -b <path_to_vector_b>
```

### Parallel Method

1. Jacobi

```
$env:JULIA_NUM_THREADS=<number_of_threads>
```

```
julia jacobi.jl -a <path_to_matrix_a> -b <path_to_vector_b>
```