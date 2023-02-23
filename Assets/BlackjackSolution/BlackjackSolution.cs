using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class BlackjackSolution : MonoBehaviour
{
    public TextMeshProUGUI deckText, playerHandText;

    enum Suit { Hearts, Spades, Clubs, Diamonds }

    private class MyCard
    {
        public string name;

        /// <summary>
        /// The score this card is worth in blackjack.
        /// </summary>
        public int value;

        public Suit suit;

        public MyCard(string name, int value, Suit suit)
        {
            this.name = name;
            this.value = value;
            this.suit = suit;
        }

        public override string ToString()
        {
            return $"{name} of {suit}";
        }
    }

    private class Hand
    {
        private List<MyCard> hand = new List<MyCard>();

        public void AddCard(MyCard card)
        {
            hand.Add(card);
        }

        public int Score()
        {
            int score = 0;

            foreach (MyCard card in hand)
            {
                int value = card.value;

                if (value == 1)
                    value = 11;

                score += value;
            }


            foreach (MyCard card in hand)
            {
                if (score > 21)
                {
                    if (card.value == 1)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
        }

        public override string ToString()
        {
            string output = "";

            foreach (MyCard card in hand)
            {
                output += card;
                output += "\n";
            }

            return output;
        }
    }

    List<MyCard> deck = new List<MyCard>();
    Hand playerHand = new Hand();

    private void Awake()
    {
        Hand testHand = new Hand();
        testHand.AddCard(new MyCard("Five", 5, Suit.Clubs));
        testHand.AddCard(new MyCard("Ace", 1, Suit.Clubs));

        Debug.Log($"Score of hand is {testHand.Score()}. Expected score is 16.");

        Hand testHand2 = new Hand();
        testHand2.AddCard(new MyCard("Jack", 10, Suit.Clubs));
        testHand2.AddCard(new MyCard("Seven", 7, Suit.Clubs));
        testHand2.AddCard(new MyCard("Ace", 1, Suit.Clubs));

        Debug.Log($"Score of hand is {testHand2.Score()}. Expected score is 18.");

        //List<string> names = new List<string>()
        //{
        //    "Ace",
        //    "Two",
        //    "Three",
        //    "Four",
        //    "Five",
        //    "Six",
        //    "Seven",
        //    "Eight",
        //    "Nine",
        //    "Ten",
        //    "Jack",
        //    "Queen",
        //    "King"
        //};

        //for (int s = 0; s < 4; s++)
        //{
        //    for (int v = 0; v < 13; v++)
        //    {
        //        Suit suit = (Suit)s;

        //        int score;

        //        if (v < 10)
        //        {
        //            score = v + 1;
        //        }
        //        else
        //        {
        //            score = 10;
        //        }

        //        MyCard card = new MyCard(names[v], score, suit);

        //        deck.Add(card);
        //    }
        //}

        //List<MyCard> shuffledDeck = new List<MyCard>();

        //while (deck.Count > 0)
        //{
        //    int selectedValue = Random.Range(0, deck.Count);
        //    shuffledDeck.Add(deck[selectedValue]);
        //    deck.RemoveAt(selectedValue);
        //}

        //deck = shuffledDeck;

        //PrintDeck();

        //playerHand.AddCard(DealFromTop());
        //playerHand.AddCard(DealFromTop());

        //playerHandText.text = playerHand.ToString();

        //int playerScore = playerHand.Score();
    }

    private MyCard DealFromTop()
    {
        MyCard card = deck[0];
        deck.RemoveAt(0);

        return card;
    }

    private void PrintDeck()
    {
        string output = "";

        int newline = 0;

        foreach (MyCard card in deck)
        {
            output += card;

            newline++;

            if (newline > 1)
            {
                newline = 0;
                output += "\n";
            }
            else
            {
                output += "\t\t\t";
            }
        }

        deckText.text = output;
    }
}
