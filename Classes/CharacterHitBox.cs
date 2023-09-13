namespace DesktopKonata.Utility
{
    public class CharacterHitBox
    {
        private Rectangle _bounds = new();

        public Rectangle Bounds
        { 
            get => _bounds; 
            set => _bounds = value; 
        }
        public Size Size
        {
            get => _bounds.Size;
            set => _bounds.Size = value;
        }
        public Point Location
        {
            get => _bounds.Location;
            set => _bounds.Location = value;
        }
        public int Left
        {
            get => _bounds.Left;
            set => _bounds.X = value;
        }
        public int Top
        {
            get => _bounds.Top;
            set => _bounds.Y = value;
        }

        public Bitmap AnimatedImage { get; init; }

        public CharacterHitBox(Bitmap characterBitmap, Rectangle screenBounds)
        {
            AnimatedImage = characterBitmap;
            Size = characterBitmap.Size;
            Left = Random.Shared.Next(0, screenBounds.Width - characterBitmap.Width);
            Top = Random.Shared.Next(0, screenBounds.Height - characterBitmap.Height);
            ImageAnimator.Animate(AnimatedImage, new EventHandler(OnFrameChanged!));
        }

        private void OnFrameChanged(object sender, EventArgs args)
        {

        }
    }
}
