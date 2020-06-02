using System;
using System.Windows.Forms;
using System.Drawing;

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
            Name = GetCard.ToString() + "_picture";
            Size = new Size(40, 60);
            Image = GetCard.GetImage;
        }
        public readonly int id;
        public Card GetCard { get { return Game.FreeCards[id]; } }
    }
}