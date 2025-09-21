using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A generic queue implementation using a raw array with dynamic resizing.
/// </summary>
/// <typeparam name=T>The type of elements stored in the queue.</typeparam>
public class CustomQueue<T> : IEnumerable<T> {
    private T[] _items;
    private int _head;
    private int _tail;
    private int _count;

    /// <summary>
    /// Initializes a new instance of the <see cref=CustomQueue{T}/> class with an optional initial capacity.
    /// </summary>
    /// <param name=capacity>Initial capacity of the queue. Defaults to 4.</param>
    public CustomQueue(int capacity = 4) {
        _items = new T[capacity];
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    /// <summary>
    /// Gets the number of elements contained in the queue.
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// Adds an item to the end of the queue.
    /// </summary>
    /// <param name=item>The item to enqueue.</param>
    public void Enqueue(T item) {
        EnsureCapacity();
        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _count++;
    }

    /// <summary>
    /// Removes and returns the item at the front of the queue.
    /// </summary>
    /// <returns>The item removed from the front of the queue.</returns>
    /// <exception cref=InvalidOperationException>Thrown when the queue is empty.</exception>
    public T Dequeue() {
        if (_count == 0)
            throw new InvalidOperationException("Queue is empty.");

        T item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        _count--;
        return item;
    }

    /// <summary>
    /// Returns the item at the front of the queue without removing it.
    /// </summary>
    /// <returns>The item at the front of the queue.</returns>
    /// <exception cref=InvalidOperationException>Thrown when the queue is empty.</exception>
    public T Peek() {
        if (_count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return _items[_head];
    }

    /// <summary>
    /// Clears all items from the queue and resets its capacity to 4.
    /// </summary>
    public void Clear() {
        _items = new T[4];
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    /// <summary>
    /// Ensures the internal array has enough capacity to store additional items.
    /// Doubles the array size when full.
    /// </summary>
    private void EnsureCapacity() {
        if (_count == _items.Length) {
            T[] newArray = new T[_items.Length * 2];
            for (int i = 0; i < _count; i++) {
                int index = (_head + i) % _items.Length;
                newArray[i] = _items[index];
            }
            _items = newArray;
            _head = 0;
            _tail = _count;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the queue.
    /// </summary>
    /// <returns>An enumerator for the queue.</returns>
    public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i < _count; i++) {
                    int index = (_head + i) % _items.Length;
                    yield return _items[index];
            }
        }
    
    /// <summary>
    /// Returns a non-generic enumerator that iterates through the queue.
    /// </summary>
    /// <returns>An enumerator for the queue.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
