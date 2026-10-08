Console.WriteLine("SISTEMA DE MONITOREO DE TEMPERATURA DE MOTOR");
Console.WriteLine();

Termorregulador motorMonitoreo = new Termorregulador();// se toma la clase Termorregulador y se crea un objeto llamado motorMonitoreo

for (int i = 1; i <= 5; i++)// se hace un bucle para ingresar 5 lecturas de temperatura
{
    Console.Write($"Ingrese la lectura de temperatura #{i} (°C): ");// se solicita al usuario que ingrese la temperatura
    double temp = Convert.ToDouble(Console.ReadLine());

    motorMonitoreo.SumaTemperaturas += temp;// se suma la temperatura ingresada a la propiedad SumaTemperaturas del objeto motorMonitoreo
    motorMonitoreo.Contador++;// se incrementa el contador de lecturas ingresadas
}

double promedio = motorMonitoreo.CalcularPromedio();// se calcula el promedio de las temperaturas ingresadas

Console.WriteLine();
Console.WriteLine($"Promedio de temperatura: {promedio:F2} °C");//  se muestra el promedio de temperatura con 2 decimales
Console.WriteLine($"Estado del motor: {motorMonitoreo.ObtenerEstado()}");// se muestra el estado del motor según el promedio de temperatura

class Termorregulador// se crea la clase Termorregulador
{
    public double SumaTemperaturas { get; set; } = 0;// se crea la propiedad SumaTemperaturas para almacenar la suma de las temperaturas ingresadas
    public int Contador { get; set; } = 0;// se crea la propiedad Contador para almacenar la cantidad de lecturas ingresadas

    public double CalcularPromedio()// se crea el método CalcularPromedio para calcular el promedio de las temperaturas ingresadas
    {
        if (Contador == 0) return 0;// se verifica que el contador no sea cero para evitar división por cero
        return SumaTemperaturas / Contador;
    }

    public string ObtenerEstado()// se crea el método ObtenerEstado para determinar el estado del motor según el promedio de temperatura
    {
        double promedio = CalcularPromedio();// se calcula el promedio de las temperaturas ingresadas
        if (promedio <= 70)
            return "NORMAL";// se retorna "NORMAL" si el promedio es menor o igual a 70
        else
            return "ALERTA DE TEMPERATURA";// se retorna "ALERTA DE TEMPERATURA" si el promedio es mayor a 70
    }
}