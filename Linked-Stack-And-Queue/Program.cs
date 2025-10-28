using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLists {
    /// <summary>
    /// Demonstration program for using custom stack and queue implementations.
    /// </summary>
    public class Program {
        /// <summary>
        /// Application entry point. Runs demos for <see cref="CustomStack{T}"/> and <see cref="CustomQueue{T}"/>.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        public static void Main(string[] args) {
            ///////////////////////////////////////////////////////////////////////////////
            ///                             STACK DEMONSTRATION                         ///
            ///////////////////////////////////////////////////////////////////////////////
            
            Console.WriteLine("=== STACK DEMO ===");
            var stack = new CustomStack<int>();
            
            Console.WriteLine("Push 1, 2, 3");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Peek at top element without removing
            Console.WriteLine($"Peek: {stack.Peek()}"); // Expected output: 3
            // Print current number of elements in the stack
            Console.WriteLine($"Count: {stack.Count}"); // Expected output: 3

            // Iterate over stack, from top to bottom
            Console.WriteLine("Stack contents (top to bottom):");
            foreach (var item in stack)
                Console.WriteLine(item);

            // Pop elements off the stack and print them
            Console.WriteLine($"Pop: {stack.Pop()}"); // Expected output: 3
            Console.WriteLine($"Pop: {stack.Pop()}"); // Expected output: 2

            // Count after popping two elements
            Console.WriteLine($"Count after pops: {stack.Count}");

            // Clear all elements
            Console.WriteLine("Clearing stack...");
            stack.Clear();
            Console.WriteLine($"Count after clear: {stack.Count}");

            // Exception handling for popping from empty stack
            try
            {
                Console.WriteLine("Trying to pop from empty stack:");
                stack.Pop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Exception handling for peeking on empty stack
            try
            {
                Console.WriteLine("Trying to peek on empty stack:");
                stack.Peek();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ///////////////////////////////////////////////////////////////////////////////
            ///                             QUEUE DEMONSTRATION                         ///
            ///////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\n=== QUEUE DEMO ===");
            var queue = new CustomQueue<int>();

            Console.WriteLine("Enqueue 10, 20, 30");
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // Peek at front element without removing
            Console.WriteLine($"Peek: {queue.Peek()}"); // Expected output: 10
            // Print current number of elements in queue
            Console.WriteLine($"Count: {queue.Count}"); // Expected output: 3

            // Iterate over queue, from front to rear
            Console.WriteLine("Queue contents (front to rear):");
            foreach (var item in queue)
                Console.WriteLine(item);

            // Dequeue elements and print them
            Console.WriteLine($"Dequeue: {queue.Dequeue()}"); // Expected output: 10
            Console.WriteLine($"Dequeue: {queue.Dequeue()}"); // Expected output: 20

            // Count after dequeuing two elements
            Console.WriteLine($"Count after dequeues: {queue.Count}");

            // Clear entire queue
            Console.WriteLine("Clearing queue...");
            queue.Clear();
            Console.WriteLine($"Count after clear: {queue.Count}");

            // Exception handling for dequeuing from empty queue
            try
            {
                Console.WriteLine("Trying to dequeue from empty queue:");
                queue.Dequeue();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Exception handling for peeking on empty queue
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
