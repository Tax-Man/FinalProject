using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject40S
{
    public class Path
    {
        public const int MAX_CAPACITY = 25;

        private int length;
        private Aircraft head;
        private Aircraft tail;

        /// <summary>
        /// default constructor
        /// </summary>
        public Path()
        {
            Finalize();
        }

        /// <summary>
        /// String representation of this object
        /// </summary>
        /// <returns>The object represented as a String</returns>
        public override string ToString()
        {
            if (IsEmpty()) return "empty";
            string text = "{\n";
            Aircraft current = head;
            while (current != null)
            {
                text += current.ToString() + ',';
                current = current.next;
            }
            return text + "\n}";
        }
        
        /// <summary>
        /// Frees up all memory used by this object
        /// </summary>
        public void Finalize()
        {
            length = 0;
            head = tail = null;
            GC.Collect();
        }

        /// <summary>
        /// Determines if the list is empty (no content)
        /// </summary>
        /// <returns>is empty (true) or not empty (false)</returns>
        public bool IsEmpty()
        {
            return length == 0;
        }

        /// <summary>
        /// Accessor method for the number of nodes (the length) of the list
        /// </summary>
        /// <returns>the number of nodes in the list</returns>
        public int Size()
        {
            return length;
        }

        /// <summary>
        /// Inserts data to the front (head) of the list, for an (1) empty list, 
        /// (2) list of 1 node, (3) list of > 1 node
        /// </summary>
        /// <param name="data">the data type to add</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool Add(T data)
        {
            if (data == null) return false;
            Aircraft node = new Aircraft(data);
            if (IsEmpty())
            {
                head = tail = node;
            }
            else
            {
                node.previous = tail;
                tail.next = node;
                tail = node;
            }
            length++;
            return true;
        }
        
        /// <summary>
        /// Accessor for the data at the specified index
        /// </summary>
        /// <param name="index">the index location to access</param>
        /// <returns>the data (or null) at the index</returns>
        public T Get(int index)
        {
            if (!InRange(index)) return default(T);
            return GetNode(index).data;
        }
        
        private bool InRange(int index)
        {
            if (IsEmpty() || index < 0 || index >= length) return false;
            return true;
        }

        protected Aircraft GetFirstNode()
        {
            return head;
        }

        protected Aircraft GetLastNode()
        {
            return tail;
        }

        protected Aircraft GetNode(int index)
        {
            if (!InRange(index)) return null;
            if (index == 0) return GetFirstNode();
            if (index == length - 1) return GetLastNode();

            Aircraft current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current;
        }

        /// <summary>
        /// Mutator method sets the index location to the new data
        /// </summary>
        /// <param name="index">the index location to mutate</param>
        /// <param name="data">the new data to mutate into</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool SetNode(int index, T data)
        {
            Aircraft current = GetNode(index);

            if (current == null) return false;
            if (data == null) return false;

            current.data = data;
            return true;
        }

        public Aircraft Front()
        {
            return Get(0);
        }
        public Aircraft Back()
        {
            return Get(length - 1);
        }

        public T RemoveFront()
        {
            if (IsEmpty()) return default(T);
            else
            {
                T data = Front();
                if (length == 1)
                {
                    Finalize();
                }
                else
                {
                    head = head.next;
                    head.previous.next = null;
                    head.previous = null;
                    length--;
                    GC.Collect();
                }
                return data;
            }
        }

        public T RemoveBack()
        {
            if (IsEmpty()) return default(T);
            else
            {
                T data = Back();
                if (length == 1)
                {
                    Finalize();
                }
                else
                {
                    tail = tail.previous;
                    tail.next.previous = null;
                    tail.next = null;
                    length--;
                    GC.Collect();
                }
                return data;
            }
        }

        public bool Contains(T data)
        {
            Aircraft current = head;
            while (current != null)
            {
                if (current.data.Equals(data)) return true;
                current = current.next;
            }
            return false;
        }

        /// <summary>
        /// Inserts data as a new node after the passed index
        /// </summary>
        /// <param name="data">the data type to insert</param>
        /// <param name="index">the index location to insert after</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool AddAfter(T data, int index)
        {
            if (!InRange(index)) return false;
            if (data == null) return false;
            if (index == length - 1) return Add(data);
            else
            {
                Aircraft node = new Aircraft(data);
                Aircraft current = GetNode(index);
                node.next = current.next;               
                current.next.previous = node;
                current.next = node;
                node.previous = current;
                length++;  
                return true;                              
            }
        }

        public T Remove(int index)
        {
            if (!InRange(index)) return default(T);
            if (index == 0) return RemoveFront();
            if (index == length - 1) return RemoveFront();
            Aircraft current = GetNode(index);
            current.previous.next = current.next;
            current.next.previous = current.previous;
            current.next = current.previous = null;
            length--;
            GC.Collect();
            return current.data;
        }
        public int FirstIndexOf(T data)
        {
            int index = 0;
            Aircraft current = head;
            while (current != null)
            {
                if (current.data.Equals(data)) return index;
                index++;
                current = current.next;
            }
            return default(int);
        }

        public int LastIndexOf(T data)
        {
            int index = length - 1;
            Aircraft current = tail;
            while (current != null)
            {
                if (current.data.Equals(data)) return index;
                index--;
                current = current.previous;
            }
            return default(int);
        }

        public bool Remove(T data)
        {
            if (data == null) return false;
            int index = FirstIndexOf(data);
            if (index == NOT_FOUND) return false;
            Remove(index);
            return true;
        }

        public bool RemoveLast(T data)
        {
            if (data == null) return false;
            int index = LastIndexOf(data);
            if (index == NOT_FOUND) return false;
            Remove(index);
            return true;
        }
        
        public void Clear()
        {
            Aircraft current = head;
            while (current != null)
            {
                Aircraft next = current.next;

                current.Finalize();

                current = next;
            }
            Finalize();
        }

        public int NumberOf(T data)
        {
            int counter = 0;
            Aircraft current = head;
            while (current != null)
            {
                if (current.data.Equals(data)) counter++;
                current = current.next;
            }
            return counter;
        }

        public void AddAll(T[] items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public void AddAll(Path list)
        {
            for (int i = 0; i < list.Size(); i++)
            {
                Add(list.Get(i));
            }
        }

        public void Insert(Path list, int index)
        {
            for (int i = 0; i < list.Size(); i++)
            {
                AddAfter(list.Get(i), index);
            }
        }

        public Path SubList(int from, int to)
        {
            if (!InRange(from)) return null;
            if (!InRange(to)) return null;
            if (from > to) return null;
            Path list = new Path();
            for (int i = from; i <= to; i++)
            {
                list.Add(Get(i));
            }
            return list;
        }

        public int[] AllIndices(T data)
        {
            if (data == null) return null;
            if (!Contains(data)) return null;
            int size = NumberOf(data);
            int[] array = new int[size];
            Aircraft current = head;
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (current.data.Equals(data))
                {
                    array[counter] = i;
                    counter++;
                    if (counter >= size) return array;
                }
                current = current.next;
            }
            return array;
        }

        public void FromArray(T[] array)
        {
            Finalize();
            foreach (T item in array)
            {
                Add(item);
            }
        }

        public void FromPath(Path list)
        {
            Finalize();
            for (int i = 0; i < list.length; i++)
            {
                Add(list.Get(i));
            }
        }

        public Path(T[] array)
        {
            FromArray(array);
        }
        public T[] ToArray(T[] array)
        {
            array = (T[])Array.CreateInstance(array.GetType(), length);

            for (int i = 0; i < length; i++)
            {
                array[i] = Get(i);
            }
            return array;
        }

    }
}