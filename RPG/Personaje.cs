using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public enum TipoDeClase
    {
        Orco,
        Humano,
        Enano,
        Elfo,
        ElfoOscuro,
        Demonio
    }

    public enum NombresEnum
    {
        Fulchard,
        Taffy,
        Serle,
        Gylbart,
        Louve
        
    }

    public enum ApodosEnum
    {
        Sir,
        Admiral,
        Cardinal,
        Prince,
        Count 
    }

    public class Personaje
    {
        //Datos        
        private TipoDeClase clase;  //clase o raza del personaje
        private NombresEnum nombre;      //nombre del personaje
        private ApodosEnum apodo;       //apodo del personaje
        private DateTime fechadeNacimiento;
        private int edad;           //entre 0 a 300
        private int salud;          //100

        //Stats
        private int nivel;          //1 a 10
        private int velocidad;      // 1 a 10
        private int destreza;       //1 a 5
        private int fuerza;         //1 a 10
        private int armadura;       //1 a 10
        private int batallasganadas = 0;  //batallas ganadas


        public TipoDeClase Clase { get => clase; set => clase = value; }
        public NombresEnum Nombre { get => nombre; set => nombre = value; }
        public ApodosEnum Apodo { get => apodo; set => apodo = value; }
        public DateTime FechadeNacimiento { get => fechadeNacimiento; set => fechadeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int BatallasGanadas { get => batallasganadas; set => batallasganadas = value; }


         /******************Creacion aleatoria*********************/
        public void creacionAleatoria()
        {
            var rnd = new Random();
            //Eleccion de clase aleatoria
            var Clases = Enum.GetValues(typeof(TipoDeClase));
            TipoDeClase Clase = (TipoDeClase)Clases.GetValue(rnd.Next(Clases.Length)); //Elije aleatoriamente de un enum con las clases
            this.Clase=Clase;

            //Nivel del personaje
            Nivel = 1;

            //Eleccion de stats aleatorios
            Salud = 100;
            Velocidad = rnd.Next(1, 11);
            Destreza = rnd.Next(1, 6);
            Fuerza = rnd.Next(1, 11);
            Armadura = rnd.Next(1, 11);

            //Eleccion de datos aleatorios
            var Nombres = Enum.GetValues(typeof(NombresEnum));
            NombresEnum Nombre = (NombresEnum)Nombres.GetValue(rnd.Next(Nombres.Length));
            this.Nombre = Nombre;
            var Apodos = Enum.GetValues(typeof(ApodosEnum));
            ApodosEnum Apodo = (ApodosEnum)Apodos.GetValue(rnd.Next(Apodos.Length));
            this.Apodo = Apodo;
            //Calculo de edad
            FechadeNacimiento = new DateTime (rnd.Next(1722,2023),rnd.Next(1,13),rnd.Next(1,29));
            DateTime fechaActual= DateTime.Now;
            if (fechaActual.Month >= FechadeNacimiento.Month && fechaActual.Day >= FechadeNacimiento.Day)
            {
                Edad = fechaActual.Year - FechadeNacimiento.Year;
            }
            else
            {
                Edad = (fechaActual.Year - FechadeNacimiento.Year)-1;
            }
        }

        //Mostrar personaje
        public void mostrarPersonaje()
        {
            Console.WriteLine("Apodo: " + apodo);
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Nivel: " + nivel);
            Console.WriteLine("Fecha de Nacimiento: " + (fechadeNacimiento).ToShortDateString());
            Console.WriteLine("Edad: " + edad);
            Console.WriteLine("Clase: " + clase.ToString());
            Console.WriteLine("Salud: " + salud);
            Console.WriteLine("Velocidad: " + velocidad);
            Console.WriteLine("Destreza: " + destreza);
            Console.WriteLine("Fuerza: " + fuerza);
            Console.WriteLine("Armadura: " + armadura);
        } 
        
         public void Descansar()
            {
                if (Salud < 85)
                {
                    Salud += 15;
                }
                else
                {
                    Salud = 100;
                }
                if (Nivel < 10)
                {
                    Nivel++;
                    
                }
                BatallasGanadas++;
            }

         public int TirarDodecaedro()
        {
            Random rnd = new Random();
            return (rnd.Next(1, 13));
        }

    }
}
