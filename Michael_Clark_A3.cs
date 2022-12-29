using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ultimatum_game
{
    internal class UltimatumGame
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            
            gm.GameLoop();
        }
    }
    internal class GameManager
    {
        private char[,] _board = new char[2, 2];
        public void GameLoop()
        {


            Console.WriteLine("The Ultimatum Game\n" +
                "You make an offer to a responder to split $100. \n" +
                "If the responder accepts the offer, the money is split per the proposal. \n" +
                "If the responder rejects the offer, both players recieve nothing. \n" +
                "Your goal is to make $100 with as few offers as possible. \n");

            Console.WriteLine("Write 0 to play against a computer and write 1 for the computer to play the computer. \n");
            var playAgain = "N";
            var gameMode = Console.ReadLine();
            do
            {
                while (gameMode != "0" && gameMode != "1")
                {
                    Console.WriteLine("Write 0 to play against a computer and write 1 for the computer to play the computer. \n");
                    var gameModeNew = Console.ReadLine();
                    gameMode = gameModeNew;
                }
                if (gameMode == "0")
                    HumanVsComputer();
                if (gameMode == "1")
                    ComputerVsComputer();
                Console.WriteLine("If you want to quit write N anything else to keep playing");
                var playAgainNew = Console.ReadLine();
                playAgain = playAgainNew;

            } while (playAgain != "N");
            Console.Clear();




            

        }
    
        private void HumanVsComputer()
        {
            int rounds = 2;
            int bank = 0;
            int goal = 100;
            string name;
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
            
            
                for (int i = 0; i < rounds++; i++)
                {
                    
                    Console.WriteLine("\nRound " + (i + 1));
                    Console.WriteLine("Enter an integer from 0 to 100");
                    var offer = Convert.ToInt32(Console.ReadLine());
                    Random random = new Random();
                    int computerRandomReject = random.Next(0, 100);
                    int reject = computerRandomReject;
                    
                    while (true)
                    {
                        if (reject > offer)
                        {
                            Console.WriteLine("The responder has rejected the offer. \n");
                            break;
                        }
                        else if (reject < offer)
                        {
                            Console.WriteLine("The offer has been accepted. \n");
                            bank += goal - offer;
                            Console.WriteLine(name + " now has $" + bank + ". \n");
                            break;
                        }
                     
                    }
                    if (bank >= goal)
                    {
                        Console.WriteLine(name + " gained $" + bank + " in " + rounds + " turns. \n");
                        break;
                    }
                    
                }
            

            
            
        }

        private void ComputerVsComputer()
        {
            int rounds = 1;
            Random random = new Random();
            var bank = 0;
            var goal = 100;
            
                
                    for (int i = 0; i < rounds; i++)
                    {

                        
                        

                        while (true)
                        {
                            int computerRandomOffer = random.Next(0, 100);
                            var offer = computerRandomOffer;
                            int computerRandomReject = random.Next(0, 100);
                            var reject = computerRandomReject;
                            if (reject > offer)
                            {
                                Console.WriteLine("The computer has offered $" + offer + " to the responder. \n");
                                Console.WriteLine("The responder has rejected the offer.");
                                
                            }
                            else if (reject == offer)
                            {
                                Console.WriteLine("The computer has offered $" + offer + " to the responder. \n");
                                Console.WriteLine("The responder has rejected the offer.");
                                
                            }
                            else if (reject < offer)
                            {
                                Console.WriteLine("The computer has offered $" + offer + " to the responder. \n");
                                Console.WriteLine("The responder has accepted the offer. \n");
                                bank += (goal - offer);
                                Console.WriteLine("The Computer now has $" + bank + " in its acccount.");
                                
                            }
                            if(bank >= goal)
                            {
                                break;
                                
                            }
                        }
                    }
                
            
            
            
            
        
        }

        internal class Player
        {
            public string Name { get; set; }

            public Player(string name)
            {
                Name = name;
            }
        }

        internal class HumanPlayer : Player
        {
            public HumanPlayer(string name) : base(name) { }
        }

        internal class Responder : Player
        {
            public Responder(string name) : base(name) { }
        }

        internal class MonteCarloSimulator : Player
        {
            public MonteCarloSimulator(string name) : base(name) { }
          
        }
    }
}