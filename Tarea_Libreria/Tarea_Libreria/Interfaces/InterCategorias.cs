using Tarea_Libreria.Clases;

namespace Tarea_Libreria.Interfaces
{
    public interface InterCategorias
    {
        string Titulo { get; set; }
        int CantidadStock { get; set; }
        void MostrarStock() { }
    }
}
