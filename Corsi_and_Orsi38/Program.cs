using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Corsi_and_Orsi38
{
    internal class Program
    {
            static void Main()
            {
                //dichiarazione variabili
                int scelta = 0;
                int scelta2 = 0;
                int dim = 0;
                int[] array = new int[100];
                int a, b;
            do
            {
                Console.Clear();
                Console.WriteLine("Premere uno dei seguenti tasti per selezionare l'operazione desiderata:");
                Console.WriteLine("0 - Passo successivo");
                Console.WriteLine("1 - Inserimento in posizione");
                Console.WriteLine("2 - Inserimento casuale");
                scelta2=int.Parse(Console.ReadLine());
                switch (scelta2)
                {
                    case 1:
                        //elaborazione
                        Console.Write("Inserire la lunghezza dell'array: ");
                        dim = int.Parse(Console.ReadLine());

                        for (int i = 0; i < dim; i++)
                        {
                            Console.Write("Inserire elemento in posizione {i}: ");
                            a = int.Parse(Console.ReadLine());
                            array[i] = a;
                        }
                        Thread.Sleep(3000);
                        break;
                    case 2:
                        Console.Write("Inserire numero minimo elementi:");
                        int min = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Inserire numero massimo elementi:");
                        int max = Convert.ToInt32(Console.ReadLine());
                        if()    //inserimento insert dato input(?)
                        insert(array,min, max);
                        Thread.Sleep(3000);
                        break;

                }



               ;
            } while (scelta2 != 0);
                //menù
                do
                {
                    Console.Clear();
                    Console.WriteLine("Premere uno dei seguenti tasti per selezionare l'operazione desiderata:");
                    Console.WriteLine("0 - Uscita");
                    Console.WriteLine("1 - Aggiungere un elemento");
                    Console.WriteLine("2 - Stampa degli elementi");
                    Console.WriteLine("3 - Stampa stringa in HTML");
                    Console.WriteLine("4 - Ricerca di un elemento");
                    Console.WriteLine("5 - Elimina un elemento");
                    Console.WriteLine("6 - Aggiungi un elemento nella posizione che sarà poi da specificare");
                    scelta = int.Parse(Console.ReadLine());

                    switch (scelta)
                    {
                        case 1:
                            Console.Write("Inserire un elemento: ");
                            a = int.Parse(Console.ReadLine());
                            if (Agg(array, a, ref dim))
                            {
                                Console.WriteLine("Elemento inserito");
                            }
                            else
                            {
                                Console.WriteLine("Array pieno");
                            }
                            break;

                        case 2:
                            for (int i = 0; i < dim; i++)
                            {
                                Console.Write(array[i] + " ");
                            }
                            break;

                        case 3:
                            Console.WriteLine();
                            Console.WriteLine("<!DOCTYPE html>\r\n<html lang=\"it\">\r\n<head>\r\n    <title>Ripasso Array-21</title>\r\n</head>\r\n<body>");
                            Console.WriteLine(Html(array, ref dim));
                            Console.WriteLine("</body>\r\n</html>");
                            Thread.Sleep(1000);
                            break;

                        case 4:
                            Console.Write("Inserire l'elemento che si desidera ricercare: ");
                            a = int.Parse(Console.ReadLine());
                            if (search(array, a) == -1)
                            {
                                Console.WriteLine("L'elemento non è stato trovato");
                            }
                            else
                            {
                                Console.WriteLine($"L'elemento {a} è stato trovato in posizione {search(array, a)}");
                            }
                            break;

                        case 5:
                            Console.Write("Inserire l'elemento da eliminare: ");
                            a = int.Parse(Console.ReadLine());
                            if (canc(array, a, ref dim))
                            {
                                Console.WriteLine("L'elemento è stato cancellato");
                            }
                            else
                            {
                                Console.WriteLine("L'elemento non è stato cancellato");
                            }
                            break;

                        case 6:
                            Console.Write("Inserire la posizione in cui si desidera inserire l'elemento: ");
                            b = int.Parse(Console.ReadLine());
                            Console.Write("Inserire l'elemento: ");
                            a = int.Parse(Console.ReadLine());
                            if (ins(array, a, b))
                            {
                                Console.WriteLine($"L'elemento {a} è stato inserito nella posizione {b}");
                            }
                            else
                            {
                                Console.WriteLine("L'elemento non è stato inserito");
                            }
                            break;
                    case 0:
                            Environment.Exit(0);
                            break;
                    }

                    Thread.Sleep(1000);
                } while (scelta != 0);
            }

            //funzione di Aggiunta
            static bool Agg(int[] array, int a, ref int index)
            {
                bool inserito = true;
                if (index < array.Length)
                {
                    array[index] = a;
                    index++;
                }
                else
                {
                    inserito = false;
                }
                return inserito;
            }

            //funzione di stampa in  Html
            static string Html(int[] array, ref int dim)
            {
                string code = "    <table>\n";
                for (int i = 0; i < dim; i++)
                {
                    code += "         <tr>\n";
                    code += "             <td>" + array[i] + "</td>\n";
                    code += "         </tr>\n";
                }
                code += "   </table>";
                return code;
            }

            //funzione di ricerca
            static int search(int[] array, int a)
            {
                int search = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == a)
                    {
                        search = i;
                        break;
                    }
                    else
                    {
                        search = -1;
                    }
                }

                return search;
            }

            //funzione di cancellazione
            static bool canc(int[] array, int a, ref int dim)
            {
                bool canc = false;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == a)
                    {
                        dim--;
                        for (int j = i; j < array.Length - 1; j++)
                        {
                            array[j] = array[j + 1];
                        }
                        canc = true;
                        break;
                    }
                }

                return canc;
            }

            //funzione di inserimento
            static bool ins(int[] array, int a, int b)
            {
                bool ins = false;

                if (b < array.Length)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                        array[i] = array[i - 1];
                    array[b] = a;
                    ins = true;
                }

                return ins;
            }
        //funzione di inserimento dato input
        static int insert(int [] array, int min, int max)
        {
            Random r = new Random();
            for (int i = min; i <= max; i++)
            {
                array[i]= r.Next(min, max);
            }
            return 0;
        }
        }
    }

