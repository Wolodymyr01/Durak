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
    }
}
