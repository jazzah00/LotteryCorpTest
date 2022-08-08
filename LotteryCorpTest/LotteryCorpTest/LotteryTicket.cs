using System;
using System.Collections.Generic;

namespace LotteryCorpTest {
    public class LotteryTicket {
        public List<List<int>> GameTicketNumbers { get; set; }
        private List<string> GameTickets;

        public LotteryTicket() {
            // Initialise class variables
            GameTicketNumbers = new List<List<int>>();
            GameTickets = new List<string>();
        }
        public LotteryTicket(int games) : this() {
            // Generate list of game tickets for provided number of games
            GenerateTickets(games);
        }

        // Public Function: to generate a quick pick print out
        public string GetLotteryTicketPrintOut(int games) {
            // Define return variable
            string printOut = "";
            // Generate a list of Game tickets for the number provided
            GenerateTickets(games);
            // Loop through generated tickets and add index
            for (int i = 0; i < GameTickets.Count; i++) {
                printOut += $"Pick #{(i + 1)}: {GameTickets[i]}\n";
            }
            return printOut;
        }

        // Private Function: to generate a list of game tickets and set against game tickets string list
        private void GenerateTickets(int games) {
            // Define list of tickets 
            GameTickets = new List<string>();
            // Until the number of game tickets have been generated, do the following
            do {
                // Define next ticket to add
                string ticket = GenerateTicket(out List<int> gameNumbers);
                // Check if the next ticket exists in the list (prevent duplicates)
                if (!GameTickets.Contains(ticket)) {
                    // If the next ticket does not exist in the list, add it
                    GameTickets.Add(ticket);
                    GameTicketNumbers.Add(gameNumbers);
                }
            } while (GameTickets.Count < games);
        }

        // Private Function: to generate a list of 7 random game numbers between 1 & 47
        private string GenerateTicket(out List<int> numbers) {
            // Define random number generator
            Random random = new Random();
            // Define list of game numbers
            numbers = new List<int>();
            // Until 7 random numbers have been added to the game numbers list, do the following
            do {
                // Define next random number
                int next = random.Next(1, 47);
                // Check if the next random number exists (prevent duplicates)
                if (!numbers.Contains(next)) {
                    // If the next random number does not exist in the list, add it
                    numbers.Add(next);
                }
            } while (numbers.Count < 7);
            // Return the list of random numbers for the game
            return string.Join(" ", numbers);
        }
    }
}
