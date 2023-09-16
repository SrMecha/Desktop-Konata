namespace DesktopKonata.Utility
{
    public class CharacterEntity : IDisposable
    {
        private bool disposed = false;
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

        public CharacterEntity(Bitmap characterBitmap, Rectangle screenBounds)
        {
            Size = characterBitmap.Size;
            AnimatedImage = characterBitmap;
            Left = Random.Shared.Next(0, screenBounds.Width - Size.Width);
            Top = Random.Shared.Next(0, screenBounds.Height - Size.Height);
            ImageAnimator.Animate(AnimatedImage, new EventHandler(OnFrameChanged!));
        }

        private void OnFrameChanged(object sender, EventArgs args)
        {

        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    ImageAnimator.StopAnimate(AnimatedImage, new EventHandler(OnFrameChanged!));
                    AnimatedImage.Dispose();
                }
                disposed = true;
            }
        }

        ~CharacterEntity()
        {
            Dispose(disposing: false);
        }
    }
}
