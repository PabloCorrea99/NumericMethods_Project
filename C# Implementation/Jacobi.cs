using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Proyecto
{
    class Jacobi
    {

        /// <summary>
		/// Metodo de Jacobi para solucionar sistemas de ecuaciones lineales	Ax=B
		/// </summary>
		/// <param name="laMatriz">Matriz A</param>
		/// <param name="respuesta">Vector B</param>
		/// <param name="iterations">Numero de iteraciones, si no es colocado son 50 iteracions</param>
		/// <param name="e">Error, si no es colocado el error es de 0.2</param>
		/// <param name="iGuess">Vector del valor inicial, si no es colocado se ponen un vector 0</param>
		/// <returns>Vector con la solucion, que para o por iteracion o por error</returns>
		public static double[] JacobiMethod(double[][] laMatriz, double[] respuesta, bool imprimir = false, int iterations = 50, double e = 0.02, double[] iGuess = null)
        {
			Console.WriteLine("Jacobi Empieza");
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
						{
							sigma += laMatriz[i][j] * solucion[j];
						}
                    }
                    solucion1[i] = (respuesta[i] - sigma) / laMatriz[i][i];
                }
				error = VectoresYMatrices.errorRelativo(solucion,solucion1);
				if (imprimir)
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
			if (!termino)
				Console.WriteLine("Step #" + (iterations-1) + ": " + String.Join(", ", solucion1.Select(v => v.ToString()).ToArray())+"\tError: "+ error.ToString());
			
			
			Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
			
            return solucion1;
        }

		/// <summary>
		/// Metodo de Jacobi para solucionar sistemas de ecuaciones lineales	Ax=B
		/// </summary>
		/// <param name="laMatriz">Matriz A</param>
		/// <param name="respuesta">Vector B</param>
		/// <param name="iterations">Numero de iteraciones, si no es colocado son 50 iteracions</param>
		/// <param name="e">Error, si no es colocado el error es de 0.2</param>
		/// <param name="iGuess">Vector del valor inicial, si no es colocado se ponen un vector 0</param>
		/// <returns>Vector con la solucion, que para o por iteracion o por error</returns>
		public static double[] JacobiMethodParalel(double[][] laMatriz, double[] respuesta, bool imprimir = false, int iterations = 50, double e = 0.02, double[] iGuess = null)
        {
			if(laMatriz.Length < 10)
			{
				Console.WriteLine("Jacobi Paralel No es la forma optima de correr el metodo");
			}
            if(!VectoresYMatrices.sePuedeUsar(laMatriz,respuesta))
			{
				Environment.Exit(0);
			}
			Console.WriteLine("Jacobi Paralel Empieza");
            Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int l = laMatriz.Length;
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
				if(laMatriz.Length<10)
				{
					Parallel.For(0,laMatriz.Length,delegate(int i){JacobiParalel(laMatriz,solucion,respuesta,i,solucion1);});
				}
				else
				{
					int s = l/10;
					int m = l%10;
					if(m==0)
					{
						Task[] tasks = new Task[10];
						tasks[0] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*0,s*1,solucion1));
						tasks[0].Start();
						tasks[1] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*1,s*2,solucion1));
						tasks[1].Start();
						tasks[2] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*2,s*3,solucion1));
						tasks[2].Start();
						tasks[3] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*3,s*4,solucion1));
						tasks[3].Start();
						tasks[4] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*4,s*5,solucion1));
						tasks[4].Start();
						tasks[5] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*5,s*6,solucion1));
						tasks[5].Start();
						tasks[6] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*6,s*7,solucion1));
						tasks[6].Start();
						tasks[7] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*7,s*8,solucion1));
						tasks[7].Start();
						tasks[8] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*8,s*9,solucion1));
						tasks[8].Start();
						tasks[9] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*9,s*10,solucion1));
						tasks[9].Start();
						Task.WaitAll(tasks);				
					}
					else
					{
						Task[] tasks = new Task[11];
						tasks[0] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*0,s*1,solucion1));
						tasks[0].Start();
						tasks[1] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*1,s*2,solucion1));
						tasks[1].Start();
						tasks[2] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*2,s*3,solucion1));
						tasks[2].Start();
						tasks[3] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*3,s*4,solucion1));
						tasks[3].Start();
						tasks[4] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*4,s*5,solucion1));
						tasks[4].Start();
						tasks[5] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*5,s*6,solucion1));
						tasks[5].Start();
						tasks[6] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*6,s*7,solucion1));
						tasks[6].Start();
						tasks[7] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*7,s*8,solucion1));
						tasks[7].Start();
						tasks[8] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*8,s*9,solucion1));
						tasks[8].Start();
						tasks[9] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*9,s*10,solucion1));
						tasks[9].Start();
						tasks[10] = new Task(()=> JacobiParalelTask(laMatriz,solucion,respuesta,s*10,(s*10)+m,solucion1));
						tasks[10].Start();
						Task.WaitAll(tasks);
					}
				}
				error = VectoresYMatrices.errorRelativo(solucion,solucion1);
				if (imprimir)
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
			if (!termino)
				Console.WriteLine("Step #" + (iterations-1) + ": " + String.Join(", ", solucion1.Select(v => v.ToString()).ToArray())+"\tError: "+ error.ToString());
			
			
			Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
			
            return solucion1;
        }

		/// <summary>
		/// Metodo de Jacobi con el paralelismo
		/// </summary>
		/// <param name="laMatriz">Matriz A</param>
		/// <param name="solucion">Vector solucion</param>
		/// <param name="i">Numero en el que esta el Jacobi</param>
		/// <param name="solucion1">Vector solucion k+1</param>
		/// <returns>Jacobi usando paralelismo para menos de 10 hilos</returns>
		private static void JacobiParalel(double[][] laMatriz,double[] solucion, double[] respuesta,int i,double[] solucion1)
		{
			double sigma = 0;
			for (int j = 0; j < laMatriz.Length; j++)
			{
				if (j != i)
				{
					sigma += laMatriz[i][j] * solucion[j];
				}
			}
			solucion1[i] = (respuesta[i] - sigma) / laMatriz[i][i];
		}

		/// <summary>
		/// Metodo de Jacobi con el paralelismo
		/// </summary>
		/// <param name="laMatriz">Matriz A</param>
		/// <param name="solucion">Vector solucion</param>
		/// <param name="n">Numero en el que empiza el Jacobi</param>
		/// <param name="m">Numero que termina el jacobi</param>
		/// <param name="solucion1">Vector solucion k+1</param>
		/// <returns>Jacobi usando paralelismo para 10 o mas hilos</returns>
		private static void JacobiParalelTask(double[][] laMatriz,double[] solucion, double[] respuesta,int n,int m,double[] solucion1)
		{
			for (int i = n; i < m; i++)
			{
				double sigma = 0;
				for (int j = 0; j < laMatriz[0].Length; j++)
				{
					if (j != i)
					{
						sigma += laMatriz[i][j] * solucion[j];
					}
				}
				solucion1[i] = (respuesta[i] - sigma) / laMatriz[i][i];
			}
		}
    }
}