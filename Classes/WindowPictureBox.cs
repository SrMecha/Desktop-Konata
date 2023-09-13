namespace DesktopKonata.Utility
{
    public class WindowPictureBox : PictureBox
    {
        private CharacterHitBox? _controledPicture;
        private Point _pictureStartLocation;
        private Point _startLocation;
        private List<CharacterHitBox> _characters = new();

        public WindowPictureBox(Rectangle screenBounds)
        {
            MouseMove += PictureMouseMove!;
            MouseDown += PictureMouseDown!;
            MouseUp += PictureMouseUp!;
            Bounds = screenBounds;
        }

        private void PictureMouseDown(object sender, MouseEventArgs args)
        {
            foreach (var character in _characters)
                if (character.Bounds.Contains(args.Location))
                {
                    _controledPicture = character;
                    _pictureStartLocation = character.Location;
                    _startLocation = args.Location;
                    return;
                }
        }

        private void PictureMouseUp(object sender, MouseEventArgs args)
        {
            _controledPicture = null;
        }

        private void PictureMouseMove(object sender, MouseEventArgs args)
        {
            if (_controledPicture is not null)
            {
                _controledPicture.Left = args.X + _pictureStartLocation.X - _startLocation.X;
                _controledPicture.Top = args.Y + _pictureStartLocation!.Y - _startLocation.Y;
            }
        }

        protected override void OnPaint(PaintEventArgs args)
        {
            ImageAnimator.UpdateFrames();
            foreach (var character in _characters)
            {
                args.Graphics.DrawImage(character.AnimatedImage, character.Location.X, character.Location.Y);
            }
            Invalidate();
        }

        public void AddCharacter(Bitmap characterBitmap)
        {
            _characters.Add(new CharacterHitBox(characterBitmap, Bounds));
        }

        public void ClearCharacters()
        {
            _characters = new();
        }

    }
}
