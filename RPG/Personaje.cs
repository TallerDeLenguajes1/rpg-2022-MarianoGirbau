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
        ElfoOscuro
    }


    public class Personaje
    {
        //Datos        
        private TipoDeClase clase;  //clase o raza del personaje
        private string? nombre;      //nombre del personaje
        private string? apodo;       //apodo del personaje
        private DateTime fechadeNacimiento;
        private int edad;           //entre 0 a 300
        private int salud;          //100
        //Stats
        private int nivel;          //1 a 10
        private int velocidad;      // 1 a 10
        private int destreza;       //1 a 5
        private int fuerza;         //1 a 10
        private int armadura;       //1 a 10

       /* public Personaje()
        {
            Nivel = 1;
            Salud = 100;
        }*/

        public TipoDeClase Clase { get => clase; set => clase = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Apodo { get => apodo; set => apodo = value; }
        public DateTime FechadeNacimiento { get => fechadeNacimiento; set => fechadeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }

        //Mostrar personaje
        public void mostrarPersonaje()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Apodo: " + apodo);
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

        //Datos Batalla
        public void Batalla(Personaje PJ2){

            Random rnd = new Random();
            float PoderDeDisparo = Destreza * Fuerza * Nivel;
            int EfectividadDeDisparo = rnd.Next(1,101);
            float ValorDeAtaque = PoderDeDisparo * EfectividadDeDisparo;
            float PoderDeDefensa = Armadura * Velocidad;
            
        }
    }
}
