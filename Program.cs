using DesktopKonata.Forms;

namespace DesktopKonata
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Menu());
        }
    }
}