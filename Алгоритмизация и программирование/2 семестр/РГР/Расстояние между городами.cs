// Расстояние между городами

using System;
namespace DistanceBetweenCities
{
    class DistBetweenCities
    {
        public double Lat_1 {  get; set; }
        public double Lat_2 { get; set; }
        public double Long_1 { get; set; }
        public double Long_2 { get; set; }
        public double Radius { get; set; }
        public DistBetweenCities(double Lat_1, double Lat_2, double Long_1, double Long_2, double Radius)
        {
            this.Lat_1 = Lat_1 * Math.PI / 180;
            this.Lat_2 = Lat_2 * Math.PI / 180;
            this.Long_1 = Long_1 * Math.PI / 180;
            this.Long_2 = Long_2 * Math.PI / 180;
            this.Radius = Radius;
        }

        public double HaversineFormula()
        {
            double delta_lat = Lat_2 - Lat_1;
            double delta_lon = Long_2 - Long_1;
            double step_1 = Math.Pow(Math.Sin(delta_lat / 2), 2) + Math.Cos(Lat_1) * Math.Cos(Lat_2) * Math.Pow(Math.Sin(delta_lon / 2), 2);
            return 2 * Radius * Math.Asin(Math.Sqrt(step_1));
        }
    }
    class Programm
    {
        static void Main()
        {
            double latitude_1, latitude_2, longitude_1, longitude_2, radius;

            Console.Write("Введите широту и долготу первого города через пробел: ");
            string[] data = Console.ReadLine().Split();
            latitude_1 = Convert.ToDouble(data[0]);
            longitude_1 = Convert.ToDouble(data[1]);

            Console.Write("Введите широту и долготу второго города через пробел: ");
            data = Console.ReadLine().Split();
            latitude_2 = Convert.ToDouble(data[0]);
            longitude_2 = Convert.ToDouble(data[1]);

            Console.Write("Введите радиус планеты: ");
            radius = Convert.ToDouble(Console.ReadLine());

            DistBetweenCities distance = new DistBetweenCities(latitude_1, latitude_2, longitude_1, longitude_2, radius);
            string result = distance.HaversineFormula().ToString("F3");

            Console.WriteLine($"Минимальное расстояние между городами по поверхности планеты: {result}");
        }
    }
}
