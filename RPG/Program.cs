using RPG;
namespace MyProgram {
    public class Program
    {
        public static void Main()
        {   
            int cantidadParticipantes=4;
            List<Personaje> Participantes = new List<Personaje>();

            //Carga de Personajes
            for (int i = 1; i < cantidadParticipantes; i++)
            {
                Personaje personaje = new Personaje();
                personaje = creacionAleatoria();
                Participantes.Add(personaje);
                mostrarPersonaje(personaje);
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

        static void mostrarPersonaje(Personaje PJ)
        {
            Console.WriteLine("Nombre: " + PJ.Nombre);
            Console.WriteLine("Apodo: " + PJ.Apodo);
            Console.WriteLine("Nivel: " + PJ.Nivel);
            Console.WriteLine("Fecha de Nacimiento: " + (PJ.FechadeNacimiento).ToShortDateString());
            Console.WriteLine("Edad: " + PJ.Edad);
            Console.WriteLine("Clase: " + PJ.Clase.ToString());
            Console.WriteLine("Salud: " + PJ.Salud);
            Console.WriteLine("Velocidad: " + PJ.Velocidad);
            Console.WriteLine("Destreza: " + PJ.Destreza);
            Console.WriteLine("Fuerza: " + PJ.Fuerza);
            Console.WriteLine("Armadura: " + PJ.Armadura);
        } 

    }
}