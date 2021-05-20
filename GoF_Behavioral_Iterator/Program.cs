using System;
using System.Collections;

/// <summary>
/// Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation. 
/// </summary>
namespace Behavioral_Iterator
{
    class Program
    {
        /// <summary>
        /// A collection item
        /// </summary>
        class Item
        {
            // Constructor
            public Item(string name)
            {
                Name = name;
            }
            
            // Gets name
            public string Name { get; }
        }


        /// <summary>
        ///  interface for creating an Iterator object
        /// </summary>
        interface IAbstractCollection
        {
            Iterator CreateIterator();
        }


        /// <summary>
        /// implements the Iterator creation interface
        /// </summary>
        class Collection : IAbstractCollection
        {
            private ArrayList _items = new ArrayList();

            public Iterator CreateIterator()
            {
                return new Iterator(this);
            }

            // Gets item count
            public int Count
            {
                get { return _items.Count; }
            }
            
            // Indexer
            public object this[int index]
            {
                get { return _items[index]; }
                set { _items.Add(value); }
            }
        }

        /// <summary>
        /// interface for accessing elements.
        /// </summary>
        interface IAbstractIterator
        {
            Item First();
            Item Next();
            bool IsDone { get; }
            Item CurrentItem { get; }
        }

        /// <summary>
        /// 
        /// </summary>
        class Iterator : IAbstractIterator
        {
            private Collection _collection;
            private int _current = 0;

            // Constructor
            public Iterator(Collection collection)
            {
                _collection = collection;
            }
            
            // Gets first item
            public Item First()
            {
                _current = 0;
                return _collection[_current] as Item;
            }
            
            // Gets next item
            public Item Next()
            {
                _current += Step;
                if (!IsDone)
                    return _collection[_current] as Item;
                else
                    return null;
            }
            
            // Gets or sets stepsize
            public int Step { get; set; } = 1;

            // Gets current iterator item
            public Item CurrentItem
            {
                get { return _collection[_current] as Item; }
            }
            
            // Gets whether iteration is complete
            public bool IsDone
            {
                get { return _current >= _collection.Count; }
            }
        }

        static void Main(string[] args)
        {
            // Build a collection
            Collection collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");
            collection[8] = new Item("Item 8");
            
            // Create iterator
            Iterator iterator = collection.CreateIterator();

            // Skip every other item
            iterator.Step = 2;
            
            Console.WriteLine("Iterating over collection:");

            for (Item item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }
            
            // Wait for user
            Console.ReadKey();
        }
    }
}
