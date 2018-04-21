using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private const int InitialCapacity = 10;
    private T[] elements;

    public Stack()
    {
        this.elements = new T[InitialCapacity];
    }

    public int Count { get; set; }

    public int Capacity { get => this.elements.Length; }

    public void Push(T element)
    {
        if (this.Count == this.Capacity)
        {
            this.Resize();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }

        T element = this.elements[this.Count - 1];
        this.Count--;

        return element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void Resize()
    {
        Array.Resize(ref this.elements, 2 * this.Count);

        //this.elements = this.elements.Concat(new T[this.Count]).ToArray();

        //T[] newElements = new T[2 * this.Count];
        //Array.Copy(this.elements, newElements, this.Count);
        //this.elements = newElements;
    }
}