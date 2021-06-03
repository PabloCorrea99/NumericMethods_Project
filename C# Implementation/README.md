# Julia Methods

Implementation of secuential and parallel Jacobi and secuential Gauss-Seidel Method's for solving systems of linear equations using Julia language.

## What Packages are needed?

There are no packages that need to be imported


## How to run it?

In the terminal of your preference you must be in the folder C# Implementation and run this command:

```
dotnet run .\Program.cs
```

You'll be asked the path of the Vector and the Matrix

Vector:
```
Escriba el path del vector
```
Matrix:
```
Escriba el path del Matriz
```
Then you'll be asked the size of the matrix

```
Escriba tamaño vector
```
At the end you'll need to select between Jacobi or Gauss-Seidel Method
<br>0=> Jacobi | Other # => Gauss-Seidel
```
Escriba 0 para Jacobi u otro numero para Gauss-Seidel
```
The Answer will be written in a .txt file and less info into a csv file, which will have 3 columns, the first one will be Method name, Iteration, Time in Ms