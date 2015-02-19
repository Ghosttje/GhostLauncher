using System.Collections.Generic;
using System.Threading;

namespace GhostLauncher.Client.BL.Elements
{
    public class BlockingCollection<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();

        public void Add(T item)
        {
            lock (_queue)
            {
                _queue.Enqueue(item);
                Monitor.Pulse(_queue);
            }
        }

        public T Take()
        {
            lock (_queue)
            {
                while (_queue.Count == 0)
                {
                    Monitor.Wait(_queue);
                }
                return _queue.Dequeue();
            }
        }

        public bool TryTake(out T item)
        {
            item = default(T);
            lock (_queue)
            {
                if (_queue.Count > 0)
                {
                    item = _queue.Dequeue();
                }
            }
            return item != null;
        }

    }
}
