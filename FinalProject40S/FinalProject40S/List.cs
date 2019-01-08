using System;
using System.Drawing;

namespace FinalProject40S
{

    /// <summary>
    /// Abstract data type
    /// </summary>
    /// <typeparam name="string">The generic data type used in the class</typeparam>
    class List
    {
        private int length;
        
        public const int NOT_FOUND = -1;
        public const int ID = 0;
        public const int POSITION = 1;
        public const int MAX_SPEED = 2;
        public const int MAX_ALTITUDE = 3;
        public const int MODEL = 4;

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
                list.Add(this.GetNode(i).Data);
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
        /// Inserts data to the front (Head) of the list, for an (1) empty list, 
        /// (2) list of 1 Aircraft, (3) list of > 1 Aircraft
        /// </summary>
        /// <param name="data">the data to add</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool Add(Data data)
        {
            if (data == null) return false;
            Aircraft aircraft = new Aircraft(data);
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
        /// Inserts data to the front (Head) of the list, for an (1) empty list, 
        /// (2) list of 1 Aircraft, (3) list of > 1 Aircraft
        /// </summary>
        /// <param name="data">the data to add</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool AddFront(Data data)
        {
            if (data == null) return false;
            Aircraft aircraft = new Aircraft(data);
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
        /// Inserts data to the front (Head) of the list, for an (1) empty list, 
        /// (2) list of 1 Aircraft, (3) list of > 1 Aircraft
        /// </summary>
        /// <param name="data">the data to add</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public Aircraft Add(Aircraft aircraft)
        {
            if (aircraft == null) return null;
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
            return null;
        }

        /// <summary>
        /// Inserts data to the front (Head) of the list, for an (1) empty list, 
        /// (2) list of 1 Aircraft, (3) list of > 1 Aircraft
        /// </summary>
        /// <param name="data">the data to add</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public Aircraft AddFront(Aircraft aircraft)
        {
            if (aircraft == null) return null;
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
            return aircraft;
        }

        /// <summary>
        /// Accessor for the aircraft at the specified index
        /// </summary>
        /// <param name="index">the index location to access</param>
        /// <returns>the aircraft (or null) at the index</returns>
        public Aircraft Get(int index)
        {
            if (!InRange(index)) return null;
            return GetNode(index);
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
        /// Mutator method sets the index location to the new data
        /// </summary>
        /// <param name="index">the index location to mutate</param>
        /// <param name="data">the new data to mutate into</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool SetNode(int index, Data data)
        {
            Aircraft current = GetNode(index);

            if (current == null) return false;
            if (data == null) return false;

            current.Data = data;
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

        public Aircraft RemoveFront()
        {
            if (IsEmpty()) return null;
            else
            {
                Aircraft aircraft = Front();
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
                return aircraft;
            }
        }

        public Aircraft RemoveBack()
        {
            if (IsEmpty()) return null;
            else
            {
                Aircraft aircraft = Back();
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
                return aircraft;
            }
        }

        public bool Contains(Data data)
        {
            Aircraft current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.next;
            }
            return false;
        }

        public bool Contains(Data data, int type)
        {
            Aircraft current = Head;
            switch (type)
            {
                case ID:
                    while (current != null)
                    {
                        if (current.Data.ID.Equals(data.ID)) return true;
                        current = current.next;
                    }
                    break;
                case POSITION:
                    while (current != null)
                    {
                        if (current.Data.Position.Equals(data.Position)) return true;
                        current = current.next;
                    }
                    break;
                case MAX_SPEED:
                    while (current != null)
                    {
                        if (current.Data.MaxSpeed.Equals(data.MaxSpeed)) return true;
                        current = current.next;
                    }
                    break;
                case MAX_ALTITUDE:
                    while (current != null)
                    {
                        if (current.Data.MaxAltitude.Equals(data.MaxAltitude)) return true;
                        current = current.next;
                    }
                    break;
                case MODEL:
                    while (current != null)
                    {
                        if (current.Data.Model.Equals(data.Model)) return true;
                        current = current.next;
                    }
                    break;
            }
            return false;
        }
        
        /// <summary>
        /// Inserts data as a new Aircraft after the passed index
        /// </summary>
        /// <param name="data">the data type to insert</param>
        /// <param name="index">the index location to insert after</param>
        /// <returns>the operation was successful (true) or not (false)</returns>
        public bool AddAfter(Data data, int index)
        {
            if (!InRange(index)) return false;              // index out of range
            if (data == null) return false;                 // invalid data to add
            if (index == length - 1) return Add(data);  // add to end of list
            else
            {                                               // adding into middle
                Aircraft aircraft = new Aircraft(data);           // create Aircraft object
                Aircraft current = GetNode(index);           // get to index spot
                aircraft.next = current.next;                   // set proper references
                current.next.previous = aircraft;
                current.next = aircraft;
                aircraft.previous = current;
                length++;                                   // increase length
                return true;                                // opperation successful
            }
        }

        public Aircraft Remove(int index)
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
            return current;
        }

        public int FirstIndexOf(Data data)
        {
            int index = 0;
            Aircraft current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data)) return index;
                index++;
                current = current.next;
            }
            return default(int);
        }

        public int LastIndexOf(Data data)
        {
            int index = length - 1;
            Aircraft current = Tail;
            while (current != null)
            {
                if (current.Data.Equals(data)) return index;
                index--;
                current = current.previous;
            }
            return default(int);
        }

        public bool Remove(Data data)
        {
            if (data == null) return false;
            int index = FirstIndexOf(data);
            if (index == NOT_FOUND) return false;
            Remove(index);
            return true;
        }

        public bool RemoveLast(Data data)
        {
            if (data == null) return false;
            int index = LastIndexOf(data);
            if (index == NOT_FOUND) return false;
            Remove(index);
            return true;
        }

        public void RemoveAll(Data data)
        {
            while (Contains(data))
            {
                Remove(data);
            }
        }

        public void RemoveAll(Data[] items)
        {
            foreach (Data item in items)
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

        public int NumberOf(Data data)
        {
            int counter = 0;
            Aircraft current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data)) counter++;
                current = current.next;
            }
            return counter;
        }

        public void AddAll(Data[] items)
        {
            foreach (Data item in items)
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

        public int[] AllIndices(Data data)
        {
            if (data == null) return null;
            if (!Contains(data)) return null;
            int size = NumberOf(data);
            int[] array = new int[size];
            Aircraft current = Head;
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (current.Data.Equals(data))
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