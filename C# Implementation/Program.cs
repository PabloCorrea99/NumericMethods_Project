using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

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

			// -----------------------------------------------------------
			// Leer desde .txts
			double[][] p = new double[10000][];
			VectoresYMatrices.leerMatriz(p);

			double[] x = new double[10000];
			VectoresYMatrices.leerVector(x);	
			
			Jacobi.JacobiMethod(p,x,false,100,0);
			Jacobi.JacobiMethodParalel(p,x,false,100,0);
			
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

			// double[][] p = new double[100][];
			// VectoresYMatrices.crearMatrizRandomDominante(p,20);
			// VectoresYMatrices.escribirMatriz(p);
			// Console.WriteLine(VectoresYMatrices.esDominante(p));

			// double[] x = new double[100];
			// VectoresYMatrices.crearVectorRandom(x,20);
			// VectoresYMatrices.escribirVector(x);

        }
    }
}