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
            MyGarage = new Garage(20, 10, int.Parse(Console.ReadLine()), 2, 90, 0, 0);
            TestPlace();
            Console.ReadKey();
        }

        static void TestPlace()
        {
            MyGarage
            .AddBoxes("Box1", 2.2, 3, 3, 2, 2)
            .AddBoxes("Box2", 1.3, 3, 3, 2, 2)
            .AddBoxes("Box3", 4.5, 1, 1, 2, 2)
            .AddBoxes("Box4", 0.3, 2, 2, 2, 2)
            .AddBoxes("Box5", 6.67, 5, 5, 2, 2);
            Console.Clear();
            MyGarage.Draw();
            Console.ReadKey();
            MyGarage.Organise();
            MyGarage.Draw();
        }
    }
}
