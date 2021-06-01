using System;
using System.Linq;	//Vector de 0s
using System.Diagnostics; // StopWatch

namespace Proyecto
{
    class GaussSeidel
    {
        
        /// <summary>
		/// Metodo de Gauss-Seidel para solucionar sistemas de ecuaciones lineales	Ax=B
		/// </summary>
		/// <param name="laMatriz">Matriz A</param>
		/// <param name="respuesta">Vector B</param>
		/// <param name="imprimir">True si imprime todas las iteraciones false por defecto para solo imprimir la iteracion final</param>
		/// <param name="iterations">Numero de iteraciones, si no es colocado son 50 iteracions</param>
		/// <param name="e">Error, si no es colocado el error es de 0.2</param>
		/// <param name="iGuess">Vector del valor inicial, si no es colocado se ponen un vector 0</param>
		/// <returns>Vector con la solucion, que para o por iteracion o por error</returns>
        public static double[] GaussSeidelMethod(double[][] laMatriz, double[] respuesta, bool imprimir = false, int iterations = 50, double e = 0.02, double[] iGuess = null)
        {
			Console.WriteLine("Gauss-Seidel Empieza");
			if(!VectoresYMatrices.sePuedeUsar(laMatriz,respuesta))
			{
				Environment.Exit(0);
			}
            Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			double[] solucion;
			if(iGuess == null)
			{
				solucion = (Enumerable.Repeat(0.0, respuesta.Length).ToArray());
			}
            else
			{
				solucion = new double[respuesta.Length];
				VectoresYMatrices.copy(solucion,iGuess);
			}
			double[] solucion1 = new double[respuesta.Length];
			VectoresYMatrices.copy(solucion1,solucion);
			double error = 0;
			bool termino = false;
            for(int p = 0; p < iterations; p++)
            {
                for (int i = 0; i < laMatriz.Length; i++)
                {
                    double sigma = 0;
                    for (int j = 0; j < laMatriz[0].Length; j++)
                    {
                        if (j != i)
                            sigma += laMatriz[i][j] * solucion1[j];
                    }
                    solucion1[i] = (respuesta[i] - sigma) / laMatriz[i][i];
                }
				error = VectoresYMatrices.errorRelativo(solucion,solucion1);
				if(imprimir)
                	Console.WriteLine("Step #" + p + ": " + String.Join(", ", solucion1.Select(v => v.ToString()).ToArray())+"\tError: "+ error.ToString());

				if(error <= e)
				{
					Console.WriteLine("Para por criterio error deseado");
					Console.WriteLine("Step #" + p + ": " + String.Join(", ", solucion1.Select(v => v.ToString()).ToArray())+"\tError: "+ error.ToString());
					termino = true;
					break;
				}
				VectoresYMatrices.copy(solucion,solucion1);
            }
			stopwatch.Stop();
			if(!termino)
				Console.WriteLine("Step #" + (iterations-1) + ": " + String.Join(", ", solucion1.Select(v => v.ToString()).ToArray())+"\tError: "+ error.ToString());
			
			Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            return solucion1;
        }
    }
}