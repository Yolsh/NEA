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
            Boxes.Add(new Box("b", 2, new Size(300, 200), 150, Color.AliceBlue));
            Boxes.Add(new Box("b", 2, new Size(200, 200), 150, Color.AliceBlue));
            Boxes.Add(new Box("b", 2, new Size(600, 200), 150, Color.AliceBlue));
            Boxes.Add(new Box("b", 2, new Size(100, 200), 150, Color.AliceBlue));
            SortBoxList(Boxes, 0, Boxes.Count()-1);
            foreach (Box b in Boxes)
            {
                Console.WriteLine(b.Size.Width);
            }
            Console.ReadKey();
        }

        private static void Merger(List<Box> NewList, int s, int m, int e)
        {
            if (s != e)
            {

            }

            int SizeL = m - s + 1;
            int SizeR = e - m;

            List<Box> Left = new List<Box>();
            List<Box> Right = new List<Box>();
            for (int x = 0; x < SizeL; x++) Left.Add(NewList[s + x]);
            for (int x = 0; x < SizeR; x++) Right.Add(NewList[m + x + 1]);

            int i = 0, j = 0, pointer = s;
            while (i < Left.Count() && j < Right.Count())
            {
                if (Left[i].Size.Width >= Right[j].Size.Width)
                {
                    NewList[pointer] = Left[i];
                    i++;
                }
                else
                {
                    NewList[pointer] = Right[j];
                    j++;
                }
                pointer++;
            }
            while (i < SizeL)
            {
                NewList[pointer] = Left[i];
                i++;
                pointer++;
            }
            while (j < SizeR)
            {
                NewList[pointer] = Right[j];
                j++;
                pointer++;
            }
        }

        static private void SortBoxList(List<Box> BoxList, int start, int end)
        {
            int midpoint = start + (end - 1) / 2;
            if (start < end)
            {
                SortBoxList(BoxList, start, midpoint);
                SortBoxList(BoxList, midpoint + 1, end);
            }
            Merger(BoxList, start, midpoint, end);
        }
    }
}
