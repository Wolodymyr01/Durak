using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using static System.Math;

namespace Durak
{
    public class Randomizer
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return random.Next(min, max);
            }
        }
        public static bool MakeDecision(int procentYes)
        {
            var x = RandomNumber(0, 100);
            return (x < procentYes) ? true : false;
        }
    }
    public class CardPicture : PictureBox
    {
        public CardPicture(int id) : base()
        {
            this.id = id;
            GetCard = Game.FreeCards[id];
            Name = GetCard.ToString() + "_picture";
            Size = new Size(69, 105);
            image = GetCard.GetImage;
            Image = Image.FromFile("default.jpg");
            GetCard.picture = this;
            Click += new EventHandler((o, a) =>
            {
                if (Game.players[Game.ActivePlayer].cards.Count == 0
&& Game.FreeCards.Count == 0)
                {
                    Game.Win(Game.players[Game.ActivePlayer]);
                    return;
                }
                if (GetCard.player == Game.players[Game.ActivePlayer]) // my turn
                {
                    if (Card.playing.Count == 0)
                    {
                        Card.playing.Add(GetCard);
                        Game.players[Game.ActivePlayer].occupied.Remove(GetCard.occ);
                        Game.players[Game.ActivePlayer].cards.Remove(GetCard);
                        Location = new Point(Location.X, Location.Y + 
                            (int)Pow(-1, Game.ActivePlayer) * 120);
                        if (Game.players[Game.ActivePlayer].cards.Count == 0
&& Game.FreeCards.Count == 0)
                        {
                            Game.Win(Game.players[Game.ActivePlayer]);
                        }
                        Game.NextPlayer();
                    }
                    else
                    {
                        if (Game.players[Game.ActivePlayer].attacking) // could throw more cards
                        {
                            int c = Game.ActivePlayer + 1;
                            if (c >= Game.players.Length) c = 0;
                            if (Game.players[c].cards.Count > 0)
                            {
                                for (int i = 0; i < Card.playing.Count; i++)
                                {
                                    var item = Card.playing[i];
                                    if (item.face == GetCard.face && item != GetCard)
                                    {
                                        Card.playing.Add(GetCard);
                                        Game.players[Game.ActivePlayer].occupied.Remove(GetCard.occ);
                                        Game.players[Game.ActivePlayer].cards.Remove(GetCard);
                                        Location = new Point(Location.X, Location.Y +
                                            (int)Pow(-1, Game.ActivePlayer) * 90);
                                        if (Game.players[Game.ActivePlayer].cards.Count == 0
                                        && Game.FreeCards.Count == 0)
                                        {
                                            Game.Win(Game.players[Game.ActivePlayer]);
                                        }
                                        Game.NextPlayer();
                                    }
                                }
                            }
                        }
                        else // defender
                        {
                            for (int i = 0; i < Card.playing.Count; i++)
                            {
                                var item = Card.playing[i];
                                if (GetCard > item)
                                {
                                    Card.playing.Add(GetCard);
                                    Game.players[Game.ActivePlayer].occupied.Remove(GetCard.occ);
                                    Game.players[Game.ActivePlayer].cards.Remove(GetCard);
                                    Card.Beat(GetCard, item);
                                    Location = new Point(item.picture.Location.X,
                                        item.picture.Location.Y + (int)Pow(-1, Game.ActivePlayer) * 20);
                                    if (Game.players[Game.ActivePlayer].cards.Count == 0 && Game.FreeCards.Count == 0)
                                    {
                                        Game.Draw();
                                    }
                                    Game.NextPlayer(true);
                                }
                            }
                        }
                    }
                }
            });
        }
        public Image image;
        public readonly int id;
        public Card GetCard;
    }
}