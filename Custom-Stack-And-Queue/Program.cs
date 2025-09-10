using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== STACK DEMO ===");
        var stack = new CustomStack<int>();

        Console.WriteLine("Pushing: 1, 2, 3");
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine("Stack contents (top to bottom):");
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Count after pop: {stack.Count}");

        Console.WriteLine("Clearing stack...");
        stack.Clear();
        Console.WriteLine($"Count after clear: {stack.Count}");

        try
        {
            Console.WriteLine("Attempting to Peek on empty stack...");
            stack.Peek();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\n=== QUEUE DEMO ===");
        var queue = new CustomQueue<string>();

        Console.WriteLine("Enqueuing: Alice, Bob, Charlie");
        queue.Enqueue("Alice");
        queue.Enqueue("Bob");
        queue.Enqueue("Charlie");

        Console.WriteLine("Queue contents (front to back):");
        foreach (var name in queue)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine($"Peek: {queue.Peek()}");
        Console.WriteLine($"Dequeue: {queue.Dequeue()}");
        Console.WriteLine($"Count after dequeue: {queue.Count}");

        Console.WriteLine("Clearing queue...");
        queue.Clear();
        Console.WriteLine($"Count after clear: {queue.Count}");

        try
        {
            Console.WriteLine("Attempting to Dequeue on empty queue...");
            queue.Dequeue();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

