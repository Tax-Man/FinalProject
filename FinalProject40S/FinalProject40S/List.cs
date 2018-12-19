using System;
using System.Drawing;

namespace FinalProject40S
{

    /// <summary>
    /// Abstract ID type
    /// </summary>
    /// <typeparam name="string">The generic data type used in the class</typeparam>
    class List
    {
        private int length;
        
        public const int NOT_FOUND = -1;
        
        /// <summary>
        /// First Aircraft in the path
        /// </summary>
        public Aircraft Head
        {
            get => Head;
            set => Head = value;
        }
        /// <summary>
        /// Last Aircraft in the path
        /// </summary>
        private Aircraft Tail
        {
            get => Tail;
            set => Tail = value;
        }
        /// <summary>
        /// Type of path; (0) Civilian; (1) Military
        /// </summary>
        public int Type
        {
            get => Type;
            set => Type = value;
        }
        public PointF Start
        {
            get => Start;
            set => Start = value;
        }
        private PointF End
        {
            get => End;
            set => End = value;
        }
        
        /// <summary>
        /// default constructor
        /// </summary>
        public List()
        {
            Finalize();
        }

        public List(PointF start, PointF end)
        {
            Finalize();
            Start = start;
            End = end;
        }

        /// <summary>
        /// String representation of this object
        /// </summary>
        /// <returns>The object represented as a String</returns>
        public override string ToString()
        {
            if (IsEmpty()) return "empty";
            string text = "{\n";
            Aircraft current = Head;
            while (current != null)
            {
                text += current.ToString() + ',';
                current = current.next;
            }
            return text + "\n}";
        }

        /// <summary>
        /// Determines if two objects are "equal" in this context
        /// </summary>
        /// <param name="item">the object to compare to</param>
        /// <returns>the objects are "equal" (true) or not (false)</returns>
        public override bool Equals(object item)
        {
            List that = (List)item;
            if (this.Size() != that.Size()) return false;
            Aircraft current1 = Head;
            Aircraft current2 = Head;

            while (current1 != null)
            {
                if (!current1.Equals(current2))
                {
                    return false;
                }
                current1 = current1.next;
                current2 = current2.next;
            }
            return true;
        }

        /// <summary>
        /// Creates a duplicate object using new memory
        /// </summary>
        /// <returns>a "clone" of the object using new memory</returns>
        public List Clone()
        {
            List list = new List();
            for (int i = 0; i < length; i++)
            {
                list.Add(this.GetNode(i).ID);
            }


            return list;
        }

