using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Lab_2A
{
    public class Man
    {
        public string name { get; set; }
        public int age { get; set; }
        public string eyes { get; set; }
        public int salary { get; set; }
        public bool apartment { get; set; }



        public Man(string name, int age, string eyes, int salary, bool apartment)
        {
            this.name = name;
            this.age = age;
            this.eyes = eyes;
            this.salary = salary;
            this.apartment = apartment;

        }

        public Man()
        {

        }

        public override string ToString()
        {
            return $"Man: {name}, {age} y.o., {eyes} eyes, salary {salary}$, apartment {apartment}";
        }
    }
    public class Men
    {
        public List<Man> men = new List<Man>();

        public Men()
        {

        }

        public void Add(string name, int age, string eyes, int salary, bool apartment)
        {
            men.Add(new Man(name, age, eyes, salary, apartment));
        }

        public void CreatePO(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Men));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            using (fs)
            {
                serializer.Serialize(fs, this);
            }
        }

        public void ReadPO(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Men));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            using (fs)
            {
                Men obj = (Men)serializer.Deserialize(fs);
                this.men = obj.men;
            }
        }

        public void Delete()
        {
            this.men = this.men.Where(elem => elem.apartment == true).ToList();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"D:\Lab_C#\Programming_C#\Lab_2A\Lab_2A\XMLFile1.xml";

            Men men = new Men();
            men.Add("Pavlo", 23, "blue", 356800, true);
            men.Add("Slava", 26, "green", 85400, true);
            men.Add("Yura", 18, "green", 45853, true);
            men.Add("Artem", 23, "blue", 53783, false);
            men.Add("Denys", 24, "green", 56430, true);
            men.Add("Ivan", 25, "blue", 93653, false);
            men.Add("Stas", 33, "green", 47656, true);
            men.Add("Vyacheslav", 28, "blue", 35436, false);
            men.Add("Kolya", 27, "green", 45893, true);
            men.Add("Dima", 19, "blue", 48393, false);
            men.CreatePO(fileName);

            Men men2 = new Men();
            men2.ReadPO(fileName);


            foreach (Man man in men2.men)
            {
                Console.WriteLine(man.ToString());
            }

            men2.Delete();

            foreach (Man man in men2.men)
            {
                Console.WriteLine(man.ToString());
            }
            Console.WriteLine();

            var task = men.men
                .GroupBy(group => $"{group.age}")
                .Select(item => new { item.Key, Value = item.Count() });

            foreach (var item in task)
            {
                Console.WriteLine($"Age: {item.Key}, number of men: {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
