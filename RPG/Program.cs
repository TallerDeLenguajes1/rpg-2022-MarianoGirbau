using RPG;
namespace MyProgram {
    public class Program
    {
        public static void Main()
        {   
            MostrarHistorialGanadores();

            int cantidadParticipantes=4;
            List<Personaje> Participantes = new List<Personaje>();
            //Carga de Personajes
            Console.WriteLine("\n##### Participantes #####");
            for (int i = 0; i < cantidadParticipantes; i++)
            {
                Personaje personaje = new Personaje();
                personaje.creacionAleatoria();
                Participantes.Add(personaje);
                personaje.mostrarPersonaje();
                Console.WriteLine("####################");
            }

            //Peleas
            Console.WriteLine("\n##### Batallas #####");
            do
            {
                List<Personaje> Ganadores = new List<Personaje>();
                for (int j = 0; j <= (Participantes.Count)/2; j=j+2) //Batallas de a pares
                {   
                    Personaje Ganador = Batalla(Participantes.ElementAt(j), Participantes.ElementAt(j + 1));
                    Ganador.Descansar(); //recupera vida y gana nivel
                    Ganadores.Add(Ganador);
                }
                Participantes.RemoveAll(x => !(Ganadores.Contains(x)));
            } while (Participantes.Count>1);

            Console.WriteLine("\nEl ganador del torneo es:");
            var ganador = Participantes[0];
            Console.WriteLine($"{ganador.Apodo} {ganador.Nombre} !!!\n");
            PresionarTecla();
            Console.WriteLine("###### Stats #####");
            ganador.mostrarPersonaje();

            //Guardado de ganador
            string path = Directory.GetCurrentDirectory();
            string nombreArchivo = path + "/Ganadores.csv"; //donde se guardan los archivos
            string datosGanador = $"{ganador.Apodo};{ganador.Nombre};{ganador.Nivel};{ganador.BatallasGanadas}%TAB;{DateTime.Today.ToShortDateString()}";
            HelperDeArchivos.GuardarArchivoCsv(nombreArchivo,datosGanador);
        }

