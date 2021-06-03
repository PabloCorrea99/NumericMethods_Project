using System;
using System.IO;

namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Empieza Programa");
			// // Creando manualmente las variables Gauss
            // double[][] GSA = new double[3][];
            // GSA[0] = new double[3];
            // GSA[1] = new double[3];
            // GSA[2] = new double[3];

            // GSA[0][0] = 9;
            // GSA[0][1] = 2;
            // GSA[0][2] = -1;

            // GSA[1][0] = 7;
            // GSA[1][1] = 8;
            // GSA[1][2] = 5;

            // GSA[2][0] = 3;
            // GSA[2][1] = 4;
            // GSA[2][2] = -10;

            // double[] GSB = new double[] { -2, 3, 6 };

            // GaussSeidel.GaussSeidelMethod(GSA, GSB, false,100,0);

			// // -----------------------------------------------------------
			// // Creando manualmente las variables Jacobi

			// double[][] JA = new double[3][];
            // JA[0] = new double[3];
            // JA[1] = new double[3];
            // JA[2] = new double[3];

            // JA[0][0] = 5;
            // JA[0][1] = 2;
            // JA[0][2] = -3;

            // JA[1][0] = 2;
            // JA[1][1] = 10;
            // JA[1][2] = -8;

            // JA[2][0] = 3;
            // JA[2][1] = 8;
            // JA[2][2] = 13;

			// double[] JB = new double[] { 1, 4, 7 };

            // Jacobi.JacobiMethod(JA, JB,false,100,0);

			// // -----------------------------------------------------------
			// // Leer desde .txts
			// double[][] p = new double[5000][];
			// VectoresYMatrices.leerMatriz(p);

			// double[] x = new double[5000];
			// VectoresYMatrices.leerVector(x);

            // Jacobi.JacobiMethod(p,x,false,100,0.000001);
            // Jacobi.JacobiMethodParalel(p,x,false,100,0.000001);

            // // -----------------------------------------------------------
			// // Consola
            // Console.WriteLine("Escriba el path del vector");
            // String pathVector = Console.ReadLine();
            // Console.WriteLine("Escriba el path del Matriz");
            // String pathMatriz = Console.ReadLine();
            // Console.WriteLine("Escriba tamaño vector");
            // int num = Convert.ToInt32(Console.ReadLine());

			// double[][] p = new double[num][];
			// VectoresYMatrices.leerMatriz(p,pathMatriz);

			// double[] x = new double[num];
			// VectoresYMatrices.leerVector(x,pathVector);

            // Console.WriteLine("Escriba 0 para Jacobi u otro numero para Gauss-Seidel");
            // int metodo = Convert.ToInt32(Console.ReadLine());
            // string s,m;
            // if(metodo==0)
            // {            
            //     for(int i = 0; i<10;i++)
            //     {
            //         s = Jacobi.JacobiMethod(p,x,false,100,0.000001).ToString();
            //         m = Jacobi.JacobiMethodParalel(p,x,false,100,0.000001).ToString();
            //         StreamWriter puntos = new StreamWriter("valoresPuntosCs.csv", append: true);
            //         s = "Jacobi Method #," +i.ToString()+ "," + s;
            //         m = "Jacobi Paralelo #," +i.ToString()+ "," + m;
            //         puntos.WriteLine(s);
            //         puntos.WriteLine(m);
            //         puntos.Close();
            //     }
            // }
            // else
            // {
            //     GaussSeidel.GaussSeidelMethod(p, x, false,100);
            // }
            // Console.WriteLine("Escriba el error");
            // double error = Convert.ToDouble(Console.ReadLine());

            // -----------------------------------------------------------
			// Leer desde .txts
            
			double[][] p = new double[5000][];
			double[] x = new double[5000];
            VectoresYMatrices.leerMatriz(p,"C:\\numeric\\numeric5000-atriz.txt");
            VectoresYMatrices.leerVector(x,"C:\\numeric\\numeric5000vector.txt");
            String s,m,g;
            for(int i=0;i<10;i++)
            {      
                s = Jacobi.JacobiMethod(p,x,false,100,0.000001).ToString();
                StreamWriter puntos = new StreamWriter("valoresPuntosCs.csv", append: true);
                s = "Jacobi Method #," +i.ToString()+ "," + s;
                puntos.WriteLine(s);
                puntos.Close();  
            }
            for(int i=0;i<10;i++)
            {      
                m = Jacobi.JacobiMethodParalel(p,x,false,100,0.000001).ToString();
                StreamWriter puntos = new StreamWriter("valoresPuntosCs.csv", append: true);
                m = "Jacobi Paralelo #," +i.ToString()+ "," + m;
                puntos.WriteLine(m);
                puntos.Close();  
            }
            for(int i=0;i<10;i++)
            {      
                g = GaussSeidel.GaussSeidelMethod(p,x,false,100,0.000001).ToString();
                StreamWriter puntos = new StreamWriter("valoresPuntosCs.csv", append: true);
                g = "Gauss-Seidel Paralelo #," +i.ToString()+ "," + g;
                puntos.WriteLine(g);
                puntos.Close();  
            }
			// //-----------------------------------------------------------
			// // Creando randoms

			// double[][] p = new double[10000][];
			// VectoresYMatrices.crearMatrizRandomDominante(p,30);

			// double[] x = new double[10000];
			// VectoresYMatrices.crearVectorRandom(x,30);
			
			// Jacobi.JacobiMethodParalel(p,x,false,100,0);
			// Jacobi.JacobiMethod(p,x,false,100,0);

			// //-----------------------------------------------------------
			// // Creando randoms y guardarlos en los .txt

			// double[][] p = new double[500][];
			// VectoresYMatrices.crearMatrizRandomDominante(p,20);
			// VectoresYMatrices.escribirMatriz(p,"matriz.txt");
			// Console.WriteLine(VectoresYMatrices.esDominante(p));

			// double[] x = new double[500];
			// VectoresYMatrices.crearVectorRandom(x,20);
			// VectoresYMatrices.escribirVector(x,"vector.txt");

        }
    }
}