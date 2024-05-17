using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    internal class ArbolBinario2
    {
        public NodoArbol? NodoRaiz { get; set; }
        string respuesta;

        public ArbolBinario2()
        {
            NodoRaiz = null;
        }

        bool ArbolVacio() => NodoRaiz == null;

        NodoArbol CrearNodo()
        {
            NodoArbol nuevoNodo = new NodoArbol();

            if (ArbolVacio())
            {
                Console.WriteLine("Ingrese el dato para el nodo raíz: ");
                nuevoNodo.Informacion = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ingrese el dato para el nodo: ");
                nuevoNodo.Informacion = Console.ReadLine();
            }

            return nuevoNodo;
        }

        public void PoblarArbol(NodoArbol nodo)
        {
            if (ArbolVacio())
            {
                nodo = CrearNodo();
                NodoRaiz = nodo;
            }

            Console.WriteLine($"Existe nodo por la izq. de {nodo.Informacion}");
            respuesta = Console.ReadLine().ToString().Trim().ToLower();

            if (respuesta.Equals("s"))
            {
                NodoArbol nuevoNodo = new NodoArbol();
                nuevoNodo = CrearNodo();

                nodo.RamaIzquierda = nuevoNodo;

                PoblarArbol(nodo.RamaIzquierda);


            }

            // rama derecha
            Console.WriteLine($"Existe nodo por la der. de {nodo.Informacion}");
            respuesta = Console.ReadLine().ToString().Trim().ToLower();

            if (respuesta.Equals("s"))
            {
                NodoArbol nuevoNodo = new NodoArbol();
                nuevoNodo = CrearNodo();

                nodo.RamaDerecha = nuevoNodo;

                PoblarArbol(nodo.RamaDerecha);


            }

        }

        public void RecorridoPreorden(NodoArbol nodo)
        {
            if (nodo == null)
            {
                return;
            }
            else
            {

                Console.Write($"{nodo.Informacion} > ");
                RecorridoPreorden(nodo.RamaIzquierda);
                RecorridoPreorden(nodo.RamaDerecha);

            }

        }

        public void RecorridoInorden(NodoArbol nodo)
        {
            if (nodo == null)
            {
                return;
            }
            else
            {

                RecorridoInorden(nodo.RamaIzquierda);
                Console.Write($"{nodo.Informacion} >");

                RecorridoInorden(nodo.RamaDerecha);
            }

        }

        public void RecorridoPostorden(NodoArbol nodo)
        {
            if (nodo == null)
            {
                return;
            }

            else
            {

                RecorridoPostorden(nodo.RamaIzquierda);
                RecorridoPostorden(nodo.RamaDerecha);

                Console.Write($"{nodo.Informacion} > ");
            }
        }

        //recorrido iterativo
        public void RecorridoInordenIterativo(NodoArbol nodo)
        {
            NodoArbol actual = nodo;
            while (actual != null)
            {
                if (actual.RamaIzquierda == null)
                {
                    Console.Write($"{actual.Informacion} > ");
                    actual = actual.RamaDerecha;
                }
                else
                {
                    NodoArbol predecesor = actual.RamaIzquierda;
                    while (predecesor.RamaDerecha != null && predecesor.RamaDerecha != actual)
                    {
                        predecesor = predecesor.RamaDerecha;
                    }
                    if (predecesor.RamaDerecha == null)
                    {
                        predecesor.RamaDerecha = actual;
                        actual = actual.RamaIzquierda;
                    }
                    else
                    {
                        predecesor.RamaDerecha = null;
                        Console.Write($"{actual.Informacion} > ");
                        actual = actual.RamaDerecha;
                    }
                }
            }
        }
        public void RecorridoPreordenIterativo(NodoArbol? nodo)
        {
            NodoArbol? actual = nodo;

            while (actual != null)
            {
                if (actual.RamaIzquierda == null)
                {
                    Console.Write($"{actual.Informacion} > ");
                    actual = actual.RamaDerecha;
                }
                else
                {
                    NodoArbol predecesor = actual.RamaIzquierda;
                    while (predecesor.RamaDerecha != null && predecesor.RamaDerecha != actual)
                    {
                        predecesor = predecesor.RamaDerecha;
                    }

                    if (predecesor.RamaDerecha == null)
                    {
                        Console.Write($"{actual.Informacion} > ");
                        predecesor.RamaDerecha = actual;
                        actual = actual.RamaIzquierda;
                    }
                    else
                    {
                        predecesor.RamaDerecha = null;
                        actual = actual.RamaDerecha;
                    }
                }
            }
        }
        public void GraficaArbol(NodoArbol? nodo, int nivel = 0, string indent = "")
        {
            if (nodo == null)
            {
                return;
            }

            if (nodo.RamaDerecha != null)
            {
                GraficaArbol(nodo.RamaDerecha, nivel + 1, indent + "       ");
            }

            Console.Write(indent);

            if (nivel > 0)
            {
                if (nodo.RamaDerecha != null)
                {
                    Console.Write(" ");

                }
                else
                {
                    Console.Write(" ");

                }
            }

            Console.Write(nodo.Informacion);

            if (nodo.RamaIzquierda != null)
            {
                Console.Write(" ");
            }

            Console.WriteLine();

            if (nodo.RamaIzquierda != null)
            {
                GraficaArbol(nodo.RamaIzquierda, nivel + 1, indent + "       ");
            }
        }

    }

}

