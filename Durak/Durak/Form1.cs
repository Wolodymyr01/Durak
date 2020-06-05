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
            if (Card.playing.Count > 1)
            {
                foreach (var item in Card.playing)
                {
                    if (!item.IsBeaten) return;
                }
            }
            else return;
            for (int i = 0; i < Card.playing.Count; i++)
            {
                Card.playing[i].picture.Dispose();
            }
            Card.playing.Clear();
            foreach (var player in Game.players)
            {
                while (player.cards.Count < 6)
                {
                    try
                    {
                        player.PickCard();
                    }
                    catch (ApplicationException)
                    {
                        if (player.cards.Count == 0)
                        {
                            Game.NextPlayer();
                            if (Game.players[Game.ActivePlayer].cards.Count == 0) Game.Draw();
                            else Game.Win(player);
                            return;
                        }
                        else
                        {
                            Game.NextPlayer(true);
                            return;
                        }
                    }
                }
            }
            // maybe other actions
            Game.NextPlayer(true);
        }

        private void PickUpButton_Click(object sender, EventArgs e)
        {
            if (Card.playing.Count > 0)
            {
                foreach (var item in Card.playing)
                {
                    item.Restore();
                    try
                    {
                        Game.players[Game.ActivePlayer].PickCard(item);
                    }
                    catch (ApplicationException)
                    {
                        foreach (var player in Game.players)
                        {
                            if (player.cards.Count == 0)
                            {
                                Game.Win(player);
                                return;
                            }
                        }
                    }
                }
                Card.playing.Clear();
                for (int i = 0; i < Game.players.Length; i++)
                {
                    while (Game.players[i].cards.Count < 6)
                    {
                        try
                        {
                            Game.players[i].PickCard();
                        }
                        catch (ApplicationException)
                        {
                            foreach (var player in Game.players)
                            {
                                if (player.cards.Count == 0)
                                {
                                    Game.Win(player);
                                }
                                return;
                            }
                        }
                    }
                }
                Game.NextPlayer();
            }
        }
        public static Action<object, TextBox, TextBox, Label, Label, Panel, Control.ControlCollection, PictureBox>
            action = Action;
        public static void Action(object sender, TextBox Player1, TextBox Player2, 
            Label label2, Label label3, Panel panel1, Control.ControlCollection Controls, PictureBox box)
        {
            if (sender.GetType() != typeof(Player))
            {
                Game.players = new Player[2]; //{ new Player(Player1.Text, new Point(55, 10)),
                //new Player(Player2.Text, new Point(10, 250)) };
                var p1 = from players in Statistics.heroes
                         where players.Name == Player1.Text
                         select players;
                var p2 = from players in Statistics.heroes
                         where players.Name == Player2.Text
                         select players;
                Game.players[0] = (p1.Count() > 0) ? p1.First() : new Player(Player1.Text, new Point(55, 10));
                Game.players[1] = (p2.Count() > 0) ? p1.First() : new Player(Player2.Text, new Point(10, 250));
                if (p1.Count() > 0) Game.players[0].loc = new Point(55, 10);
                if (p2.Count() > 0) Game.players[1].loc = new Point(10, 250);
                Game.players[0].attacking = true;
                label2.Text = Game.players[0].Name;
                label3.Text = Game.players[1].Name;
                panel1.Dispose();
            }
            // draw deck
            Game.Trump = (Suit)Randomizer.RandomNumber(0, 3);
            box.Image = Image.FromFile($"{Game.Trump.ToString()}.jpg");
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
                }
            }
            foreach (var item in Game.players[Game.ActivePlayer].cards)
            {
                item.picture.Image = item.picture.image;
            }
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            Action(sender, Player1, Player2, label2, label3, panel1, Controls, SuitPicture);
            Game.Init(Player1, Player2, label2, label3, panel1, Controls, SuitPicture);
        }
    }
}
