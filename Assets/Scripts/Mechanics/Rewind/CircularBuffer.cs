using System.Collections.Generic;

public class CircularBuffer<T>
{
    // Collection itself
    private List<T> buffer;
    // Capacity
    private int capacity;

    // Constructer - Allow me to create a circular buffer with a given capacity
    public CircularBuffer(int capacity)
    {
        buffer = new List<T>(capacity);
        this.capacity = capacity;
    }

    public int Count => buffer.Count;

    // Buffer Operations
    // =================
    // 1. Push (Adding new information to the buffer)
    public void Push(T item)
    {
        // Check if my buffer is at or above capacity
        if(buffer.Count >= capacity)
        {
            buffer.RemoveAt(0);  // removes the OLDEST data
        }

        buffer.Add(item);
    }

    // 2. Pop (Removing the next piece of information)
    public T Pop()
    {
        if(buffer.Count == 0) return default(T);    

        int lastIndex = buffer.Count - 1;
        T item = buffer[lastIndex];         // Creates a copy of the item in buffer[lastIndex] and stores it in 'item'
        buffer.RemoveAt(lastIndex);         // Removes the item at lastIndex.

        return item;
    }
}
