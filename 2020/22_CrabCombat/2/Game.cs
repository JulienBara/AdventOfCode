using System;
using System.Collections.Generic;
using System.Linq;

namespace _22_CrabCombat_2
{
    public class Game
    {
        public Game(Queue<long> player1, Queue<long> player2)
        {
            Player1 = player1;
            Player2 = player2;
            ExistedRounds = new Dictionary<(string, string), bool>();
        }

        public Queue<long> Player1 { get; set; }
        public Queue<long> Player2 { get; set; }
        public Dictionary<(string,string), bool> ExistedRounds { get; set; } // (deck1, deck2) with deck1 = "card1,card2,card3"

        public int ReturnWinner()
        {
            while(Player1.Count > 0 && Player2.Count > 0)
            {
                if(ExistedRounds.ContainsKey((string.Join(',',Player1),string.Join(',',Player2))))
                {
                    return 1;
                }
                ExistedRounds.Add((string.Join(',',Player1),string.Join(',',Player2)), true);

                var number1 = Player1.Dequeue();
                var number2 = Player2.Dequeue();

                int winner;

                if(number1 <= Player1.Count && number2 <= Player2.Count)
                {
                    var subPlayer1 = new Queue<long>(Player1.Take((int)number1));
                    var subPlayer2 = new Queue<long>(Player2.Take((int)number2));
                    var game = new Game(subPlayer1, subPlayer2);
                    winner = game.ReturnWinner();
                }
                else
                {
                    winner = number1 > number2 ? 1 : 2;
                }

                if (winner == 1)
                {
                    Player1.Enqueue(number1);
                    Player1.Enqueue(number2);
                } 
                else 
                {
                    Player2.Enqueue(number2);
                    Player2.Enqueue(number1);
                }
            }
            return Player2.Count == 0 ? 1 : 2;
        }
    }
}