        /// <summary>
        /// Frees up all memory used by this object
        /// </summary>
        public void Finalize()
        {
            length = 0;
            Head = Tail = null;
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
        /// Inserts ID to the front (Head) of the list, for an (1) empty list, 
        /// (2) list of 1 Aircraft, (3) list of > 1 Aircraft
        /// </summary>
        /// <param name="ID">the ID type to add</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool Add(string ID)
        {
            if (ID == null) return false;
            Aircraft aircraft = new Aircraft(ID);
            if (IsEmpty())
            {
                Head = Tail = aircraft;
            }
            else
            {
                aircraft.previous = Tail;
                Tail.next = aircraft;
                Tail = aircraft;
            }
            length++;
            return true;
        }
        

        /// <summary>
        /// Inserts ID to the front (Head) of the list, for an (1) empty list, 
        /// (2) list of 1 Aircraft, (3) list of > 1 Aircraft
        /// </summary>
        /// <param name="ID">the ID type to add</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool AddFront(string ID)
        {
            if (ID == null) return false;
            Aircraft aircraft = new Aircraft(ID);
            if (IsEmpty())
            {
                Head = Tail = aircraft;
            }
            else
            {
                aircraft.next = Head;
                Head.previous = aircraft;
                Head = aircraft;
            }
            length++;
            return true;
        }

        /// <summary>
        /// Accessor for the ID at the specified index
        /// </summary>
        /// <param name="index">the index location to access</param>
        /// <returns>the ID (or null) at the index</returns>
        public string Get(int index)
        {
            if (!InRange(index)) return null;
            return GetNode(index).ID;
        }


        private bool InRange(int index)
        {
            if (IsEmpty() || index < 0 || index >= length) return false;
            return true;
        }
        

        protected Aircraft GetNode(int index)
        {
            if (!InRange(index)) return null;
            if (index == 0) return Head;
            if (index == length - 1) return Tail;

            Aircraft current = Head;

            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current;
        }

        /// <summary>
        /// Mutator method sets the index location to the new ID
        /// </summary>
        /// <param name="index">the index location to mutate</param>
        /// <param name="ID">the new ID to mutate into</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool SetNode(int index, string ID)
        {
            Aircraft current = GetNode(index);

            if (current == null) return false;
            if (ID == null) return false;

            current.ID = ID;
            return true;
        }

        public string Front()
        {
            return Get(0);
        }
        public string Back()
        {
            return Get(length - 1);
        }

        public string RemoveFront()
        {
            if (IsEmpty()) return default(string);
            else
            {
                string ID = Front();
                if (length == 1)
                {
                    Finalize();
                }
                else
                {
                    Head = Head.next;
                    Head.previous.next = null;
                    Head.previous = null;
                    length--;
                    GC.Collect();
                }
                return ID;
            }
        }

        public string RemoveBack()
        {
            if (IsEmpty()) return null;
            else
            {
                string ID = Back();
                if (length == 1)
                {
                    Finalize();
                }
                else
                {
                    Tail = Tail.previous;
                    Tail.next.previous = null;
                    Tail.next = null;
                    length--;
                    GC.Collect();
                }
                return ID;
            }
        }

        public bool Contains(string ID)
        {
            Aircraft current = Head;
            while (current != null)
            {
                if (current.ID.Equals(ID)) return true;
                current = current.next;
            }
            return false;
        }

        /// <summary>
        /// Inserts ID as a new Aircraft after the passed index
        /// </summary>
        /// <param name="ID">the ID type to insert</param>
        /// <param name="index">the index location to insert after</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool AddAfter(string ID, int index)
        {
            if (!InRange(index)) return false;              // index out of range
            if (ID == null) return false;                 // invalid ID to add
            if (index == length - 1) return Add(ID);  // add to end of list
            else
            {                                               // adding into middle
                Aircraft aircraft = new Aircraft(ID);           // create Aircraft object
                Aircraft current = GetNode(index);           // get to index spot
                aircraft.next = current.next;                   // set proper references
                current.next.previous = aircraft;
                current.next = aircraft;
                aircraft.previous = current;
                length++;                                   // increase length
                return true;                                // opperation successful
            }
        }

        public string Remove(int index)
        {
            if (!InRange(index)) return null;
            if (index == 0) return RemoveFront();
            if (index == length - 1) return RemoveFront();
            Aircraft current = GetNode(index);
            current.previous.next = current.next;
            current.next.previous = current.previous;
            current.next = current.previous = null;
            length--;
            GC.Collect();
            return current.ID;
        }
        public int FirstIndexOf(string ID)
        {
            int index = 0;
            Aircraft current = Head;
            while (current != null)
            {
                if (current.ID.Equals(ID)) return index;
                index++;
                current = current.next;
            }
            return default(int);
        }

        public int LastIndexOf(string ID)
        {
            int index = length - 1;
            Aircraft current = Tail;
            while (current != null)
            {
                if (current.ID.Equals(ID)) return index;
                index--;
                current = current.previous;
            }
            return default(int);
        }

        public bool Remove(string ID)
        {
            if (ID == null) return false;
            int index = FirstIndexOf(ID);
            if (index == NOT_FOUND) return false;
            Remove(index);
            return true;
        }

        public bool RemoveLast(string ID)
        {
            if (ID == null) return false;
            int index = LastIndexOf(ID);
            if (index == NOT_FOUND) return false;
            Remove(index);
            return true;
        }

        public void RemoveAll(string ID)
        {
            while (Contains(ID))
            {
                Remove(ID);
            }
        }

        public void RemoveAll(string[] items)
        {
            foreach (string item in items)
            {
                RemoveAll(item);
            }
        }

        public void Clear()
        {
            Aircraft current = Head;
            while (current != null)
            {
                Aircraft next = current.next;

                current.Finalize();

                current = next;
            }
            Finalize();
        }

        public int NumberOf(string ID)
        {
            int counter = 0;
            Aircraft current = Head;
            while (current != null)
            {
                if (current.ID.Equals(ID)) counter++;
                current = current.next;
            }
            return counter;
        }

        public void AddAll(string[] items)
        {
            foreach (string item in items)
            {
                Add(item);
            }
        }

        public void AddAll(List list)
        {
            for (int i = 0; i < list.Size(); i++)
            {
                Add(list.Get(i));
            }
        }

        public void Insert(List list, int index)
        {
            for (int i = 0; i < list.Size(); i++)
            {
                AddAfter(list.Get(i), index);
            }
        }

        public List SubList(int from, int to)
        {
            if (!InRange(from)) return null;
            if (!InRange(to)) return null;
            if (from > to) return null;
            List list = new List();
            for (int i = from; i <= to; i++)
            {
                list.Add(Get(i));
            }
            return list;
        }

        public int[] AllIndices(string ID)
        {
            if (ID == null) return null;
            if (!Contains(ID)) return null;
            int size = NumberOf(ID);
            int[] array = new int[size];
            Aircraft current = Head;
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (current.ID.Equals(ID))
                {
                    array[counter] = i;
                    counter++;
                    if (counter >= size) return array;
                }
                current = current.next;
            }
            return array;
        }

        //public void FromArray(string[] array)
        //{
        //    Finalize();
        //    foreach (string item in array)
        //    {
        //        Add(item);
        //    }
        //}

        public void FromLinkedList(List list)
        {
            Finalize();
            for (int i = 0; i < list.length; i++)
            {
                Add(list.Get(i));
            }
        }

        //public ListAll(string[] array)
        //{
        //    FromArray(array);
        //}
        //public string[] ToArray(string[] array)
        //{
        //    array = (string[])Array.CreateInstance(array.GetType(), length);

        //    for (int i = 0; i < length; i++)
        //    {
        //        array[i] = Get(i);
        //    }
        //    return array;
        //}

    }
}