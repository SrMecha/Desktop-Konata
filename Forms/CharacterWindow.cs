using DesktopKonata.Utility;
using System.Windows.Forms;

namespace DesktopKonata.Forms
{
    public partial class CharacterWindow : Form
    {
        public CharacterWindow()
        {
            InitializeComponent();
            Controls.Add(new WindowPictureBox(Screen.PrimaryScreen!.Bounds));
        }

        public WindowPictureBox GetCharacterPictureBox()
        {
            return Controls.OfType<WindowPictureBox>().First()!;
        }

        public void AddCharacter(Bitmap characterBitmap)
        {
            GetCharacterPictureBox().AddCharacter(characterBitmap);
        }

        public void ClearCharacters()
        {
            GetCharacterPictureBox().ClearCharacters();
        }
    }
}