using DesktopKonata.Utility;

namespace DesktopKonata.Forms
{
    public partial class CharacterWindow : Form
    {
        public CharacterWindow(Screen screen)
        {
            InitializeComponent();
            Controls.Add(new WindowPictureBox(screen.Bounds));
        }
    }
}