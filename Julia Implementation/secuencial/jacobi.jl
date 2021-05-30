using LinearAlgebra

function read_matrix_A()
    stream = open("C:/Users/Usuario/Desktop/Universidad/7 SEMESTRE/NumericMethods_Project/matriz.txt", "r")

    line_count = 1
    A = Array{Float64}(undef, 10000, 10000)
    
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

function read_vector_b()
    stream = open("C:/Users/Usuario/Desktop/Universidad/7 SEMESTRE/NumericMethods_Project/vector.txt", "r")

    b = Array{Float64}(undef, 10000)

    line = readline(stream)
    b = map(x->parse(Float64, x), split(line, ","))

    return b

    close(stream)
end

function jacobi(A, b, x0, tol, maxiter)
    #=
    Realiza una serie de iteraciones para resolver el sistema de ecuaciones lineales,
    Ax = b, partiendo desde una suposicion inicial, x0.

    El algoritmo tiene como punto de parada cuando el cambio en x es menor que 'tol',
    o si se ha superado el numero maximo de iteraciones.
    =#

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
        k += 1

        rel_diff = norm(x - x_prev)
        #print(x, rel_diff, "\n")
        x_prev = copy(x)
    end
    return x, rel_diff, k
end

println("Empezo Lectura")

A = read_matrix_A()
b = read_vector_b()

x0 = zeros(10000)

println("Termino Lectura")

tol = 0.00001
maxiter = 100

@time x, rel_diff, k = jacobi(A, b, x0, tol, maxiter)

if k == maxiter
    print("WARNING: the jacobi iterations did not converge within the required tolerance. \n")
end

#print(x, rel_diff, k)
