using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace MultiThread
{
    class ArrayGenerator
    {
        int threadCount, count;
        

        public ArrayGenerator (int threadCount, int count)
        {
            this.count = count;
            this.threadCount = threadCount;
        }

        

        public int[] Generate()
        {
            int[] arr = new int[count];
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[j] = new Thread(() => GenerateInternal(j, arr));
            }

            foreach (var item in threads)
            {
                item.Start();
            }

            foreach (var item in threads)
            {
                item.Join();
            }

            return arr;
            
        }

        private void GenerateInternal(int threadIndex, int[] arr)
        {
            Random rnd = new Random();
            int start = arr.Length / threadCount * threadIndex;
            int end = threadIndex == threadCount - 1 
                ? arr.Length 
                : arr.Length / threadCount * (threadIndex + 1);

            for (int i = start; i < end; i++)
            {
                arr[i] = rnd.Next(0, 25);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int[] temp;
            //Random rnd = new Random();
            //var sw = Stopwatch.StartNew();
            //sw.Start();
            //int[] array = new int[5000000];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = rnd.Next(0, 100);
            //}
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //var sw = Stopwatch.StartNew();
            //sw = Stopwatch.StartNew();
            ArrayGenerator generator = new ArrayGenerator(5000000, 3);
            generator.Generate();
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(generator.Generate().Count(x => x == 0));
            
            File.WriteAllText("test.txt", string.Join(" ", generator.Generate()));

            Console.ReadLine();
        }
    }
}
