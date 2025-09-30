using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLists {
	public class CustomStack<T> : IEnumerable<T> {
		private class Node {
			public T Value;
			public Node Next;
			public Node(T value) { Value = value; Next = null; }
		}

		private Node top;
		private int count;

		public void Push(T value) {
			var node = new Node(value) { Next = top };
			top = node;
			count ++;
		}

		public T Pop() {
			if (top == null)
				throw new InvalidOperationException("Pop from empty stack");
			var value = top.Value;
			top = top.Next;
			count --;
			return value;
		}

		public T Peek() {
			if (top == null)
				throw new InvalidOperationException("Peek on empty stack");
			return top.Value;
		}

		public void Clear() {
			top = null;
			count = 0;
		}

		public int Count => count;

		public IEnumerator<T> GetEnumerator() {
			var current = top;
			while (current != null) {
				yield return current.Value;
				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
