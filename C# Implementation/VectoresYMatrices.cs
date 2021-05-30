using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Proyecto
{
    class VectoresYMatrices
    {
        public static Random random = new Random();

        /// <summary>
		/// A un Matriz M, se le agregan numeros aleatorios
		/// </summary>
		/// <param name="m">Matrix al que se le pondran los numeros</param>
		/// <param name="n">Numero "maximo" que aparecera en la matrix</param>
		public static void crearMatrizRandomDominante(double[][] m, int n)
		{
			double s = 0;
			double r = 0;
			for(int i = 0; i < m.Length; i++)
			{
				m[i] = new double[m.Length];
				for(int j = 0; j < m.Length; j++)
				{
					if(i!=j)
					{
						r = Convert.ToDouble(random.Next(-n,n));
						m[i][j] = r;
						s+=Math.Abs(r);
					}
				}
				int x = (int) s;
				m[i][i] = Convert.ToDouble(random.Next(x+1,x+2));
				s=0;
			}
		}

		/// <summary>
		/// Se imprime la matriz m
		/// </summary>
		/// <param name="m">Matriz a imprimir</param>
		public static void imprimirMatriz(double[][] m)
		{
			double[] x;
			for(int i = 0; i < m.Length; i++)
			{
				x = m[i];
				Console.WriteLine("[{0}]", string.Join(", ", x));	
			}
		}

		/// <summary>
		/// Se escribe la matriz m
		/// </summary>
		/// <param name="m">Escribir la matriz m en un archivo de texto</param>
		public static void escribirMatriz(double[][] m)
		{
			String filepath= @"C:\numeric\matriz.txt";
			List<String> lineas = new List<string>();
			double[] x;
			for(int i = 0; i < m.Length; i++)
			{
				x = m[i];
				lineas.Add(string.Join(",", x));	
			}
			File.WriteAllLines(filepath,lineas);
		}

		/// <summary>
		/// Se lee el archivo en el path C:\numeric\matriz.txt
		/// </summary>
		/// <param name="m">Escribir la matriz m lo que esta en un archivo de texto</param>
		public static void leerMatriz(double[][] m,String filepath= @"C:\numeric\matriz.txt")
		{
			String[] lineas = File.ReadAllLines(filepath).ToArray();
			if(lineas.Length != m.Length)
			{
				Console.WriteLine("Error al leer la matriz no coincide el tamaño");
				Environment.Exit(0);
			}
			else
			{
				for(int i = 0; i < m.Length; i++)
				{
					String[] s = lineas[i].Split(",");
					m[i] = new double[m.Length];
					for(int j = 0; j <s.Length;j++)
					{
						try
						{
							m[i][j] = Convert.ToDouble(s[j]);
						}
						catch (InvalidCastException e)
						{
							Console.WriteLine("Error al leer el archivo"+e);
							Environment.Exit(0);
						}	
						
					}
				}
			}
		}

		/// <summary>
		/// Se lee el archivo en el path C:\numeric\matriz.txt
		/// </summary>
		/// <param name="v">Escribir el vector v lo que esta en un archivo de texto</param>
		public static void leerVector(double[] v,String filepath= @"C:\numeric\vector.txt")
		{
			String[] lineas = File.ReadAllLines(filepath).ToArray();
			String[] s = lineas[0].Split(",");
			if(s.Length != v.Length)
			{
				Console.WriteLine("Error al leer el vector no coincide el tamaño");
				Environment.Exit(0);
			}
			else
			{
				for(int i = 0; i < v.Length; i++)
				{
					try
					{
						v[i] = Convert.ToDouble(s[i]);
					}
					catch (InvalidCastException e)
					{
						Console.WriteLine("Error al leer el archivo"+e);
						Environment.Exit(0);
					}					
				}
			}
		}

		/// <summary>
		/// Se escribe el vector v
		/// </summary>
		/// <param name="v">Escribir el vector v en un archivo de texto</param>
		public static void escribirVector(double[] v)
		{
			String filepath= @"C:\numeric\vector.txt";
			List<String> lineas = new List<string>();
			lineas.Add(string.Join(", ", v));	
			File.WriteAllLines(filepath,lineas);
		}

		/// <summary>
		/// A un vector V, se le agregan numeros aleatorios
		/// </summary>
		/// <param name="v">Vector al que se le pondran los numeros</param>
		/// <param name="n">Numero maximo que aparecera en el vector</param>
		public static void crearVectorRandom(double[] v, int n)
		{
			for(int i = 0; i < v.Length; i++)
			{
				v[i] = Convert.ToDouble(random.Next(n));	
			}
		}

        /// <summary>
		/// A un vector V, se le agregan numeros aleatorios
		/// </summary>
		/// <param name="laMatriz">Matriz A</param>
		/// <param name="respuesta">Vector B</param>
		/// <returns>Boleano si se puede usar la matriz y el vector respuesta</returns>
		public static bool sePuedeUsar(double[][] laMatriz,double[] respuesta)
		{
			if(!esDominante(laMatriz))
			{
				Console.WriteLine("La matriz A no es estrictamente diagonalmente dominante");
				return false;
			}
			else if(laMatriz.Length != laMatriz[0].Length)
			{
				Console.WriteLine("La matriz A no es NxN");
				return false;
			}
			else if(laMatriz.Length != respuesta.Length)
			{
				Console.WriteLine("El tamaño de la matriz no coicide con el del vector");
				return false;
			}
			return true;
		}

		/// <summary>
		/// Error relativo entre 2 vectores
		/// </summary>
		/// <param name="xk">Vector k</param>
		/// <param name="xk1">Vector k+1</param>
		/// <returns>Error entre los 2 vectores</returns>
		public static double errorRelativo(double[] xk, double[] xk1)
		{
			if(xk.Max() == 0 && xk1.Max()==0)
			{
				return 1;
			}

			int n = xk.Length;
			double numMax=0;

			for(int i = 0; i < n; i++)
			{
				double x = xk1[i] - xk[i];
				if(x < 0)
				{
					x *= -1;
				}
				if(x > numMax)
				{
					numMax = x;
				}
			}

			double denMax = 0;
			for(int i = 0; i < n; i++)
			{
				double x = xk1[i];
				if(x > denMax)
				{
					denMax = x;
				}
			}

			if (denMax == 0)
			{
				// Console.WriteLine("\t Error = 0");
				return 0;
			}
			double error = numMax/denMax;
			// Console.WriteLine("\t Error: "+error.ToString());
			return error;
		}

		/// <summary>
		/// Metodo para ver si la Matriz m es estrictamente diagonalmente dominante
		/// </summary>
		/// <param name="m">Matriz</param>
		/// <returns>Boleano indicando si la matriz m es estrictamente diagonalmente dominante</returns>
		public static bool esDominante(double[][] m)
		{
			for(int i=0;i<m.Length;i++)
			{
				double number=0;
				for(int j=0;j<m.Length;j++)
				{
					if(j!=i)
					{
						number+=Math.Abs(m[i][j]);
					}	
				}
				if(Math.Abs(m[i][i])<=number)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Metodo para copiar los valores del vector y0 en x0
		/// </summary>
		/// <param name="x0">Vector x0</param>
		/// <param name="yo">Vector y0</param>
		public static void copy(double[] x0, double[] y0)
		{
			for(int i = 0; i < y0.Length;i++)
			{
				x0[i] = y0[i];
			}
		}

		/// <summary>
		/// Se imprime el vector v
		/// </summary>
		/// <param name="v">Vector a imprimir</param>
		public static void imprimirVector(double[] v)
		{
			Console.WriteLine("[{0}]", string.Join(", ", v));
			Console.WriteLine("FIN");
		}
    }
}