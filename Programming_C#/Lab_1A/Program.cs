using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1A
{
    public class Cars
    {
        protected int id;
        public int Id { get { return id; } set { id = value; } }
        protected string surname;
        public string Surname { get { return surname; } set { surname = value; } }
        protected int number;
        public int Number { get { return number; } set { number = value; } }

        protected string brand;
        public string Brand { get { return brand; } set { brand = value; } }
        protected int price;
        public int Price { get { return price; } set { price = value; } }

        protected string adress;
        public string Adress { get { return adress; } set { adress = value; } }


        public Cars(int id, string surname, int number, string brand, int price, string adress)
        {
            this.id = id;
            this.surname = surname;
            this.number = number;
            this.brand = brand;
            this.price = price;
            this.adress = adress;

        }
        public override string ToString()
        {
            return $" Surname: {surname} Number: {number}  Brand: {brand} Price: {price}  Adress: {adress}";
        }
    }
    public interface IListCars
    {
        void Add(Cars cars);
        void Delete(int id);
        void EditPrice(int id, int price);
        void EditAdress(int id, string adress);
        void Show();
    }
    public class ListCar : IListCars
    {
        protected List<Cars> cars;
        public List<Cars> Cars { get { return cars; } set { cars = value; } }
        public ListCar(List<Cars> cars)
        {
            this.cars = cars;
        }
        public void Add(Cars car)
        {
            cars.Add(car);
        }
        public void Delete(int id)
        {
            try
            {
                cars = cars.Where(item => item.Id != id).ToList();
            }
            catch (Exception exexception)
            {
                Console.WriteLine(exexception.Message);
                Console.WriteLine("Something wrong,please check the id.");
            }
        }
        public void EditPrice(int id, int price)
        {
            try
            {
                cars.First(item => item.Id == id).Price = price;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Something wrong,please check the id.");
            }
        }
        public void EditAdress(int id, string adress)
        {
            try
            {
                cars.First(item => item.Id == id).Adress = adress;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Something wrong,please check the id.");
            }
        }
        public void Show()
        {
            foreach (Cars car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            ListCar cars = new ListCar(new List<Cars>
            {
                new Cars(1,"Pavlo", 7644, "Lexus",40000,"Hust"),
                new Cars(2,"Ivan", 4643, "Volvo",50000,"Vinogradov"),
                new Cars(3,"Slava", 3753, "Tesla",300000,"Perechyn"),
                new Cars(4,"Stepan", 6438, "Mercedes-Benz",90000,"Irshava"),
                new Cars(5,"Kostya", 6548, "BMW",50000,"Mukachevo"),
               });
            cars.Show();
            cars.Add(new Cars(5, "Petro", 5495, "Porsche", 43000, "Uzhhorod"));
            cars.Show();
            cars.Delete(3);
            cars.Delete(9);
            cars.Show();
            cars.EditPrice(3, 55000);
            cars.Show();
            cars.EditAdress(5, "Rakhiv");
            cars.Show();
            cars.EditPrice(7, 5000);
            cars.EditAdress(12, "Tyachiv");
            Console.Write("Бренд:  ");
            var brand = Convert.ToString(Console.ReadLine());
            var task = cars.Cars.Where(item => item.Brand == brand);
            var k = 0;

            foreach (var el in task)
            {
                var x = el.Number;
                while (x > 0)
                {
                    if (x % 10 == 7)
                    {
                        k++;
                    }
                    x = x / 10;
                }


            }
            Console.WriteLine("Cars amount: {0}", k);

            var k2 = cars.Cars.GroupBy(group => group.Brand).Select(item => new { item.Key, Value = item.Count() });
            foreach (var num in k2)
            {
                Console.WriteLine($"Brand: {num.Key}, number of cars: {num.Value}");
            }
        }
    }
}