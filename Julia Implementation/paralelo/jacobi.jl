using Distributed
using SharedArrays
using LinearAlgebra
using BenchmarkTools
addprocs(16)

@everywhere using Distributed
@everywhere using SharedArrays
@everywhere using LinearAlgebra

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
    stream = open("C:/Users/Usuario/Desktop/Universidad/7 SEMESTRE/NumericMethods_Project/vector.txt")

    b = Array{Float64}(undef, 10000)

    line = readline(stream)
    b = map(x->parse(Float64, x), split(line, ","))

    return b

    close(stream)
end

println("Empezo la lectura")

a = read_matrix_A()
a = SharedMatrix(a)

b = read_vector_b()
b = SharedVector(b)

x_prev = zeros(size(a)[1])
x_prev = SharedVector(x_prev)

x = zeros(size(a)[1])
x = SharedVector(x)

println("Termino la lectura")

col_asign = convert(UInt64, (size(a)[1])/nworkers())

rel_diff = 0.0

function prueba()
    @sync @distributed for t in 0:nworkers()-1
        for i=(t*col_asign)+1:(t*col_asign)+col_asign
            subs = 0.0
            for j in 1:size(a)[1]
                if (j != i)
                    subs += a[i,j] * x_prev[j]
                end
            end
            x[i] = (b[i] - subs) / a[i,i]
        end
    end
end

function main()

    tol = 0.00001
    maxiter = 100

    rel_diff = 2*tol
    k = 0

    while (rel_diff > tol) && (k < maxiter)
        prueba()
        #print(x)
        rel_diff = norm(x - x_prev)
        #println(rel_diff)
        global x_prev
        x_prev = copy(x)
        k += 1
    end
    #= print(k)
    print(x)
    println(rel_diff) =#
end

@btime main()