using Tarea_Libreria.Interfaces;

namespace Tarea_Libreria.Clases
{
    public class Usuario : InterMembers
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }

        public Usuario(string nombreUsuario, string contrasena)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Usuario: {NombreUsuario}" +
                $"\nContraseña: {Contrasena}\n");
        }
    }
}
