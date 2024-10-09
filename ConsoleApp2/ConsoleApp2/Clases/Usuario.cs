using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Clases
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int CantFichas { get; set; }

        public Usuario(string nombreUsuario, string contrasena, int cantFichas)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            CantFichas = cantFichas;
        }

        public Usuario(string nombreUsuario, string contrasena)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Usuario: {NombreUsuario}" +
                $"\nContraseña: {Contrasena}" +
                $"\nCantidad de Fichas: {CantFichas}\n");
        }
    }
}
