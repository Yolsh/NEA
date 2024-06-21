using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        public static Random rand = new Random();
        public static Garage MyGarage;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a minimum Hallway Width");
            MyGarage = new Garage(20, 10, int.Parse(Console.ReadLine()));
            TestPlace();
            Console.ReadKey();
        }

        static void TestPlace()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Give the box a name");
                string name = Console.ReadLine();
                Console.WriteLine("What is the boxes weight");
                double weight = double.Parse(Console.ReadLine());
                Console.WriteLine("Whats its Length");
                int Length = int.Parse(Console.ReadLine());
                Console.WriteLine("Whats its Width");
                int Width = int.Parse(Console.ReadLine());
                Console.WriteLine("X Coordinate");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Y Coordinate");
                int y = int.Parse(Console.ReadLine());

                MyGarage
                .AddBoxes(name, weight, Length, Width, x, y);
                Console.Clear();
                MyGarage.Draw();
                Console.ReadKey();
            }
        }
    }
}
