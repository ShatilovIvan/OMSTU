using System;

class Vector<T>
{
    int Capacity {get; set;}
    int Count {get; set;}
    const int DefaultCapacity = 4;
    T[] arr;
    
    public Vector()
    {
        arr = new T[DefaultCapacity];
        Capacity = DefaultCapacity;
    }

    public Vector(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException();
        
        arr = new T[capacity];
        Capacity = capacity;
    }

    public void Add(T item)
    {
        if (Count >= Capacity)
        {
            Resize();
        }

        arr[Count] = item;
        Count++;
    }

    private void Resize()
    {
        int newCapacity = Capacity * 2;
        T[] newArray = new T[newCapacity];
        
        for (int i = 0; i < Capacity; i++)
        {
            newArray[i] = arr[i];
        }

        Capacity = newCapacity;
        arr = newArray;
    }

    public T GetAt(int id)
    {
        if (id < 0 || id >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        return arr[id];
    }

    public void Delete(int id)
    {
         if (id < 0 || id >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = id; i < Count - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        arr[Count - 1] = default;
        Count--;
    }
}
