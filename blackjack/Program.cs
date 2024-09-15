using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackjackGame game = new BlackjackGame();
            game.Play();
        }
    }
    
    class BlackjackGame
    {
        private Deck deck;
        private List<Card> playerHand;
        private List<Card> dealerHand;

        public BlackjackGame()
        {
            deck = new Deck();
            deck.Shuffle();
            playerHand = new List<Card>();
            dealerHand = new List<Card>();
        }

        public void Play()
        {
            // Initial Deal
            playerHand.Add(deck.DrawCard());
            playerHand.Add(deck.DrawCard());
            dealerHand.Add(deck.DrawCard());
            dealerHand.Add(deck.DrawCard());

            // Player's action
            bool playerStands = false;
            while (!playerStands && CalcHandValue(playerHand) <= 21)
            {
                Console.WriteLine($"Your hand: {HandtoString(playerHand)} (Total: {CalcHandValue(playerHand)})");
                Console.WriteLine("'hit' or 'stand'?");
                string choice = Console.ReadLine().ToLower();

                if (choice == "hit")
                {
                    playerHand.Add(deck.DrawCard());
                }
                else if (choice == "stand")
                {
                    playerStands = true;
                }
                else
                {
                    Console.WriteLine("Please type 'hit' or 'stand'.");
                }
            }

            // Dealer's action
            while (CalcHandValue(dealerHand) < 17)
            {
                dealerHand.Add(deck.DrawCard());
            }

            // Display hands
            Console.WriteLine($"Your hand: {HandtoString(playerHand)} (Total: {CalcHandValue(playerHand)})");
            Console.WriteLine($"Dealer hand: {HandtoString(dealerHand)} (Total: {CalcHandValue(dealerHand)})");

            // Determine the winner
            int playerTotal = CalcHandValue(playerHand);
            int dealerTotal = CalcHandValue(dealerHand);

            if (playerTotal > 21)
            {
                Console.WriteLine("Bust! Dealer wins.");
            }
            else if (dealerTotal > 21)
            {
                Console.WriteLine("Dealer bust! You win.");
            }
            else if (dealerTotal > playerTotal)
            {
                Console.WriteLine("Dealer wins.");
            }
            else if (playerTotal > dealerTotal)
            {
                Console.WriteLine("You win.");
            }
            else
            {
                Console.WriteLine("Tie.");
            }
        }

        private int CalcHandValue(List<Card> hand)
        {
            int total = 0;
            int aces = 0;

            foreach (var card in hand)
            {
                total += card.Value;
                if (card.Rank == "Ace")
                {
                    aces++;
                }
            }

            while (total > 21 && aces > 0)
            {
                total -= 10;
                aces--;
            }

            return total;
        }

        private string HandtoString(List<Card> hand)
        {
            List<string> cards = new List<string>();
            foreach (var card in hand)
            {
                cards.Add(card.ToString());
            }
            return string.Join(", ", cards);
        }
    }

    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            string[] suits = {"Hearts","Diamonds","Clubs","Spades"};
            string[] ranks = {"2","3","4","5","6","7","8","9","10","Jack","Queen","King"};

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    int value = rank switch
                    {
                        "Ace" => 11,
                        "King" => 10,
                        "Queen" => 10,
                        "Jack" => 10,
                        _ => int.Parse(rank)
                    };
                    cards.Add(new Card(suit, rank, value));
                }
            }
        }

        public void Shuffle()
        {
            for (int i=0; i<cards.Count; i++)
            {
                int j = random.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[i];
                cards[j] = temp;
            }
        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("The deck is empty!");
            }

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }

    class Card
    {
        public string Suit {get;}
        public string Rank {get;}
        public int Value {get;}

        public Card(string suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}