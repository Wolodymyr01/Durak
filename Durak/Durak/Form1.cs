using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Durak
{
    public partial class Durak : Form
    {
        public Durak()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            foreach (var player in Game.players)
            {
                while (player.cards.Count < 6)
                {
                    player.PickCard();
                }
            }
            // maybe other actions
            foreach (var item in Card.playing)
            {
                item.Restore();
            }
            Card.playing.Clear();
            Game.NextPlayer();
        }

        private void PickUpButton_Click(object sender, EventArgs e)
        {
            foreach (var item in Card.playing)
            {
                item.Restore();
            }
            Game.players[Game.ActivePlayer].cards.AddRange(Card.playing);
            Card.playing.Clear();
            Game.NextPlayer();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Game.players = new Player[2] { new Player(Player1.Text), new Player(Player2.Text) };
            Game.players[0].myTurn = true;
            label2.Text = Game.players[0].Name;
            label3.Text = Game.players[1].Name;
            panel1.Dispose();
            // draw deck
            CardPicture[] pics = new CardPicture[36];
            for (int i = 0; i < pics.Length; i++)
            {
                pics[i] = new CardPicture(i);
                Controls.Add(pics[i]);
                pics[i].Location = new Point(420 + 1 * i, 100 + 1 * i);
            }
            for (int i = 0; i < Game.players.Length; i++)
            {
                while (Game.players[i].cards.Count < 6)
                {
                    Game.players[i].PickCard();
                    MessageBox.Show(Game.players[i].cards.Count.ToString());
                }
            }
        }
    }
}
