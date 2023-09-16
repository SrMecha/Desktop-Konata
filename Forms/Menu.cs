using DesktopKonata.Utility;
using System.Windows.Forms;

namespace DesktopKonata.Forms
{
    public partial class Menu : Form
    {
        private readonly Screen[] AllScreens = Screen.AllScreens;
        private readonly List<CharacterWindow> _windows = new();

        private NotifyIcon _notifyIcon = new()
        {
            Visible = true,
            Icon = Properties.Resources.KonataIco,
            Text = "Konata is here!",
            BalloonTipIcon = ToolTipIcon.Info,
            BalloonTipTitle = "Hey",
            BalloonTipText = "I`ll be here!"
        };

        public Menu()
        {
            InitializeComponent();
            _notifyIcon.MouseClick += NotifyIcon_MouseClick!;
        }

        private void Menu_Load(object sender, EventArgs args)
        {
            foreach (var screen in AllScreens)
            {
                var window = new CharacterWindow(screen);
                window.SetBounds(screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height);
                _windows.Add(window);
                window.Show();
            }
        }

        private void KonataLoveToolStripMenuItem_Click(object sender, EventArgs args)
        {
            CharacterManager.AddCharacter(Properties.Resources.KonataLoveDancingGif);
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
            _notifyIcon.Visible = false;
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideInTray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CharacterManager.ClearCharacters();
        }

        private void bananaKonataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharacterManager.AddCharacter(Properties.Resources.BananaKonataGIF);
        }

        private void konataDanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharacterManager.AddCharacter(Properties.Resources.KonataDancingGif);
        }
    }
}
