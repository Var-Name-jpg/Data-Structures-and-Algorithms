namespace CustomLists {
    /// <summary>
    /// Represents a generic queue (FIFO) data structure implemented using a singly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the queue.</typeparam>
    public class CustomQueue<T> : IEnumerable<T> {

        /// <summary>
        /// Represents a node in the linked list, containing the value and a reference to the next node.
        /// </summary>
        private class Node {
            /// <summary>
            /// Gets or sets the value stored in the node.
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Gets or sets the reference to the next node.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Node"/> class with the specified value.
            /// </summary>
            /// <param name="value">The value to store in the node.</param>
            public Node(T value) { 
                Value = value; 
                Next = null; 
            }
        }

        /// <summary>
        /// The front node of the queue (oldest element).
        /// </summary>
        private Node front;

        /// <summary>
        /// The rear node of the queue (most recently added element).
        /// </summary>
        private Node rear;

        /// <summary>
        /// The current number of elements in the queue.
        /// </summary>
        private int count;

        /// <summary>
        /// Adds an element to the end of the queue.
        /// </summary>
        /// <param name="value">The value to enqueue.</param>
        public void Enqueue(T value) {
            var node = new Node(value);
            if (rear == null)
                front = rear = node; // Queue was empty; front and rear point to new node
            else {
                rear.Next = node;     // Link new node after current rear
                rear = node;          // Update rear to new node
            }
            count++; // Increment element count
        }

        /// <summary>
        /// Removes and returns the element at the front of the queue.
        /// </summary>
        /// <returns>The value of the dequeued element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when attempting to dequeue from an empty queue.</exception>
        public T Dequeue() {
            if (front == null)
                throw new InvalidOperationException("Dequeue from empty queue");
            var value = front.Value;   // Get value from front node
            front = front.Next;        // Move front to next node
            if (front == null)
                rear = null;           // Queue is now empty; reset rear
            count--;                   // Decrement element count
            return value;
        }

        /// <summary>
        /// Returns the element at the front of the queue without removing it.
        /// </summary>
        /// <returns>The value at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when peeking into an empty queue.</exception>
        public T Peek() {
            if (front == null)
                throw new InvalidOperationException("Peek on empty queue");
            return front.Value;
        }

        /// <summary>
        /// Removes all elements from the queue.
        /// </summary>
        public void Clear() {
            front = rear = null; // Reset both references
            count = 0;           // Reset count
        }

        /// <summary>
        /// Gets the number of elements contained in the queue.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>An enumerator for the queue.</returns>
        public IEnumerator<T> GetEnumerator() {
            var current = front;
            while (current != null) {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Returns a non-generic enumerator that iterates through the queue.
        /// </summary>
        /// <returns>An object that implements IEnumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
