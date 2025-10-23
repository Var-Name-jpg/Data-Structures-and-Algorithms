# ⚓ Project 1 – Battleship  

## 🔎 Overview  
This project refreshes core Object-Oriented Programming concepts, file I/O, regex, and string handling by implementing a console-driven Battleship game in **C# (.NET 8)**. Players load ships from a file, enter coordinate commands to fire shots, and the game reports hits, misses, and tracks ship health until all ships are sunk.  

---

## ⚙️ Language and Version  
- **C# (C# 12 / .NET 8.0)**  
- Developed using Visual Studio 2022  

---

## 🚀 Features Implemented  

- **Ships:**  
  - Each ship subclass (Carrier, Battleship, Destroyer, Submarine, PatrolBoat) defines length and position on a 10x10 board.  
  - Ships track damage as unique hits, ignoring repeated hits on the same coordinate.  
  - Provides health status and human-readable ship info (name, length, position, direction, health, alive/dead).  

- **Ship Factory:**  
  - Parses, normalizes, and validates ship data from text input lines or files.  
  - Accepts minor input variations (e.g., “Patrol Boat” vs “PatrolBoat”, “H”/“V” for directions).  
  - Validates syntactic format and that ships fit within board bounds before construction.  
  - Constructs correct ship subclass with normalized data.  

- **Game Driver:**  
  - Loads ships from a file path provided as a command-line argument or user prompt.  
  - Runs a command loop until all ships are sunk or `exit` command is entered.  
  - Commands supported:  
    - `info` - Displays status lines for all ships.  
    - `X,Y` - Fires at coordinates; reports hit, miss, and sinking.  
    - `exit` - Quits the application.  
    - Any other input returns “Command not recognized.”  

---

## 📁 File Input Format  
- Each ship specified on its own line, format:  
  ```
  <ShipType>; (<X>,<Y>); <Direction>  
  ```  
- Comments start with `#` and blank lines are ignored.  
- Example lines accepted:  
  ```
  Destroyer; (2,5); Horizontal  
  Patrol Boat; (4,7); V  
  ```  

---

## ▶️ How to Build and Run  

1. Ensure **.NET 8 SDK** and **Visual Studio 2022** are installed.  
2. Open the project folder in a terminal or Visual Studio.  
3. Build the project:  
   ```
   dotnet build
   ```  
4. Run the game executable, optionally passing the fleet file path as an argument:  
   ```
   dotnet run -- path/to/fleet.txt
   ```  
5. If no argument is passed, the program prompts for a file path.  

---

## 📝 Assumptions and Notes  
- The board is fixed size 10×10 with coordinates from (0,0) to (9,9).  
- The ship classes do not handle file parsing or bounds themselves; parsing and validation happen in the Ship Factory.  
- Ship health models length minus unique hits; repeated hits on the same coordinate do not decrease health again.  
- Coordinates and directions are normalized and validated strictly before ship creation.  
- Overlapping or duplicate ships are not checked and are out of scope.  
- The console interface is simple, guiding the user with prompt messages and error handling.  

---

## 🧩 Classes Overview  

| Class           | Description                                      |
|-----------------|------------------------------------------------|
| `Coord2D`       | Represents board coordinates, supports parsing and equality. |
| `DirectionType` | Enum: `Horizontal` or `Vertical` orientation.    |
| `IHealth`       | Interface for health-related properties and methods. |
| `IInformatic`   | Interface returning human-readable status info. |
| `Ship`          | Abstract base: manages points, damage, health, and reporting. |
| `Carrier`       | Ship subclass with length 5.                     |
| `Battleship`    | Ship subclass with length 4.                     |
| `Destroyer`     | Ship subclass with length 3.                     |
| `Submarine`     | Ship subclass with length 3.                     |
| `PatrolBoat`    | Ship subclass with length 2.                     |
| `ShipFactory`   | Parses, validates, normalizes input lines and creates ships. |
| `Game`          | Manages the fleet, handles firing logic and win conditions. |
| `Program`       | Console driver implementing main game loop and user interaction. |

---

Enjoy commanding your fleet and sinking enemy ships! 🚢🎯
