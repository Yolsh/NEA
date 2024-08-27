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
        public static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("Enter a minimum Hallway Width");
                MyGarage = new Garage(40, 20, int.Parse(Console.ReadLine()), 2, 90, 0, 0);
                TestPlace();
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void TestPlace()
        {
            MyGarage
            .AddBoxes("Box1", 2.2, rand.Next(3, 6), rand.Next(3, 6), 1, 1)
            .AddBoxes("Box2", 1.3, rand.Next(3, 6), rand.Next(3, 6), 1, 1)
            .AddBoxes("Box3", 4.5, rand.Next(3, 6), rand.Next(3, 6), 1, 1)
            .AddBoxes("Box4", 0.3, rand.Next(3, 6), rand.Next(3, 6), 1, 1)
            .AddBoxes("Box5", 0.3, rand.Next(3, 6), rand.Next(3, 6), 1, 1)
            .AddBoxes("Box6", 0.3, rand.Next(3, 6), rand.Next(3, 6), 1, 1)
            .AddBoxes("Box7", 0.3, rand.Next(3, 6), rand.Next(3, 6), 1, 1)
            .AddBoxes("Box8", 0.3, rand.Next(3, 6), rand.Next(3, 6), 1, 1)
            .AddBoxes("Box9", 6.67, rand.Next(3, 6), rand.Next(3, 6), 1, 1);
            Console.Clear();
            MyGarage.Draw();
            Console.ReadKey();
            MyGarage.Organise();
            MyGarage.Draw();
        }
    }
}

/*
 * error handling for overflowing boxes
 * maybe better explain the problem.
 */