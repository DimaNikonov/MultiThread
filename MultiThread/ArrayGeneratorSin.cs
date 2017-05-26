using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class ArrayGeneratorSin
    {

        int threadCount, count;


        public ArrayGeneratorSin(int count, int threadCount)
        {
            this.count = count;
            this.threadCount = threadCount;
        }



        public double[] Generate()
        {
            double [] arr = new double[count];
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[i] = new Thread(() => GenerateInternal(j, arr));
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

        private void GenerateInternal(int threadIndex, double[] arr)
        {
            Random rnd = new Random();
            int start = arr.Length / threadCount * threadIndex;
            int end = threadIndex == threadCount - 1
                ? arr.Length
                : arr.Length / threadCount * (threadIndex + 1);

            for (int i = start; i < end; i++)
            {
                double j = i;
                arr[i] = Math.Sin(i);
            }
        }
    }
}

