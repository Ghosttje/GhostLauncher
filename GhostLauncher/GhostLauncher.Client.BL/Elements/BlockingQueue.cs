using System.Collections.Generic;
using System.Threading;

namespace GhostLauncher.Client.BL.Elements
{
    public class BlockingQueue<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();

        private bool _isClosing = false;

        public void Enqueue(T item)
        {
            lock (_queue)
            {
                _queue.Enqueue(item);
                if (_queue.Count == 1)
                {
                    // wake up any blocked dequeue
                    Monitor.PulseAll(_queue);
                }
            }
        }

        public T Dequeue()
        {
            lock (_queue)
            {
                while (_queue.Count == 0)
                {
                    if (_isClosing)
                    {
                        return default(T);
                    }

                    // Start blocking
                    Monitor.Wait(_queue);
                }
                return _queue.Dequeue();
            }
        }

        public void Close()
        {
            lock (_queue)
            {
                _isClosing = true;
                Monitor.PulseAll(_queue);
            }
        }
    }
}
