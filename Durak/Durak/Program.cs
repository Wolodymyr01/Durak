using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Drawing;

namespace Durak
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Statistics.heroes = (File.Exists("Statistics.xml")) ? new XmlSerializer(typeof(SortedSet<Player>))
                .Deserialize(new FileStream("Statistics.xml", FileMode.Open)) as SortedSet<Player> 
                : new SortedSet<Player>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Durak());
        }
    }
    public enum Suit : byte
    {
        clovers, diamonds, hearts, pikes
    }
    public enum Face : byte
    {
        six = 6, seven, eight, nine, ten, jack, queen, king, ace
    }
    public class Card : IComparable
    {
        public Card(Suit s, Face f)
        {
            suit = s; face = f;
            string str = (((byte)f > 10)? char.ToUpper(f.ToString()[0]).ToString() : ((byte)f).ToString()) 
                + char.ToUpper(s.ToString()[0]) + ".jpg";
            if (str[1] == 'P') str = str.Remove(1, 1).Insert(1, "S");
            GetImage = Image.FromFile(str);
        }
        public static Card[] Deck
        {
            get
            {
                Card[] cards = new Card[36];
                int k = -1;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 6; j < 15; j++)
                    {
                        cards[++k] = new Card((Suit)i, (Face)j);
                    }
                }
                return cards;
            }
        }
        public static List<Card> playing = new List<Card>();
        public readonly Suit suit;
        public readonly Face face;
        public CardPicture picture;
        public Image GetImage { get; private set; }
        public bool IsBeaten { get; private set; } = false;
        public static void Beat(Card who, Card whom)
        {
            who.IsBeaten = true;
            whom.IsBeaten = true;
        }
        public void Restore()
        {
            IsBeaten = true;
        }
        public int CompareTo(object obj)
        {
            var acard = obj as Card;
            if (this > acard) return 1;
            else if (this == acard) return 0;
            else return -1;
        }
        public override string ToString()
        {
            return suit.ToString() + " " + face.ToString();
        }
        public override int GetHashCode()
        {
            return suit.GetHashCode() - face.GetHashCode();
        }
        public static bool operator >(Card A, Card B)
        {
            if (A.suit == Game.Trump)
            {
                if (B.suit == Game.Trump)
                {
                    return A.suit > B.suit;
                }
                return true;
            }
            else
            {
                if (B.suit == Game.Trump)
                {
                    return false;
                }
                return A.suit > B.suit;
            }
        }
        public static bool operator <(Card A, Card B)
        {
            if (A.suit == Game.Trump)
            {
                if (B.suit == Game.Trump)
                {
                    return A.suit < B.suit;
                }
                return false;
            }
            else
            {
                if (B.suit == Game.Trump)
                {
                    return true;
                }
                return A.suit < B.suit;
            }
        }
    }
    [Serializable]
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }
        public readonly List<Card> cards = new List<Card>();
        public bool myTurn = false;
        public Result statistics;
        public string Name { get; protected set; }
        public void PickCard()
        {
            var n = Randomizer.RandomNumber(0, Game.FreeCards.Count);
            cards.Add(Game.FreeCards[n]);
            Game.FreeCards.RemoveAt(n);
            // graphical interaction
            cards.Sort();
            int i = cards.Count - 1;
            cards[i].picture.Location = (this == Game.players[0]) ? new Point(55 + i * 10, 10)
                : new Point(10 + i * 10, 250);
            cards[i].picture.active = true;
        }
        public override string ToString()
        {
            return Name;
        }
        public static bool operator >(Player A, Player B)
        {
            return A.statistics.WinPercent > B.statistics.WinPercent;
        }
        public static bool operator <(Player A, Player B)
        {
            return A.statistics.WinPercent > B.statistics.WinPercent;
        }
    }
    public static class Game
    {
        /// <summary>
        /// Shows cards lefted in the deck
        /// </summary>
        public static List<Card> FreeCards = Card.Deck.ToList();
        public static Player[] players;
        public static Suit Trump = (Suit)Randomizer.RandomNumber(0, 3);
        public static Card[] Deck = Card.Deck;
        /// <summary>
        /// Shows whose turn is that now
        /// </summary>
        public static int ActivePlayer { get; private set; } = 0;
        public static void NextPlayer()
        {
            if (++ActivePlayer >= players.Length) ActivePlayer = 0;
        }
        public static void NewGame()
        {
            FreeCards = Card.Deck.ToList();
            Trump = (Suit)Randomizer.RandomNumber(0, 3);
            ActivePlayer = 0;
        }
    }
    [Serializable]
    public struct Result
    {
        public uint wins, loses, draws;
        public uint Games
        {
            get
            {
                return wins + loses + draws;
            }
        }
        public float WinPercent
        {
            get
            {
                return (float)wins / Games;
            }
        }
    }
    public static class Statistics
    {
        public static SortedSet<Player> heroes; // check if the file exists, if not create a new list 
        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SortedSet<Player>));
            FileStream fs = new FileStream("Statistics.xml", FileMode.OpenOrCreate);
            serializer.Serialize(fs, heroes);
            fs.Close();
        }
    }
}
