using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class CopyPartArray
    {
        Random rnd = new Random();
        int threadCount;
        int[] array;

        public CopyPartArray(int[] array, int threadCount)
        {
            this.array = array;
            this.threadCount = threadCount;
        }



        public int[] Generate()
        {
            int[] arr = new int[array.Length];
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[i] = new Thread(() => CopyPart(j, arr));
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

        private void CopyPart(int threadIndex, int[] arr)
        {

            int start = arr.Length / threadCount * threadIndex;
            int end = threadIndex == threadCount - 1
                ? arr.Length
                : arr.Length / threadCount * (threadIndex + 1);

            for (int i = start; i < end; i++)
            {
                arr[i] = array[i];
            }
        }
    }
}

