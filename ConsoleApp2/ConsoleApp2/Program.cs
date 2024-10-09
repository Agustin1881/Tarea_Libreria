using ConsoleApp2.Clases;

class Program
{

    static void Main()
    {
        void LogIn(int numPlayer, string user, string password, List<Usuario> ListaUsuarios,
        string usuarioActual, string contraActual)
        {
            for (int i = 0; i < ListaUsuarios.Count; i++)
            {
                if (ListaUsuarios[i].NombreUsuario == user &&
                    ListaUsuarios[i].Contrasena == password)
                {
                    usuarioActual = user;
                    contraActual = password;
                    numPlayer = i;
                    return;
                }
                else
                {
                    Console.WriteLine("Usuario o contraseña incorrecto");
                }
            }
        }


        List<Usuario> ListaUsuarios = new List<Usuario>();
        bool Registrado = false;
        int opcionGame, numPlayer = 0;
        string usuarioActual = "", contraActual = "";

        while (!Registrado)
        {
            Console.Clear();
            Console.WriteLine("\n=== Casino Web ===\n\n" +
                              "1. Sign In\n" +
                              "2. Log In");
            int opcionMenu = int.Parse(Console.ReadLine());

            switch (opcionMenu)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Nuevo usuario: ");
                    string nuevoUser = Console.ReadLine();
                    Console.Write("Nueva contraseña: ");
                    string nuevaContra = Console.ReadLine();
                    Console.Write("Confirme contraseña: ");
                    string nuevaContraVerificacion = Console.ReadLine();

                    if (nuevaContra == nuevaContraVerificacion)
                    {
                        ListaUsuarios.Add(new Usuario(nuevoUser, nuevaContra, 2000));
                        Console.WriteLine("Usuario registrado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Las contraseñas no coinciden.");
                    }
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("\nUsuario: ");
                    string user = Console.ReadLine();
                    Console.Write("Contraseña: ");
                    string contra = Console.ReadLine();

                    LogIn(numPlayer, user, contra, ListaUsuarios, usuarioActual, contraActual);
                    Registrado = true;
                    
                    break;
                   
                default:
                    Console.WriteLine("Opcion no valida\n" +
                                      "Ingrese otra opcion");
                    Console.Clear();
                    break;
            }
        }

        while (Registrado)
        {
            Console.Clear();
            Console.WriteLine("\nBienvenido!\n");
            ListaUsuarios[numPlayer].MostrarInfo();
            Console.WriteLine("Juegos:" +
                                          "\n1_ 21 BlackJack" +
                                          "\n2_ Poker" +
                                          "\n3_ Tragamonedas");
            opcionGame = int.Parse(Console.ReadLine());

            switch (opcionGame)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\nJuego: 21 BlackJack");
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("\nJuego: Poker");
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("\nJuego: Tragamonedas");
                    break;
                default:
                    Console.WriteLine("Opción de categoría no válida.");
                    break;
            }
        }
    }
}
