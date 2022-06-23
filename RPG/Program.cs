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
            for (int i = 1; i < cantidadParticipantes; i++)
            {
                Personaje personaje = new Personaje();
                personaje = creacionAleatoria();
                Participantes.Add(personaje);
                personaje.mostrarPersonaje();
                Console.WriteLine("####################");
            }

            //Peleas
            Console.WriteLine("\n##### Batallas #####");
            for (int i = 1; i < (Participantes.Count)/2; i++)
            {
                
            }
        }

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
            personajeAux.Nombre = "";
            personajeAux.Apodo = "";
            personajeAux.FechadeNacimiento = new DateTime (rnd.Next(1722,2023),rnd.Next(1,13),rnd.Next(1,29));
            personajeAux.Edad= 1 ; //Usar funcion de tp anterior

            return personajeAux;
        }

  

    }
}