        /******************* Batalla *********************/
        static Personaje Batalla(Personaje PJ1,Personaje PJ2)
        {   
            Console.WriteLine($"PELEAN: {PJ1.Apodo} {PJ1.Nombre} vs {PJ2.Apodo} {PJ2.Nombre}!!!");
            Console.WriteLine($"Suerte a ambos contricantes\n");
            int MDP = 50000;
            Random rnd = new Random();
            for (int i = 1; i < 3 && PJ1.Salud>=0 && PJ2.Salud>=0; i++)
            {
                //Stats PJ1
                float PoderDeDisparo1 = PJ1.Destreza * PJ1.Fuerza * PJ1.Nivel;
                int EfectividadDeDisparo1 = rnd.Next(1, 101);
                float ValorDeAtaque1 = PoderDeDisparo1 * EfectividadDeDisparo1;
                float PoderDeDefensa1 = PJ1.Armadura * PJ1.Velocidad;
                //Stats PJ2
                float PoderDeDisparo2 = PJ2.Destreza * PJ2.Fuerza * PJ2.Nivel;
                int EfectividadDeDisparo2 = rnd.Next(1, 101);
                float ValorDeAtaque2 = PoderDeDisparo2 * EfectividadDeDisparo2;
                float PoderDeDefensa2 = PJ2.Armadura * PJ2.Velocidad;

                if (PJ2.Salud >= 0 && PJ1.Salud>= 0) //Para que no pegue si esta muerto
                {
                    float DA1 = (((ValorDeAtaque1 * EfectividadDeDisparo1) - PoderDeDefensa2) / MDP) * 10f;
                    PJ2.Salud = (int)(PJ2.Salud - DA1);
                    if (DA1 > 0) 
                    {
                        if (DA1 >= 60)
                        {
                            Console.Write("Golpe crítico! ");
                        }
                        Console.WriteLine($"{PJ2.Apodo} {PJ2.Nombre} pierde {DA1} PV.");
                        if (PJ2.Salud <= 0)
                        {
                            Console.WriteLine($"{PJ2.Apodo} {PJ2.Nombre} no puede continuar.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{PJ2.Apodo} {PJ2.Nombre} esquivó el golpe.");
                    }
                }

                PresionarTecla();

                if (PJ1.Salud >= 0 && PJ2.Salud >= 0) //Para que no pegue si esta muerto
                {
                    float DA2 = (((ValorDeAtaque2 * EfectividadDeDisparo2) - PoderDeDefensa1) / MDP) * 10f;
                    PJ1.Salud = (int)(PJ1.Salud - DA2);
                    if (DA2 > 0)
                    {
                        if (DA2 >= 60)
                        {
                            Console.Write("Golpe crítico! ");
                        }
                        Console.WriteLine($"{PJ1.Apodo} {PJ1.Nombre} pierde {DA2} PV.");
                        if (PJ1.Salud <= 0)
                        {
                            Console.WriteLine($"{PJ1.Apodo} {PJ1.Nombre} no puede continuar.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{PJ1.Apodo} {PJ1.Nombre} esquivó el golpe.");
                    }
                }

                PresionarTecla();
            }

            //Ver quien quedó con menos vida
            if (PJ1.Salud > PJ2.Salud)
            {
                Console.WriteLine($"El ganador es {PJ1.Apodo} {PJ1.Nombre}.");
                Console.WriteLine("####################");
                PresionarTecla();
                return PJ1;
            }else if (PJ1.Salud < PJ2.Salud)
            {
                Console.WriteLine($"El ganador es {PJ2.Apodo} {PJ2.Nombre}.");
                Console.WriteLine("####################");
                PresionarTecla();
                return PJ2;
            }else
            {
                Console.WriteLine($"Es un empate, gana el que tenga mejor suerte:");
                PresionarTecla();
                int SuertePJ1 = PJ1.TirarDodecaedro();
                Console.WriteLine($"{PJ1.Apodo} {PJ1.Nombre} saco un {SuertePJ1}.");
                PresionarTecla();
                int SuertePJ2 = PJ2.TirarDodecaedro();
                Console.WriteLine($"{PJ2.Apodo} {PJ2.Nombre} saco un {SuertePJ2}.");
                PresionarTecla();
                if (SuertePJ1>SuertePJ2)
                {
                    Console.WriteLine($"El ganador es {PJ1.Apodo} {PJ1.Nombre}.");
                    Console.WriteLine("####################");
                    PresionarTecla();
                    return PJ1;
                }else
                {
                    Console.WriteLine($"El ganador es {PJ2.Apodo} {PJ2.Nombre}.");
                    Console.WriteLine("####################");
                    PresionarTecla();
                    return PJ2;
                }
            }
        }

        static void PresionarTecla()
            {
                Console.ReadKey(true);
            }

        /******************* Historial *********************/
        static void MostrarHistorialGanadores()
        {
            string opcion;
            if (File.Exists("ganadores.csv"))
            {
                do
                {
                    Console.WriteLine("Ingrese una opción:");
                    Console.WriteLine("\t[1] Ver historial de ganadores");
                    Console.WriteLine("\t[2] Jugar");
                    Console.Write("Esperando entrada: ");
                    opcion = Console.ReadLine();
                } while (opcion != "1" && opcion != "2");
            }
            else
            {
                opcion = "2";
            }
            if (opcion == "1"){  
                Console.WriteLine("###### HISTORIAL DE GANADORES ######");
                Console.WriteLine("Nombre\t\t|Apodo\t\t|Nivel\t|Bat. Ganadas\t|Fecha");
                string TextoAMostrar = HelperDeArchivos.AbrirArchivoCsv("ganadores.csv");
                TextoAMostrar = TextoAMostrar.Replace(";", "\t|");
                Console.WriteLine(TextoAMostrar.Replace("%TAB", "\t"));
                PresionarTecla();
            }
        }
    }
}