using ConsoleApp2.Clases;

class Program
{
    static void Clear()
    {
        Console.Clear();
        Console.WriteLine("=== Casino Web ===\n\n");
    }

    public class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }

    public class Deck
    {
        private Random random = new Random();
        private List<Card> cards = new List<Card>();
        private string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

        public Deck()
        {
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card { Rank = rank, Suit = suit });
                }
            }
        }

        public Card DrawRandomCard()
        {
            int index = random.Next(cards.Count);
            Card drawnCard = cards[index];
            cards.RemoveAt(index); // Para que no se repitan las cartas
            return drawnCard;
        }
    }

    public class Usuario
    {
        public string NombreUsuario { get; }
        public string Contrasena { get; }
        public int Balance { get; private set; }
        public bool Activo { get; }

        public Usuario(string nombreUsuario, string contrasena, int balance, bool activo)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Balance = balance;
            Activo = activo;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Usuario: {NombreUsuario}, Balance: {Balance}");
        }
    }

static void Main()
    {

        List<Usuario> ListaUsuarios = new List<Usuario>(); // (-1) a = 0 / b = 1 / c = 2
        int numPlayer = -1;
        string usuarioActual = "", contraActual = "";

        while (numPlayer == -1)
        {
            Clear();
            Console.WriteLine("1. Sign In\n" +
                              "2. Log In");
            int opcionMenu = int.Parse(Console.ReadLine());

            switch (opcionMenu)
            {
                case 1:
                    Clear();
                    Console.Write("Nuevo usuario: ");
                    string nuevoUser = Console.ReadLine();
                    Console.Write("Nueva contraseña: ");
                    string nuevaContra = Console.ReadLine();
                    Console.Write("Confirme contraseña: ");
                    string nuevaContraVerificacion = Console.ReadLine();

                    if (nuevaContra == nuevaContraVerificacion)
                    {
                        Console.WriteLine("Usuario registrado exitosamente.");
                        ListaUsuarios.Add(new Usuario(nuevoUser, nuevaContra, 2000, true));
                    }
                    else
                    {
                        Console.WriteLine("\nContraseñas no coinciden.");
                    }
                    Console.ReadLine();
                    break;

                case 2:
                    Clear();
                    Console.Write("Usuario: ");
                    string user = Console.ReadLine();
                    Console.Write("Contraseña: ");
                    string contra = Console.ReadLine();

                    LogIn(ref numPlayer, user, contra, ListaUsuarios, ref usuarioActual, ref contraActual);

                    if (numPlayer != -1)
                    {
                        Juegos(ListaUsuarios, numPlayer);
                    }
                    break;

                default:
                    Console.WriteLine("Opción no válida\nIngrese otra opción");
                    break;
            }
        }
    }

    static void LogIn(ref int numPlayer, string user, string password, List<Usuario> ListaUsuarios,
    ref string usuarioActual, ref string contraActual)
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
        }
        Console.WriteLine("Usuario o contraseña incorrecto");
    }

    static void Juegos(List<Usuario> ListaUsuarios, int numPlayer)
    {
        Clear();
        Console.WriteLine("Bienvenido!\n");
        ListaUsuarios[numPlayer].MostrarInfo();
        Console.WriteLine("Juegos:" +
                          "\n1. 21 BlackJack" +
                          "\n2. Poker" +
                          "\n3. Tragamonedas");
        int opcionGame = int.Parse(Console.ReadLine());

        switch (opcionGame)
        {
            case 1:
                Clear();
                Console.WriteLine("\nJuego: 21 BlackJack\n");
                BlackJack(ListaUsuarios, numPlayer);
                break;

            case 2:
                Clear();
                Console.WriteLine("\nJuego: Poker\n");
                // Poker(ListaUsuarios, numPlayer);
                break;

            case 3:
                Clear();
                Console.WriteLine("\nJuego: Tragamonedas\n");
                // Tragamonedas(ListaUsuarios, numPlayer);
                break;

            default:
                Console.WriteLine("Opción de categoría no válida.");
                break;
        }
    }
    static void BlackJack(List<Usuario> ListaUsuarios, int numPlayer)
    {
        ListaUsuarios[numPlayer].MostrarInfo();
        static void BlackJack(List<Usuario> ListaUsuarios, int numPlayer)
        {
            Deck deck = new Deck();
            int playerScore = 0, dealerScore = 0;

            // Repartir cartas iniciales
            for (int i = 0; i < 2; i++)
            {
                playerScore += GetCardValue(deck.DrawRandomCard());
                dealerScore += GetCardValue(deck.DrawRandomCard());
            }

            // Mostrar puntuación inicial
            Console.WriteLine($"Tu puntuación inicial: {playerScore}");
            Console.WriteLine($"Puntuación del dealer (oculta): ? + {GetCardValue(deck.DrawRandomCard())}");

            // Turno del jugador
            while (playerScore < 21)
            {
                Console.WriteLine("¿Quieres pedir otra carta? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    playerScore += GetCardValue(deck.DrawRandomCard());
                    Console.WriteLine($"Tu nueva puntuación: {playerScore}");
                }
                else
                {
                    break;
                }
            }

            // Turno del dealer (simplificado)
            while (dealerScore < 17)
            {
                dealerScore += GetCardValue(deck.DrawRandomCard());
            }

            // Resultados
            Console.WriteLine($"Tu puntuación final: {playerScore}");
            Console.WriteLine($"Puntuación del dealer: {dealerScore}");

            // Determinar el ganador
            if (playerScore > 21)
            {
                Console.WriteLine("Te has pasado. ¡Perdiste!");
            }
            else if (dealerScore > 21 || playerScore > dealerScore)
            {
                Console.WriteLine("¡Ganaste!");
            }
            else if (playerScore < dealerScore)
            {
                Console.WriteLine("Perdiste.");
            }
            else
            {
                Console.WriteLine("Es un empate.");
            }
        }

        static int GetCardValue(Card card)
        {
            if (int.TryParse(card.Rank, out int value))
            {
                return value;
            }
            else if (card.Rank == "A")
            {
                return 11; // Puedes implementar lógica para A como 1 o 11 según sea necesario
            }
            else
            {
                return 10; // J, Q, K valen 10
            }
        }
    }
}
