using System.Windows.Forms;

namespace DesktopKonata.Forms
{
    public partial class Menu : Form
    {
        private NotifyIcon _notifyIcon = new()
        {
            Visible = true,
            Icon = Properties.Resources.KonataIco,
            Text = "Konata is here!",
            BalloonTipIcon = ToolTipIcon.Info,
            BalloonTipTitle = "Hey",
            BalloonTipText = "I`ll be here!"
        };
        private CharacterWindow _characterWindow;

        public Menu()
        {
            InitializeComponent();
            _notifyIcon.MouseClick += NotifyIcon_MouseClick!;
            _characterWindow = new();
        }

        private void Menu_Load(object sender, EventArgs args)
        {
            _characterWindow.Show();
        }

        private void KonataLoveToolStripMenuItem_Click(object sender, EventArgs args)
        {
            _characterWindow.AddCharacter(Properties.Resources.KonataLoveDancingGif);
        }

        private void HideInTray()
        {
            Hide();
            _notifyIcon.ShowBalloonTip(500);
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs args)
        {
            if (args.CloseReason == CloseReason.UserClosing)
            {
                args.Cancel = true;
                HideInTray();
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs args)
        {
            WindowState = FormWindowState.Normal;
            Show();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideInTray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _characterWindow.GetCharacterPictureBox().ClearCharacters();
        }
    }
}
