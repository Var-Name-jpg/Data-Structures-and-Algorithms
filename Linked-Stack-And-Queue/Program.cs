using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLists {
	public class Program {
		public static void Main(string[] args) {
			// Stack demo
			Console.WriteLine("=== STACK DEMO ===");
			var stack = new CustomStack<int>();
			
			Console.WriteLine("Push 1, 2, 3");
			stack.Push(1);
			stack.Push(2);
			stack.Push(3);

			Console.WriteLine($"Peek: {stack.Peek()}"); // Should print 3
			Console.WriteLine($"Count: {stack.Count}"); // Should print 3

			Console.WriteLine("Stack contents (top to bottom):");
			foreach (var item in stack)
			    Console.WriteLine(item);

			Console.WriteLine($"Pop: {stack.Pop()}"); // Should print 3
			Console.WriteLine($"Pop: {stack.Pop()}"); // Should print 2

			Console.WriteLine($"Count after pops: {stack.Count}");

			Console.WriteLine("Clearing stack...");
			stack.Clear();
			Console.WriteLine($"Count after clear: {stack.Count}");

			try
			{
			    Console.WriteLine("Trying to pop from empty stack:");
			    stack.Pop();
			}
			catch (Exception ex)
			{
			    Console.WriteLine(ex.Message);
			}

			try
			{
			    Console.WriteLine("Trying to peek on empty stack:");
			    stack.Peek();
			}
			catch (Exception ex)
			{
			    Console.WriteLine(ex.Message);
			}

			// Queue demo
			Console.WriteLine("\n=== QUEUE DEMO ===");
			var queue = new CustomQueue<int>();

			Console.WriteLine("Enqueue 10, 20, 30");
			queue.Enqueue(10);
			queue.Enqueue(20);
			queue.Enqueue(30);

			Console.WriteLine($"Peek: {queue.Peek()}"); // Should print 10
			Console.WriteLine($"Count: {queue.Count}"); // Should print 3

			Console.WriteLine("Queue contents (front to rear):");
			foreach (var item in queue)
			    Console.WriteLine(item);

			Console.WriteLine($"Dequeue: {queue.Dequeue()}"); // Should print 10
			Console.WriteLine($"Dequeue: {queue.Dequeue()}"); // Should print 20

			Console.WriteLine($"Count after dequeues: {queue.Count}");

			Console.WriteLine("Clearing queue...");
			queue.Clear();
			Console.WriteLine($"Count after clear: {queue.Count}");

			try
			{
			    Console.WriteLine("Trying to dequeue from empty queue:");
			    queue.Dequeue();
			}
			catch (Exception ex)
			{
			    Console.WriteLine(ex.Message);
			}

			try
			{
			    Console.WriteLine("Trying to peek on empty queue:");
			    queue.Peek();
			}
			catch (Exception ex)
			{
			    Console.WriteLine(ex.Message);
			}
		}
	}
}
