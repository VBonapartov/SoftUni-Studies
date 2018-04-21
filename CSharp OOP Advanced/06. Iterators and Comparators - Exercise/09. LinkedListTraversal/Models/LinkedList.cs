using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node<T> firstElement;

    public LinkedList()
    {
        this.Count = 0;
    }

    public int Count { get; private set; }

    private Node<T> Head { get; set; }

    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);

        if (this.IsEmpty())
        {
            this.Head = newNode;
            this.firstElement = newNode;
        }
        else
        {
            this.Head.Next = newNode;
            newNode.Prev = this.Head;
            this.Head = newNode;
        }

        this.Count++;
    }

    public void Remove(T item)
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException("Linked List is empty!");
        }

        if (this.Count == 1)
        {
            this.Clear();
        }

        Node<T> currentNode = this.firstElement;

        while (currentNode.Next != null)
        {
            if (currentNode.Value.Equals(item))
            {
                if (currentNode.Prev != null)
                {
                    currentNode.Prev.Next = currentNode.Next;
                }
                else
                {
                    this.firstElement = this.firstElement.Next;
                    this.firstElement.Prev = null;
                }

                if (currentNode.Next != null)
                {
                    currentNode.Next.Prev = currentNode.Prev;
                }
                else
                {
                    currentNode.Prev.Next = null;
                }

                this.Count--;
            }

            currentNode = currentNode.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> currentNode = this.firstElement;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private bool IsEmpty()
    {
        return this.Count == 0;
    }

    private void Clear()
    {
        this.Head = null;
        this.Count = 0;
        this.firstElement = null;
    }
}