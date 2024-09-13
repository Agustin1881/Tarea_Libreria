using System;
using System.Collections.Generic;
using Tarea_Libreria.Interfaces;

namespace Tarea_Libreria.Clases
{
    public class Accion : InterCategorias
    {
        public string Titulo { get; set; }
        public int CantidadStock { get; set; }

        public Accion() { }

        public Accion(string titulo, int cantidadStock)
        {
            Titulo = titulo;
            CantidadStock = cantidadStock;
        }

        public static List<Accion> ListaAccion = new List<Accion>
        {
            new Accion("Titulo 1", 10),
            new Accion("Titulo 2", 15),
            new Accion("Titulo 3", 20)
        };

        public void MostrarStock()
        {
            Console.WriteLine("Libros de acción en stock:\n");

            for (int i = 0; i < ListaAccion.Count; i++)
            {
                Console.WriteLine($"{ListaAccion[i].Titulo}" +
                                  $"\nCantidad en stock: {ListaAccion[i].CantidadStock}\n");
            }
        }
    }
}
