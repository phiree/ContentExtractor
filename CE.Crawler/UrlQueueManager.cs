using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Crawler
{
    public enum FrontierQueuePriority
    {
        Low,
        BelowNormal,
        Normal,
        AboveNormal,
        High,
    }

    public class UrlQueueManager
    {
        private Queue<string> lowQueue = new Queue<string>();
        private Queue<string> belowQueue = new Queue<string>();
        private Queue<string> normalQueue = new Queue<string>();
        private Queue<string> aboveQueue = new Queue<string>();
        private Queue<string> highQueue = new Queue<string>();

        public int Count
        {
            get
            {
                int count = 0;
                count = lowQueue.Count
                    + belowQueue.Count
                    + normalQueue.Count
                    + aboveQueue.Count
                    + highQueue.Count;
                return count;
            }

        }

        public void Clear()
        {
            lowQueue.Clear();
            belowQueue.Clear();
            normalQueue.Clear();
            aboveQueue.Clear();
            highQueue.Clear();
        }

        public void Enqueue(string url)
        {
            normalQueue.Enqueue(url);
        }


        public void Enqueue(string url, FrontierQueuePriority priority)
        {
            switch (priority)
            {
                case FrontierQueuePriority.Low:
                    SynchronizedEnqueue(lowQueue, url);
                    break;
                case FrontierQueuePriority.BelowNormal:
                    SynchronizedEnqueue(belowQueue, url);
                    break;
                case FrontierQueuePriority.Normal:
                    SynchronizedEnqueue(normalQueue, url);
                    break;
                case FrontierQueuePriority.AboveNormal:
                    SynchronizedEnqueue(aboveQueue, url);
                    break;
                case FrontierQueuePriority.High:
                    SynchronizedEnqueue(highQueue, url);
                    break;
                default:
                    SynchronizedEnqueue(normalQueue, url);
                    break;
            }

        }

        public string Dequeue()
        {

            if (highQueue.Count > 0)
            {
                return SynchronizedDequeue(highQueue);
            }
            else if (aboveQueue.Count > 0)
            {
                return SynchronizedDequeue(aboveQueue);
            }
            else if (normalQueue.Count > 0)
            {
                return SynchronizedDequeue(normalQueue);
            }
            else if (belowQueue.Count > 0)
            {
                return SynchronizedDequeue(belowQueue);
            }
            else
                return SynchronizedDequeue(lowQueue);

        }


        private static void SynchronizedEnqueue(Queue<string> queue, string item)
        {
            lock (queue)
            {
                queue.Enqueue(item);
            }
        }

        private static string SynchronizedDequeue(Queue<string> queue)
        {
            lock (queue)
            {
                return queue.Dequeue();
            }
        }
    }
}
