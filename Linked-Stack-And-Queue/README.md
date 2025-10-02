<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="content-type" content="text/html; charset=utf-8"/>
	<title></title>
	<meta name="generator" content="LibreOffice 25.8.1.1 (Linux)"/>
	<meta name="created" content="00:00:00"/>
	<meta name="changed" content="2025-10-02T09:11:18.994764102"/>
	<style type="text/css">
		@page { size: 8.5in 11in; margin-left: 0.79in; margin-right: 0.39in; margin-top: 0.39in; margin-bottom: 0.39in }
		p { margin-bottom: 0.1in; line-height: 115%; background: transparent }
	</style>
</head>
<body lang="en-US" link="#000080" vlink="#800000" dir="ltr"><p style="line-height: 100%; margin-bottom: 0in">
# 📚 CSCI 2210 – Data Structures ## 🧩 Lab 2 – Custom
Linked-List Based Stack and Queue ### 🔎 Overview This project
implements custom **Stack** (LIFO) and **Queue** (FIFO) data
structures using an internal **linked list** in **C\#**. It
demonstrates core **Object Oriented Programming (OOP)** concepts and
integrates with C\#’s native `foreach` iterator loop. Both data
structures support required stack and queue operations, resizing when
capacity is reached, and proper error handling for invalid
operations. *** ### ⚙️ Language and Version - **C\# (C\# 10 /
.NET 6)** *** ### 🚀 Features Implemented - **Stack (LIFO)** 🥞 -
`Push(item)` – Add an element to the top of the stack - `Pop()` –
Remove and return the top element - `Peek()` – View the top element
without removal - `Clear()` – Remove all elements - `Count` –
Return the number of stored elements - **Queue (FIFO)** 🚌 -
`Enqueue(item)` – Add an element to the back of the queue -
`Dequeue()` – Remove and return the front element - `Peek()` –
View the front element without removal - `Clear()` – Remove all
elements - `Count` – Return the number of stored elements -
**Additional Requirements** 🧮 - Internal storage: **Custom Linked
List** - Resizing: Automatically **doubles capacity** when full -
Iteration: Supports `foreach` loop in C\# - Error handling: Throws an
**InvalidOperationException** on illegal calls (`Pop`, `Dequeue`, or
`Peek` when empty) *** ### ▶️ How to Build and Run 1. Make sure
**.NET 6 SDK (or newer)** is installed. 2. Clone or download the
repository. 3. Open the folder in a terminal and run: ```bash dotnet
build dotnet run ``` This will build and run the demo `Program.cs`
which tests both the Stack and Queue. *** ### 📝 Assumptions and
Notes - Both Stack and Queue start with an **initial capacity of 4**
(can be modified). - When the capacity is reached, it **doubles
automatically**. - Example: if capacity = 4 → reaches 5 elements →
resizes to 8. - Iteration works naturally with C\#’s `foreach`
syntax. - Error cases trigger exceptions, rather than returning null
or default values.</p>
</body>
</html>