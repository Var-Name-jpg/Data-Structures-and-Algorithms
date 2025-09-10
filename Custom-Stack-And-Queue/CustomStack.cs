using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A generic stack implementation using a raw array with dynamic resizing.
/// </summary>
/// <typeparam name=T>The type of elements stored in the stack.</typeparam>
public class CustomStack<T> : IEnumerable<T> {
    private T[] _items;
    private int _count;

    /// <summary>
    /// Initializes a new instance of the <see cref=CustomStack{T}/> class with an optional initial capacity.
    /// </summary>
    /// <param name=capacity>Initial capacity of the stack. Defaults to 4.</param>
    public CustomStack(int capacity = 4) {
        _items = new T[capacity];
        _count = 0;
    }

    /// <summary>
    /// Gets the number of elements contained in the stack.
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// Adds an item to the top of the stack.
    /// </summary>
    /// <param name=item>The item to push onto the stack.</param>
    public void Push(T item) {
        EnsureCapacity();
        _items[_count++] = item;
    }

    /// <summary>
    /// Removes and returns the item at the top of the stack.
    /// </summary>
    /// <returns>The item removed from the top of the stack.</returns>
    /// <exception cref=InvalidOperationException>Thrown when the stack is empty.</exception>
    public T Pop() {
        if (_count == 0)
            throw new InvalidOperationException(Stack is empty);

        T item = _items[--_count];
        _items[_count] = default!;
        return item;
    }

    /// <summary>
    /// Returns the item at the top of the stack without removing it.
    /// </summary>
    /// <returns>The item at the top of the stack.</returns>
    /// <exception cref=InvalidOperationException>Thrown when the stack is empty.</exception>
    public T Peek() {
        if (_count == 0)
            throw new InvalidOperationException(Stack is empty);

        return _items[_count-1];
    }

    /// <summary>
    /// Clears all items from the stack and resets its capacity to 4.
    /// </summary>
    public void Clear() {
        _items = new T[4];
        _count = 0;
    }

    /// <summary>
    /// Ensures the internal array has enough capacity to store additional items.
    /// Doubles the array size when full.
    /// </summary>
    private void EnsureCapacity() {
        if (_count == _items.Length) {
            T[] newArray = new T[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++) {
                newArray[i] = _items[i];
            }
            _items = newArray;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the stack from top to bottom.
    /// </summary>
    /// <returns>An enumerator for the stack.</returns>
    public IEnumerator<T> GetEnumerator() {
        for (int i = _count - 1; i >= 0; i--) {
            yield return _items[i];
        }
    }
    
    /// <summary>
    /// Returns a non-generic enumerator that iterates through the stack.
    /// </summary>
    /// <returns>An enumerator for the stack.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
