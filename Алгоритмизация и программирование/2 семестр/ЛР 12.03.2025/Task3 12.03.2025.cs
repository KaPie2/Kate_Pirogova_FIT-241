//Класс машины, в котором будет описана машина (марка, фио владельца, год выпуска и помыта или не помыта (bool)).
//Класс гараж, который будет хранить список объектов типа машина. Класс мойка, у которого будет только один метод – помыть машину.
//С использованием делегата необходимо каждую машину в гараже помыть, если она не помыта


using System;
using System.Runtime.ConstrainedExecution;
using System.Timers;

namespace Task3
{
    public class Car
    {
        public string Brand { get; set; }
        public string Owner_name { get; set; }
        public int Year { get; set; }
        public bool Is_clean { get; set; }

        public Car(string Brand, string Owner_name, int Year, bool Is_clean)
        {
            this.Brand = Brand;
            this.Owner_name = Owner_name;
            this.Year = Year;
            this.Is_clean = Is_clean;
        }
    }

    public class Garage
    {
        public List<Car> Cars { get; set; } = new List<Car>();

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }

    }

    public class CarWash
    {
        public delegate void WashCarDelegate(Car car);
        public void WashCar(Car car)
        {
            if (!car.Is_clean)
            {
                Console.WriteLine($"\nМоем машину: {car.Brand}");
                car.Is_clean = true;
                Console.WriteLine($"Машина {car.Brand} теперь чистая!");
            }
            else
            {
                Console.WriteLine($"\nМашина {car.Brand} уже чистая!");
            }
        }

        public void WashAllCars(Garage garage)
        {
            WashCarDelegate washDelegate = WashCar;
            foreach (var car in garage.Cars)
            {
                washDelegate(car);
            }
        }
    }

    class Programm
    {
        static void Main()
        {
            Garage garage = new Garage();

            Console.Write("Введите кол-во машин: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write("\nВведите марку автомобиля: ");
                string brand = Console.ReadLine();
                Console.Write("Введите ФИО владельца: ");
                string name = Console.ReadLine();
                Console.Write("Введите год выпуска: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Помыта ли машина? (Введите \"да\" или \"нет\"): ");
                string data = Console.ReadLine();
                bool is_clean = false;
                if (data == "да") is_clean = true;

                Car car = new Car(brand, name, year, is_clean);
                garage.AddCar(car);
            }

            CarWash carWash = new CarWash();

            carWash.WashAllCars(garage);
        }
    }
}
