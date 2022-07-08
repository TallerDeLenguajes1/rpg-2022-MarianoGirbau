using RPG;
namespace MyProgram {
    public class Program
    {
        public static void Main()
        {   
            int cantidadParticipantes=4;
            List<Personaje> Participantes = new List<Personaje>();

            //Carga de Personajes
            Console.WriteLine("\n##### Participantes #####");
            for (int i = 0; i < cantidadParticipantes; i++)
            {
                Personaje personaje = new Personaje();
                personaje = creacionAleatoria();
                Participantes.Add(personaje);
                personaje.mostrarPersonaje();
                Console.WriteLine("####################");
            }

            //Peleas
            Console.WriteLine("\n##### Batallas #####");
            List<Personaje> Ganadores = new List<Personaje>();
            for (int i = 0; i <= (Participantes.Count)/2; i=i+2) //Batallas de a pares
            {   
                Personaje Ganador = Batalla(Participantes.ElementAt(i), Participantes.ElementAt(i + 1));
                Ganadores.Add(Ganador);
            }
            for (int i = 0; i <= (Ganadores.Count)/2; i=i+2)
            {
                List<Personaje> FixtureActual = Ganadores;
                Ganadores.Clear();
            }
        }

        //Creacion aleatoria
        static Personaje creacionAleatoria()
        {
            Personaje personajeAux = new Personaje();
            var rnd = new Random();
            //Eleccion de clase aleatoria
            var Clases = Enum.GetValues(typeof(TipoDeClase));
            TipoDeClase Clase = (TipoDeClase)Clases.GetValue(rnd.Next(Clases.Length)); //Elije aleatoriamente de un enum con las clases
            personajeAux.Clase = Clase;

            //Nivel del personaje
            personajeAux.Nivel = 1;

            //Eleccion de stats aleatorios
            personajeAux.Salud = 100;
            personajeAux.Velocidad = rnd.Next(1, 11);
            personajeAux.Destreza = rnd.Next(1, 6);
            personajeAux.Fuerza = rnd.Next(1, 11);
            personajeAux.Armadura = rnd.Next(1, 11);

            //Eleccion de datos aleatorios
            var Nombres = Enum.GetValues(typeof(NombresEnum));
            NombresEnum Nombre = (NombresEnum)Nombres.GetValue(rnd.Next(Nombres.Length));
            personajeAux.Nombre = Nombre;
            var Apodos = Enum.GetValues(typeof(ApodosEnum));
            ApodosEnum Apodo = (ApodosEnum)Apodos.GetValue(rnd.Next(Apodos.Length));
            personajeAux.Apodo = Apodo;
            //Calculo de edad
            personajeAux.FechadeNacimiento = new DateTime (rnd.Next(1722,2023),rnd.Next(1,13),rnd.Next(1,29));
            DateTime fechaActual= DateTime.Now;
            if (fechaActual.Month >= personajeAux.FechadeNacimiento.Month && fechaActual.Day >= personajeAux.FechadeNacimiento.Day)
            {
                personajeAux.Edad = fechaActual.Year - personajeAux.FechadeNacimiento.Year;
            }
            else
            {
                personajeAux.Edad = (fechaActual.Year - personajeAux.FechadeNacimiento.Year)-1;
            }

            return personajeAux;
        }

        //Datos Batalla
         static Personaje Batalla(Personaje PJ1,Personaje PJ2)
        {   
            Console.WriteLine($"Pelean: {PJ1.Apodo} {PJ1.Nombre} vs {PJ2.Apodo} {PJ2.Nombre}");
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

                if (PJ2.Salud >= 0 && PJ1.Salud>= 0) //Para que no pegue si estan muerto
                {
                    float DA1 = (((ValorDeAtaque1 * EfectividadDeDisparo1) - PoderDeDefensa2) / MDP) * 100;
                    PJ2.Salud = (int)(PJ2.Salud - DA1);
                    if (DA1 > 0) 
                    {
                        if (DA1 >= 60)
                        {
                            Console.Write("Golpe crítico! ");
                        }
                        Console.WriteLine($"{PJ2.Apodo} {PJ2.Nombre} pierde {DA1} ptos. de vida.");
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
                if (PJ1.Salud >= 0 && PJ2.Salud >= 0) //Para que no pegue si estan muerto
                {
                    float DA2 = (((ValorDeAtaque2 * EfectividadDeDisparo2) - PoderDeDefensa1) / MDP) * 100;
                    PJ1.Salud = (int)(PJ1.Salud - DA2);
                    if (DA2 > 0)
                    {
                        if (DA2 >= 60)
                        {
                            Console.Write("Golpe crítico! ");
                        }
                        Console.WriteLine($"{PJ1.Apodo} {PJ1.Nombre} pierde {DA2} ptos. de vida.");
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
            }
            //Ver quien quedó con menos vida
            if (PJ1.Salud > PJ2.Salud)
            {
                Console.WriteLine($"El ganador es {PJ1.Apodo} {PJ1.Nombre}.");
                return PJ1;
            }else if (PJ1.Salud < PJ2.Salud)
            {
                Console.WriteLine($"El ganador es {PJ2.Apodo} {PJ2.Nombre}.");
                return PJ2;
            }else
            {
                Console.WriteLine($"Es un empate, gana el que tenga mejor suerte.");
                int SuertePJ1 = PJ1.TirarDodecaedro();
                int SuertePJ2 = PJ2.TirarDodecaedro();
                if (SuertePJ1>SuertePJ2)
                {
                    Console.WriteLine($"El ganador es {PJ1.Apodo} {PJ1.Nombre}.");
                    return PJ1;
                }else
                {
                    Console.WriteLine($"El ganador es {PJ2.Apodo} {PJ2.Nombre}.");
                    return PJ2;
                }
            }
        }
    }
}