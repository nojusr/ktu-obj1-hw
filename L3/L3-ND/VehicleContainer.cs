// VehicleContainer.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L3
{

    /// <summary>
    /// a class that stores all vehicles
    /// </summary>
    class VehicleContainer
    {
        private Vehicle[] vehicles;
        public int Count { get; private set; }

        public VehicleContainer(int capacity = 50)
        {
            this.Count = 0;
            this.vehicles = new Vehicle[capacity];
        }



        /// <summary>
        /// a method to add a value to this container
        /// </summary>
        /// <param name="vehicle">the object to add to this container</param>
        public void Add(Vehicle vehicle)
        {
            this.vehicles[this.Count] = vehicle;
            this.Count++;
        }

        /// <summary>
        /// A method to retreive a value from this container
        /// </summary>
        /// <param name="index">an integer that contains the location of the item to retreive</param>
        /// <returns>a Vehicle object</returns>
        public Vehicle Get(int index)
        {
            return this.vehicles[index];
        }

        /// <summary>
        /// An indexer to allow to use this container with the [] operator.
        /// Implemented because it would require me less work to implement 
        /// the use of this container in the VehiclesRegister class.
        /// </summary>
        public Vehicle this[int index]
        {
            get { return this.vehicles[index]; }
            set { this.vehicles[index] = value; }
        }


        public void Insert(Vehicle vehicle, int index)
        {

            if (index > this.Count) {
                this.Add(vehicle);
                return;
            }

            this.Count++;

            for (int i = this.Count; i > index; i--)
            {
                this.vehicles[i-1] = this.vehicles[i];
            }

            this.vehicles[index] = vehicle;

        }


        /// <summary>
        /// A method to remove a value from this container
        /// </summary>
        /// <param name="vehicle">the object to remove</param>
        public void Remove(Vehicle vehicle)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.vehicles[i] == vehicle)
                {
                    this.Count -= 1;
                    for (int j = i; j < this.Count; j++)
                    {
                        this.vehicles[j] = this.vehicles[j+1];
                    }
                    break;
                }
            }
        }


        /// <summary>
        /// A method to remove a value at a specific index from this container
        /// </summary>
        /// <param name="index">the index at which the value to be removed is located</param>
        public void RemoveAt(int index)
        {
            this.Count -= 1;
            for (int i = index; i < this.Count; i++)
            {
                this.vehicles[i] = this.vehicles[i+1];
            }
        }


        /// <summary>
        /// a method to determine if the container contains a given object
        /// </summary>
        /// <param name="vehicle">a Vehicle object</param>
        /// <returns>a boolean value</returns>
        public bool Contains(Vehicle vehicle)
        {

            for (int i = 0; i < this.Count; i++)
            {
                if (this.vehicles[i] == vehicle)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// a method to clear the objects contained in this container
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.vehicles[i] = null;
            }
            this.Count = 0;

        }

        /// <summary>
        /// A delegate method to specify how should the sorting in Sort be performed.
        /// Using a delegate as part of the Sort function allows for arbitrary possibilities when sorting
        /// and does not force the programmer to overload the top level methods of their custom class to do only one specific function
        /// </summary>
        /// <param name="left">the left Vehicle to compare</param>
        /// <param name="right">the right Vehicle to compare</param>
        /// <returns>1 if left is the 'bigger' object, -1 if right is the 'bigger' object, 0 if they're equal</returns>
        public delegate int SortingDelegate(Vehicle left, Vehicle right);


        /// <summary>
        /// the sorting function that uses a delegate
        /// </summary>
        /// <param name="sortingDel">A delegate method by which to sort</param>
        public void SortWithDelegate(SortingDelegate sortingDel)
        {
            bool flag = true;

            while (flag)
            {

                flag = false;

                for (int i = 0; i < this.Count-1; i++)
                {
                    Vehicle left = this.vehicles[i];
                    Vehicle right = this.vehicles[i+1];

                    if (sortingDel(left,right) > 0) {
                        this.vehicles[i] = right;
                        this.vehicles[i+1] = left;
                        flag = true;
                    }
                }
            }
        }

    }
}