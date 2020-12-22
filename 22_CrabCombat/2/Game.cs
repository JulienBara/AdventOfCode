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
        }

        public Queue<long> Player1 { get; set; }
        public Queue<long> Player2 { get; set; }

        public int ReturnWinner()
        {
            while(Player1.Count > 0 && Player2.Count > 0)
            {
                var number1 = Player1.Dequeue();
                var number2 = Player2.Dequeue();
                if(number1 > number2)
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