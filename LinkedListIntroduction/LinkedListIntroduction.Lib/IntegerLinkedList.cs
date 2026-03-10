using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListIntroduction.Lib
{
    public class IntegerLinkedList
    {
        IntegerNode _head;

        public IntegerLinkedList()
        {
            _head = null;
        }

        public IntegerLinkedList(int v)
        {
            _head = new IntegerNode(v);
        }

        public int Count => _head == null ? 0 : _head.Count;
        public int Sum => _head == null ? 0 : _head.Sum;

        public void Append(int v)
        {
            if (_head == null)
                _head = new IntegerNode(v);
            else
                _head.Append(v);

        }

        public override string ToString()
        {
            return _head == null ? "{}" : $"{{{_head}}}";
        }

        public void Prepend(int v)
        {
            IntegerNode newHead = new IntegerNode(v) { _next = _head };
            _head = newHead;
        }

        public bool Delete(int v)
        {
            if (_head == null) return false;
            if (_head._value == v)
            {
                _head._next = null;
                return true;
            }

            IntegerNode current = _head;
            while (current._next != null)
            {
                if (current._next._value == v)
                {
                    current._next = current._next._next;
                    return true;
                }
                current = current._next;
            }
            return false;
        }

        public void Insert(int value, int index)
        {
            if (index <= 0)
            {
                Prepend(value);
                return;
            }
            IntegerNode current = _head;
            for (int i = 0; i < index - 1 && current != null; i++)
            {
                current = current._next;
            }
            if (current == null)
            {
                Append(value);
                return;
            }
            IntegerNode newNode = new IntegerNode(value);
            newNode._next = current._next;
            current._next = newNode;
        }

        public void Join(IntegerLinkedList otherList)
        {
            if (otherList == null || otherList._head == null) return;
            if (_head == null)
            {
                _head = otherList._head;
                return;
            }
            IntegerNode current = _head;
            while (current._next != null)
            {
                current = current._next;
            }
            current._next = otherList._head;
        }

        public bool Contains(int v)
        {
            IntegerNode current = _head;
            while (current != null)
            {
                if (current._value == v) { return true; }
                current = current._next;
            }
            return false;
        }

        public void RemoveDupes()
        {
            if (_head == null) return;
            HashSet<int> seenValues = new HashSet<int>();

            IntegerNode current = _head;
            seenValues.Add(current._value);
            while (current._next != null)
            {
                if (seenValues.Contains(current._next._value))
                {
                    current._next = current._next._next;
                }
                else
                {
                    seenValues.Add(current._next._value);
                    current = current._next;
                }
            }
        }

        public void Merge(IntegerLinkedList otherList)
        {
            if (otherList == null || otherList._head == null) return;
            if (_head == null)
            {
                _head = otherList._head;
                otherList._head = null;
                return;
            }

            IntegerNode curr1 = _head;
            IntegerNode curr2 = otherList._head;

            while (curr1 != null && curr2 != null)
            {
                IntegerNode next1 = curr1._next;
                IntegerNode next2 = curr2._next;
                curr1._next = curr2;
                if (next1 != null)
                {
                    curr2._next = next1;
                }
                curr1 = next1;
                curr2 = next2;
            }
            otherList._head = null;
        }

        public IntegerLinkedList Reverse()
        {
            IntegerLinkedList reversedList = new IntegerLinkedList();
            IntegerNode current = _head;
            while (current != null)
            {
                reversedList.Prepend(current._value);
                current = current._next;
            }
            return reversedList;
        }

    }
    class IntegerNode
    {
        internal int _value;
        internal IntegerNode _next;

        internal int Count => _next == null ? 1 : 1 + _next.Count;

        internal int Sum => _next == null ? _value : _value + _next.Sum;


        internal IntegerNode(int v)
        {
            _value = v;
            _next = null;
        }

        internal void Append(int v)
        {
            if (_next == null)
                _next = new IntegerNode(v);
            else
                _next.Append(v);
        }

        public override string ToString()
        {
            return _next == null ? _value.ToString() : $"{_value}, {_next}";
        }
    }

    class SortedIntegerLinkedList {}
}


