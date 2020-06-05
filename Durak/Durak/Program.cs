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
        public Player player;
        public int occ;
        public Image GetImage { get; private set; }
        public bool IsBeaten { get; private set; } = false;
        public static void Beat(Card who, Card whom)
        {
            who.IsBeaten = true;
            whom.IsBeaten = true;
        }
        public void Restore()
        {
            IsBeaten = false;
        }
        public int CompareTo(object obj)
        {
            var acard = obj as Card;
            int x = 0, y = 0;
            if (suit == Game.Trump) x += 130; else x += 20 * ((int)suit + 1);
            if (acard.suit == Game.Trump) y += 130; else y += 20 * ((int)acard.suit + 1);
            x += (int)face;
            y += (int)acard.face;
            return x - y;
        }
        public override string ToString()
        {
            return suit.ToString() + " " + face.ToString();
        }
        public override int GetHashCode()
        {
            return suit.GetHashCode() - face.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return suit.Equals((obj as Card).suit) && face.Equals((obj as Card).face);
        }
        public static bool operator ==(Card A, Card B)
        {
            return A.Equals(B);
        }
        public static bool operator !=(Card A, Card B)
        {
            return !A.Equals(B);
        }
        public static bool operator >(Card A, Card B)
        {
            if (A.suit == B.suit) return A.face > B.face;
            if (A.suit == Game.Trump) return true;
            return false;
        }
        public static bool operator <(Card A, Card B)
        {
            if (A.suit == Game.Trump)
            {
                if (B.suit == Game.Trump)
                {
                    return A.face < B.face;
                }
                return false;
            }
            else
            {
                if (B.suit == Game.Trump)
                {
                    return true;
                }
                if (A.suit < B.suit) return true;
                else if (A.suit > B.suit) return false;
                return A.face < B.face;
            }
        }
    }
    [Serializable]
    public class Player : IComparable
    {
        public Player(string name, Point Loc)
        {
            Name = name;
            Loc.X -= 69;
            loc = Loc;
        }
        public readonly List<Card> cards = new List<Card>();
        public Result statistics = new Result();
        internal Point loc;
        internal List<int> occupied = new List<int>();
        public bool attacking = false;
        public string Name { get; protected set; }
        public int CompareTo(object obj)
        {
            return (int)(statistics.WinPercent - (obj as Player).statistics.WinPercent);
        }
        public void PickCard(Card card = null)
        {
            if (card is null)
            {
                var n = Randomizer.RandomNumber(0, Game.FreeCards.Count);
                if (Game.FreeCards.Count > 0)
                {
                    (Game.FreeCards[n].picture.Location,
                        Game.FreeCards[0].picture.Location) = (Game.FreeCards[0].picture.Location,
                        Game.FreeCards[n].picture.Location);
                    cards.Add(Game.FreeCards[n]);
                    Game.FreeCards.RemoveAt(n);
                }
                else throw new ApplicationException("Must be handled");          
            }
            else cards.Add(card);
            // graphical interaction
            int i = cards.Count - 1;
            int x = loc.X;
            while (occupied.Contains(x += cards[0].picture.Width)) ;
            cards[i].picture.Location = new Point(x, loc.Y);
            occupied.Add(x);
            cards[i].occ = x;
            cards[i].player = this;
            cards.Sort();
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
        /// <summary>
        /// Shows whose turn is that now
        /// </summary>
        public static int ActivePlayer { get; private set; } = 0;
        public static void NextPlayer(bool defend = false)
        {
            foreach (var item in players[ActivePlayer].cards)
            {
                item.picture.Image = Image.FromFile("default.jpg");
            }
            players[ActivePlayer].attacking = !defend;
            if (++ActivePlayer >= players.Length) ActivePlayer = 0;
            players[ActivePlayer].attacking = defend;
            foreach (var item in players[ActivePlayer].cards)
            {
                item.picture.Image = item.picture.image;
            }
        }
        public static object[] array;
        public static void Init(params object[] args)
        {
            array = args;
        }
        public static void NewGame()
        {
            FreeCards = Card.Deck.ToList();
            Durak.action(players[0], (TextBox)array[0], (TextBox)array[1], (Label)array[2], (Label)array[3], 
                (Panel)array[4], (Control.ControlCollection)array[5], (PictureBox)array[6]);
            ActivePlayer = 0;
        }
        public static void Win(Player player)
        {
            player.statistics.wins++;
            NextPlayer();
            var loser = players[ActivePlayer];
            loser.statistics.loses++;
            foreach (var item in players) Statistics.heroes.Add(item);
            Statistics.Save();
            MessageBox.Show($"{player} wins! Congratulations! {loser}, be strong, try again!");
            NewGame();
        }
        public static void Draw()
        {
            foreach (var item in players)
            {
                item.statistics.draws++;
                Statistics.heroes.Add(item);
            }
            Statistics.Save();
            MessageBox.Show($"Draw! Don't stop!");
            NewGame();
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
