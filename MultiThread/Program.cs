using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace MultiThread
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //int[] temp, temp1;
            //Random rnd = new Random();
            //var sw = Stopwatch.StartNew();
            //sw.Start();
            //int[] array = new int[5000000];
            //temp1 = new int[array.Length];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = rnd.Next(0, 25);
            //}
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //sw = Stopwatch.StartNew();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    temp1[i] = array[i];
            //}
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);

            //sw = Stopwatch.StartNew();
            //ArrayGeneratorSin generator = new ArrayGeneratorSin(5000000, 3);
            //temp=generator.Generate();
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //Console.WriteLine(temp.Count(x => x == 0));

            //File.WriteAllText("test.txt", string.Join(" ", temp));

            //Console.ReadLine();          

            //sw = Stopwatch.StartNew();
            //CopyPartArray copyPart= new CopyPartArray(array,2);
            //temp=copyPart.Generate();
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //Console.ReadLine();

            double[] arr = new double [20]{20,15,6,8,165,165,1,64,1641,16,16,61,639,34,12,15684,1568,13,111,9};
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine( sum / arr.Length);
            LinkedList<int> ll = new LinkedList<int>();
            


            FindeMin fm = new FindeMin(arr.ToList(), 3);
            double min = fm.Generate();
            Console.WriteLine(min);



            FindeMax fmax = new FindeMax(arr.ToList(), 4);
            double max = fmax.Generate();
            Console.WriteLine(max);

            FindeAverage fAverage = new FindeAverage(arr.ToList(), 5);
            double average = fAverage.Generate();
            Console.WriteLine(average);
            Console.ReadLine();

            string s;

            s = File.ReadAllText("Text.txt");

            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var item in s)
            {
                if (dict.Keys.Contains(item))
                {
                    dict[item]++;
                }
                else
                    dict.Add(item, 1);
            }
            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }
        }
    }
}
