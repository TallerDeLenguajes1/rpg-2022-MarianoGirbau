using RPG;
namespace MyProgram {
    public class Program
    {
        public static void Main()
        {
            Personaje[] Participantes = new Personaje[4];
            Personaje personaje = new Personaje();
            personaje = creacionAleatoria();

            Console.WriteLine("Clase: " + personaje.Clase.ToString());


        }

        static Personaje creacionAleatoria()
        {
            Personaje personajeAux = new Personaje();
            //Eleccion de clase aleatoria
            var Clases = Enum.GetValues(typeof(TipoDeClase));
            var rnd = new Random();
            TipoDeClase Clase = (TipoDeClase)Clases.GetValue(rnd.Next(Clases.Length)); //Elije aleatoriamente de un enum con las clases
            personajeAux.Clase = Clase;

            //Nivel del personaje
            personajeAux.Nivel = 1;

            //Eleccion de stats aleatorios
            personajeAux.Salud = 100;
            personajeAux.Armadura = rnd.Next(1, 10);
            personajeAux.Destreza = rnd.Next(1, 10);
            personajeAux.Fuerza = rnd.Next(1, 10);
            personajeAux.Velocidad = rnd.Next(1, 10);
            personajeAux.Nombre = "";
            personajeAux.Apodo = "";
            

            return personajeAux;
        }

    }
}