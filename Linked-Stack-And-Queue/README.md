# 🧩 Lab 2 – Custom Linked-List Based Stack and Queue  

## 🔎 Overview  
This project implements custom **Stack** (LIFO) and **Queue** (FIFO) data structures using an internal **linked list** in **C#**. It demonstrates core **Object Oriented Programming (OOP)** concepts and integrates with C#’s native `foreach` iterator loop.  

Both data structures support required stack and queue operations, resizing when capacity is reached, and proper error handling for invalid operations.  

---

## ⚙️ Language and Version  
- **C# (C# 10 / .NET 6)**  

---

## 🚀 Features Implemented  

- **Stack (LIFO)** 🥞  
  - `Push(item)` – Add an element to the top of the stack  
  - `Pop()` – Remove and return the top element  
  - `Peek()` – View the top element without removal  
  - `Clear()` – Remove all elements  
  - `Count` – Return the number of stored elements  

- **Queue (FIFO)** 🚌  
  - `Enqueue(item)` – Add an element to the back of the queue  
  - `Dequeue()` – Remove and return the front element  
  - `Peek()` – View the front element without removal  
  - `Clear()` – Remove all elements  
  - `Count` – Return the number of stored elements  

- **Additional Requirements** 🧮  
  - Internal storage: **Custom Linked List**  
  - Resizing: Automatically **doubles capacity** when full  
  - Iteration: Supports `foreach` loop in C#  
  - Error handling: Throws an **InvalidOperationException** on illegal calls (`Pop`, `Dequeue`, or `Peek` when empty)  

---

## ▶️ How to Build and Run  

1. Make sure **.NET 8 SDK (or newer)** is installed.  
2. Clone or download the repository.  
3. Open the folder in a terminal and run:  

```
dotnet build
dotnet run
```  

This will build and run the demo `Program.cs` which tests both the Stack and Queue.  

---

## 📝 Assumptions and Notes  
- Both Stack and Queue start with an **initial capacity of 4** (can be modified).  
- When the capacity is reached, it **doubles automatically**.  
- Example: if capacity = 4 → reaches 5 elements → resizes to 8.  
- Iteration works naturally with C#’s `foreach` syntax.  
- Error cases trigger exceptions, rather than returning null or default values.
