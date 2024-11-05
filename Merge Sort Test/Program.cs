using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;

namespace Merge_Sort_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> Boxes = new List<Box>();
            Boxes.Add(new Box("b", 2, new Size(200, 200), 150, Color.AliceBlue));
            Boxes.Add(new Box("b", 2, new Size(300, 200), 150, Color.AliceBlue));
            Boxes.Add(new Box("b", 2, new Size(70, 50), 150, Color.AliceBlue));
            Boxes.Add(new Box("b", 2, new Size(350, 120), 150, Color.AliceBlue));
            Boxes.Add(new Box("b", 2, new Size(400, 120), 150, Color.AliceBlue));
            Boxes.Add(new Box("b", 2, new Size(110, 275), 150, Color.AliceBlue));
            foreach (Box b in Boxes)
            {
                Console.Write($"{b.Size.Width * b.Size.Height}, ");
            }
            SortBoxList(Boxes, 0, Boxes.Count()-1);
            Console.WriteLine();
            foreach (Box b in Boxes)
            {
                Console.Write($"({b.Size.Width}, {b.Size.Height}) => {b.Size.Width * b.Size.Height}, ");
            }
            Console.ReadKey();
        }

        private static void Merger(List<Box> NewList, int s, int m, int e)
        {
            int LSize = m - s + 1;
            int RSize = e - m;

            Box[] Left = new Box[LSize];
            Box[] Right = new Box[RSize];

            for (int i = 0; i < LSize; i++) Left[i] = NewList[s + i];
            for (int i = 0; i < RSize; i++) Right[i] = NewList[m + i + 1];

            int L = 0, R = 0, pointer = s;
            while (L < Left.Length && R < Right.Length)
            {
                if (Left[L].Size.Width <= Right[R].Size.Width)
                {
                    NewList[pointer] = Right[R];
                    R++; 
                }
                else
                {
                    NewList[pointer] = Left[L];
                    L++;
                }
                pointer++;
            }

            while (L < LSize)
            {
                NewList[pointer] = Left[L];
                L++;
                pointer++;
            }
            while (R < RSize)
            {
                NewList[pointer] = Right[R];
                R++;
                pointer++;
            }
        }

        static private void SortBoxList(List<Box> BoxList, int start, int end)
        {
            int midpoint = (int)Math.Ceiling(((double)start + (end - 1)) / 2);
            if (start < end)
            {
                SortBoxList(BoxList, start, midpoint);
                SortBoxList(BoxList, midpoint+1, end);
            }
            Merger(BoxList, start, midpoint, end);
        }
    }
}
