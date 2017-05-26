using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class ArrayGenerator
    {
        int threadCount, count;


        public ArrayGenerator(int count, int threadCount)
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
}
