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

            // -----------------------------------------------------------
			// Leer desde .txts

            
			double[][] p = new double[5000][];
			double[] x = new double[5000];

            for(int j= 1;j<6;j++)
            {
                StreamWriter streamWriter = new StreamWriter("valores.txt", append: true);
                streamWriter.WriteLine("Jacobi #"+j.ToString());
                streamWriter.Close();
			    VectoresYMatrices.leerMatriz(p,"C:\\numeric\\numeric5000-"+j.ToString()+"\\matriz.txt");
			    VectoresYMatrices.leerVector(x,"C:\\numeric\\numeric5000-"+j.ToString()+"\\vector.txt");
                String s,m;
                for(int i = 0; i<10;i++)
                {
                    s = Jacobi.JacobiMethod(p,x,false,100,0.000001).ToString();
                    m = Jacobi.JacobiMethodParalel(p,x,false,100,0.000001).ToString();
                    StreamWriter puntos = new StreamWriter("valoresPuntos.csv", append: true);
                    s = "Jacobi Method #," +j.ToString()+ ","+i.ToString()+ "," + s;
                    m = "Jacobi Paralelo #," +j.ToString()+ ","+i.ToString()+ "," + m;
                    puntos.WriteLine(s);
                    puntos.WriteLine(m);
                    puntos.Close();
                }
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