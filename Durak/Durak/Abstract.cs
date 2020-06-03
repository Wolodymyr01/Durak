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
            GetCard = Game.FreeCards[id];
            Name = GetCard.ToString() + "_picture";
            Size = new Size(69, 105);
            Image = GetCard.GetImage;
            GetCard.picture = this;
            Click += new EventHandler((o, a) =>
            {
                MessageBox.Show(GetCard.ToString());
                if (active) SendToBack();
            });
        }
        public readonly int id;
        public bool active = false;
        public Card GetCard;
    }
}