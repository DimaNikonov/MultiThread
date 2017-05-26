using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class FindeMax
    {
        int threadCount;
        List<double> array;

        public FindeMax(List<double> array, int threadCount)
        {
            this.array = array;
            this.threadCount = threadCount;
        }

        public double Generate()
        {
            Thread[] threads = new Thread[threadCount];
            double[] arr = new double[threads.Length];

            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[i] = new Thread(() => MaxFind(j, arr));
            }

            foreach (var item in threads)
            {
                item.Start();
            }

            foreach (var item in threads)
            {
                item.Join();
            }

            return arr.Max();
        }

        private void MaxFind(int threadIndex, double[] arr)
        {
            int start = array.Count / threadCount * threadIndex;
            int end = Math.Min(array.Count, array.Count / threadCount * (threadIndex + 1));

            arr[threadIndex] = array.GetRange(start, end - start).Max();

        }
    }
}
