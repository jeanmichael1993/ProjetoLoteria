using ProjetoLoteria.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjetoLoteria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = @"C:\Users\jeanm\Desktop\loteria\Novo(a) Planilha do Microsoft Excel.csv";
            StreamReader sr = null;
            string targetPath = @"C:\Users\jeanm\Desktop\loteria\resultado.csv";
            List<string> linhas = new List<string>();
            List<Numeros> linhasResultado1 = new List<Numeros>();
            Numeros numeros = new Numeros();
            string cod = "";
            try
            {
                sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    linhas.Add(line);
                }
                foreach (String x in linhas)
                {
                    List<string> teste1 = new List<string>();
                    string[] vet = x.Split(";");
                    cod = vet[0];
                    for (int i = 1; i < vet.Length; i++)
                    {
                        int index;
                        int j;
                        index = Convert.ToInt32(vet[i]);
                        j = i;
                        while ((j > 1) && (Convert.ToInt32(vet[j - 1]) > index))
                        {
                            Convert.ToInt32(vet[j] = vet[j - 1]);
                            j = j - 1;
                        }

                        vet[j] = Convert.ToString(index);
                      

                    }

                    for(int j=1;j< vet.Length; j++)
                    {
                        teste1.Add(vet[j]);
                    }
                   
                    linhasResultado1.Add(new Numeros { Cod = cod, Num = teste1 });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }

            try
            {
                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (Numeros line in linhasResultado1)
                    {
                        var final = line.Cod;
                        foreach (string x in line.Num)
                        {
                            final += $";{x}";
                        }

                        sw.WriteLine(final);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
