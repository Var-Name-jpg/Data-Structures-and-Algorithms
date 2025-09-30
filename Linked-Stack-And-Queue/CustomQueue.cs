using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLists {
	public class CustomQueue<T> : IEnumerable<T> {
		private class Node {
			public T Value;
			public Node Next;
			public Node(T value) { Value = value; Next = null; }
		}

		private Node front;
		private Node rear;
		private int count;

		public void Enqueue(T value) {
			var node = new Node(value);
			if (rear == null)
				front = rear = node;
			else {
				rear.Next = node;
				rear = node;
			}
			count ++;
		}

		public T Dequeue() {
			if (front == null)
				throw new InvalidOperationException("Dequeue from empty queue");
			var value = front.Value;
			front = front.Next;
			if (front == null)
				rear = null;
			count --;
			return value;
		}

		public T Peek() {
			if (front == null)
				throw new InvalidOperationException("Peek on empty queue");
			return front.Value;
		}

		public void Clear() {
			front = rear = null;
			count = 0;
		}

		public int Count => count;

		public IEnumerator<T> GetEnumerator() {
			var current = front;
			while (current != null) {
				yield return current.Value;
				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
