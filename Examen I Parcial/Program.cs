using System;

namespace Examen
{
    class Alumno
    {
        public string NombreAlumno { get; set; }
        public string NumeroCuenta { get; set; }
        public string Email { get; set; }
    }

    class Asignatura : Alumno, IAsignatura
    {
        public int N1 { get; set; }
        public int N2 { get; set; }
        public int N3 { get; set; }
        public string NombreAsignatura { get; set; }
        public string Horario { get; set; }
        public string NombreDocente { get; set; }

        public double CalcularNotaFinal()
        {
            return (N1 + N2 + N3) / 3.0;
        }

        public double CalcularNotaFinal(int n1, int n2, int n3)
        {
            return (n1 + n2 + n3) / 3.0;
        }

        public string MensajeNotaFinal(double notaFinal)
        {
            if (notaFinal >= 0 && notaFinal <= 59)
                return "Reprobado";
            else if (notaFinal >= 60 && notaFinal <= 79)
                return "Bueno";
            else if (notaFinal >= 80 && notaFinal <= 89)
                return "Muy Bueno";
            else if (notaFinal >= 90 && notaFinal <= 100)
                return "Sobresaliente";
            else
                return "Nota inválida";
        }

        public void Imprimir()
        {
            Console.WriteLine("Datos del Alumno:");
            Console.WriteLine($"Nombre: {NombreAlumno}");
            Console.WriteLine($"Número de Cuenta: {NumeroCuenta}");
            Console.WriteLine($"Email: {Email}");

            Console.WriteLine("Datos de la Asignatura:");
            Console.WriteLine($"Nombre: {NombreAsignatura}");
            Console.WriteLine($"Horario: {Horario}");
            Console.WriteLine($"Nombre del Docente: {NombreDocente}");

            double notaFinal = CalcularNotaFinal();
            Console.WriteLine($"Nota Final: {notaFinal} ({MensajeNotaFinal(notaFinal)})");

            Console.WriteLine("Nota Final con parámetros:");
            Console.WriteLine($"Nota Final: {CalcularNotaFinal(N1, N2, N3)} ({MensajeNotaFinal(CalcularNotaFinal(N1, N2, N3))})");
        }
    }

    interface IAsignatura
    {
        double CalcularNotaFinal();
        double CalcularNotaFinal(int n1, int n2, int n3);
        string MensajeNotaFinal(double notaFinal);
        void Imprimir();
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Ingrese el nombre del alumno: ");
                string nombreAlumno = Console.ReadLine();

                Console.Write("Ingrese el número de cuenta del alumno: ");
                string numeroCuenta = Console.ReadLine();

                Console.Write("Ingrese el email del alumno: ");
                string email = Console.ReadLine();

                Console.Write("Ingrese el nombre de la asignatura: ");
                string nombreAsignatura = Console.ReadLine();

                Console.Write("Ingrese el horario de la asignatura: ");
                string horario = Console.ReadLine();

                Console.Write("Ingrese el nombre del docente: ");
                string nombreDocente = Console.ReadLine();

                Console.Write("Ingrese la nota del primer parcial: ");
                int n1 = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la nota del segundo parcial: ");
                int n2 = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la nota del tercer parcial: ");
                int n3 = int.Parse(Console.ReadLine());

                if (n1 > 30 || n2 > 30 || n3 > 40)
                {
                    Console.WriteLine("Nota inválida. Las notas deben ser menores o iguales a 30 para el primer y segundo parcial, y menor o igual a 40 para el tercer parcial.");
                    return;
                }

                Asignatura asignatura = new Asignatura
                {
                    NombreAlumno = nombreAlumno,
                    NumeroCuenta = numeroCuenta,
                    Email = email,
                    NombreAsignatura = nombreAsignatura,
                    Horario = horario,
                    NombreDocente = nombreDocente,
                    N1 = n1,
                    N2 = n2,
                    N3 = n3
                };

                asignatura.Imprimir();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}