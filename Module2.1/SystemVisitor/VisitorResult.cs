using System;
using System.Collections;
using System.Collections.Generic;

namespace SystemVisitor
{
    public class VisitorResult : IEnumerable<TreeElement>
    {
        public int Count { get; private set; }

        private Node _head; 
        private Node _tail;

        public void Add(TreeElement data)
        {
            var node = new Node(data);

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
            }

            _tail = node;

            Count++;
        }

        public TreeElement this[int index]
        {
            get
            {
                var indexElement = 0;
                var element = _head;

                for (int i = 0; i <= index; i++)
                {
                    if (index == indexElement)
                    {
                        return element.Data;
                    }

                    indexElement++;
                    element = element.Next;
                }

                throw new IndexOutOfRangeException();
 
            }
           
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<TreeElement> IEnumerable<TreeElement>.GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

    }
}
