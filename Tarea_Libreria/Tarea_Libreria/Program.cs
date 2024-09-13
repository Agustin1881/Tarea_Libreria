using Tarea_Libreria.Clases;

class Program
{
    static void Main()
    {
        List<Usuario> ListaUsuarios = new List<Usuario>();
        bool Registrado = false;

        while (!Registrado)
        {
            Console.WriteLine("\n=== Libreria Web ===\n\n" +
                              "1. Sign In\n" +
                              "2. Log In");
            int opcionMenu = int.Parse(Console.ReadLine());

            switch (opcionMenu)
            {
                case 1:
                    Console.Write("Nuevo usuario: ");
                    string nuevoUser = Console.ReadLine();
                    Console.Write("Nueva contraseña: ");
                    string nuevaContra = Console.ReadLine();
                    Console.Write("Confirme contraseña: ");
                    string nuevaContraVerificacion = Console.ReadLine();

                    if (nuevaContra == nuevaContraVerificacion)
                    {
                        ListaUsuarios.Add(new Usuario(nuevoUser, nuevaContra));
                        Console.WriteLine("Usuario registrado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Las contraseñas no coinciden.");
                    }
                    break;

                case 2:
                    Console.Write("\nUsuario: ");
                    string user = Console.ReadLine();
                    Console.Write("Contraseña: ");
                    string contra = Console.ReadLine();

                    Registrado = false;

                    for (int i = 0; i < ListaUsuarios.Count; i++)
                    {
                        if (ListaUsuarios[i].NombreUsuario == user &&
                            ListaUsuarios[i].Contrasena == contra)
                        {
                            Registrado = true;
                        }
                    }

                    if (!Registrado)
                    {
                        Console.WriteLine("Usuario o contraseña incorrecto");
                    }
                    else
                    {
                        Console.WriteLine("\nCategorias:" +
                                          "\n1. Accion" +
                                          "\n2. Ciencia Ficcion" +
                                          "\n3. Romantico");
                        int opcionCategoria = int.Parse(Console.ReadLine());

                        switch (opcionCategoria)
                        {
                            case 1:
                                Console.WriteLine("\nCategoria: Accion");
                                Accion categoriaAccion = new Accion();
                                categoriaAccion.MostrarStock();
                                break;
                            case 2:
                                Console.WriteLine("\nCategoría: Ciencia Ficción");
                                CienciaFiccion categoriaCienciaFiccion = new CienciaFiccion();
                                categoriaCienciaFiccion.MostrarStock();
                                break;
                            case 3:
                                Console.WriteLine("\nCategoría: Romántico");
                                Romantico categoriaRomantica = new Romantico();
                                categoriaRomantica.MostrarStock();
                                break;
                            default:
                                Console.WriteLine("Opción de categoría no válida.");
                                break;
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Opcion no valida\n" +
                                      "Ingrese otra opcion");
                    break;
            }
        }
    }
}
