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
        static void Main(string[] args)
        {
            TestDraw();
            Console.ReadKey();
        }

        static void TestDraw()
        {
            Garage MyGarage = new Garage(20, 10);
            MyGarage
                .AddBoxes("bob", 2.2, rand.Next(1, 8), rand.Next(1, 4), rand.Next(0, 20), rand.Next(0, 10))
                .AddBoxes("jeff", 2.2, rand.Next(1, 8), rand.Next(1, 4), rand.Next(0, 20), rand.Next(0, 10))
                .AddBoxes("ed", 2.2, rand.Next(1, 8), rand.Next(1, 4), rand.Next(0, 20), rand.Next(0, 10))
                .AddBoxes("Joe", 2.2, rand.Next(1, 8), rand.Next(1, 4), rand.Next(0, 20), rand.Next(0, 10));
            MyGarage.Draw();
        }
    }
}
