using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Search.Types
{
    public class PriorityQueue<T> : IEnumerable<T>, ICollection, IEnumerator<T>
    {
        private SortedList<double, List<T>> _dictionary = new SortedList<double, List<T>>();

        private int _cursor = -1;

        public void Enqueue(T item, double priority)
        {
            List<T> innerList;
            _dictionary.TryGetValue(priority, out innerList);
            if (innerList == null)
            {
                innerList = new List<T>();
                _dictionary.Add(priority, innerList);
            }

            innerList.Add(item);
        }

        public T Dequeue()
        {
            var list = _dictionary.ElementAt(0).Value;
            var item = list[0];
            list.Remove(item);
            if (list.Count == 0)
            {
                _dictionary.RemoveAt(0);
            }

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var queue in _dictionary.Values)
                {
                    count += queue.Count;
                }

                return count;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            _cursor++;

            if (_cursor < _dictionary.Values.Sum(p => p.Count))
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _cursor = -1;
        }

        public T Current
        {
            get
            {
                var lower = 0;
                var upper = 0;
                foreach (var value in _dictionary.Values)
                {
                    upper = value.Count;
                    if (upper < _cursor)
                    {
                        lower = upper;
                        continue;
                    }

                    var item = value[_cursor - lower];
                    return item;
                }

                return default(T);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
    }
}
