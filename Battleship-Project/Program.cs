using System;
using System.Collections.Generic;

namespace BattleshipFactory {
    /// <summary>
    /// Entry point for the Battleship game application.
    /// Handles user input, file parsing, ship creation, and game loop.
    /// </summary>
    public class Program {
        /// <summary>
        /// Main method that initializes the game, processes input, and runs the game loop.
        /// </summary>
        /// <param name="args">Command-line arguments. Use "-f [filepath]" to load ships from a file.</param>
        public static void Main(String[] args) {
            bool fileProvided = false;
            string filePath = string.Empty;

            ShipFactory shipFact = new ShipFactory();
            List<Ship> fleet = new List<Ship>();
            Game game = new Game(fleet);

            // Check for command line arguments
            if (args.Length >= 2) {
                if (args[0] == "-f") {
                    filePath = args[1];
                    fleet = shipFact.ParseShipFile(filePath);
                }
            } else {
                string input1 = string.Empty;
                string tempPath = string.Empty;
                string line = string.Empty;

                // Interactive input if no file is provided
                while (true) {
                    try {
                        Console.WriteLine("No file supplied. Would you like to enter a directory? (y, n)");
                        input1 = Console.ReadLine();
                        if (input1.ToLower() == "y") {
                            Console.WriteLine("\nPlease enter the path to your ship file:");
                            tempPath = Console.ReadLine();

                            if (File.Exists(tempPath)) {
                                filePath = tempPath;
				fleet = shipFact.ParseShipFile(filePath);
                                break;
                            } else {
                                Console.WriteLine("Cannot find file.. Please try again...");
                            }

                        } else if (input1.ToLower() == "n") {
                            Console.Clear();
                            Console.WriteLine("Please enter your ship string. Enter 'e' when finished.");
                            Console.WriteLine("Format: 'ShipType, ShipLength, ShipDirection(h,v), startPosX, startPosY'");

                            while (true) {
                                line = string.Empty;

                                Console.Write(">> ");
                                input1 = Console.ReadLine();

                                if (input1.ToLower() == "e") { break; }

                                try {
                                    fleet.Add(shipFact.ParseShipString(input1, fleet));
                                } catch (Exception ex) {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;
                        }   

                    } catch {
                        Console.WriteLine("Invalid Response...\n");
                    }
                }
            }

            Console.Clear();
            
            // Display ship information
            foreach (Ship ship in fleet) {
                ship.Points = shipFact.GenerateShipPoints(ship.Position, ship.Direction, ship.Length);
                Console.WriteLine(ship.GetInfo());
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            string input = string.Empty;
            Coord2D tempCoord = new Coord2D(0, 0);
            bool _gameOver = false;

            // Main game loop
            while (!_gameOver) {
                try {
                    Console.Clear();
                    Console.WriteLine("Input a command (info, (x,y), exit)...");
                    Console.Write(">> ");
                    input = Console.ReadLine();

                    if (input.ToLower() == "exit") { break; }
                    else if (input.ToLower() == "info") {
                        foreach (Ship ship in fleet) {
                            Console.WriteLine(ship.GetInfo());
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    } else if (tempCoord.TryParse(input, out Coord2D hitCoord)) {
                        if (!fleet.Any(ship => ship.TakeDamage(hitCoord))) {
                            Console.WriteLine("Miss!");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    } else {
                        throw new Exception("Invalid Command! Please try again...");
                    }

                    if (game.AllSunk()) {
                        Console.WriteLine("You Won!");
                        break;
                    }

                    for (int i = 0; i < fleet.Count; i++) {
                        if (fleet[i].IsDead()) {
                            Console.WriteLine($"{fleet[i].ShipType} Sunk!");
                            fleet.RemoveAt(i);
                        }
                    }
                    
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Program terminated. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
