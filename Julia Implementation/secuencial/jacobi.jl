using LinearAlgebra
using TickTock
using ArgParse

"""
    read_matrix_A(path)

Perform the reading of the matrix and create the data structure.
"""
function read_matrix_A(path)
    stream = open(path, "r")

    total_lines = length(readlines(stream))
    line_count = 1
    A = Array{Float64}(undef, total_lines, total_lines)

    close(stream)
    
    stream = open(path, "r")

    while ! eof(stream)
        line = readline(stream)
        values = split(line, ",")
        for i in range(1, size(values)[1], step=1)
            A[line_count, i] = parse(Float64, values[i])
        end
        line_count += 1
    end

    return A

    close(stream)
end

"""
    read_vector_b(path)

Perform the reading of the vector and create the data structure.
"""
function read_vector_b(path)
    stream = open(path, "r")

    line = readline(stream)
    vector_size = split(line)

    close(stream)

    stream = open(path, "r")

    b = Array{Float64}(undef, length(vector_size))

    b = map(x->parse(Float64, x), split(line, ","))

    return b

    close(stream)
end

"""
    jacobi(A, b, x0, tol, maxiter)

Perform a series of jacobi iterations to solve the system of linear equations,
Ax = b, starting from an initial assumption, x0.

The algorithm has as its stopping point when the change in x is less than tolerance,
or if the maximum number of iterations has been exceeded.
"""
function jacobi(A, b, x0, tol, maxiter)
    tick()

    n = size(A)[1]
    x = copy(x0)
    x_prev = copy(x0)
    k = 0
    rel_diff = tol * 2

    while (rel_diff > tol) && (k < maxiter)
        for i in range(1, n, step=1)
            subs = 0.0
            for j in range(1, n, step=1)
                if i != j
                    subs += A[i,j] * x_prev[j]
                end
            end
            x[i] = (b[i] - subs) / A[i,i]   
        end

        rel_diff = norm(x - x_prev)
        x_prev = copy(x)
        k += 1
    end

    tock()
    return x, rel_diff, k
end

"""
    parse_commandline()

Perform the reading of the arguments passed to the file.
"""
function parse_commandline()
    s = ArgParseSettings()

    @add_arg_table s begin
        "--apath", "-a"
            help = "The path to file that contains Matrix A"
            required = true
        "--bpath", "-b"
            help = "The path to file that contains Vector b"
            required = true
    end

    return parse_args(s)
end

parsed_args = parse_commandline()

println("Started reading the file")

A = read_matrix_A(parsed_args["apath"])
b = read_vector_b(parsed_args["bpath"])

x0 = zeros(length(b))

println("Finished reading the file")

tol = 0.00001
maxiter = 100

x, rel_diff, k = jacobi(A, b, x0, tol, maxiter)

if k == maxiter
    print("WARNING: the jacobi iterations did not converge within the required tolerance. \n")
end

print(x, rel_diff, k)