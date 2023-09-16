namespace DesktopKonata.Utility
{
    public static class CharacterManager
    {
        public static List<CharacterEntity> Characters { get; } = new();

        public static void AddCharacter(Bitmap characterBitmap)
        {
            Characters.Add(new CharacterEntity(characterBitmap, Screen.PrimaryScreen!.Bounds));
        }

        public static void ClearCharacters()
        {
            for (int i = Characters.Count - 1; i >= 0; i--)
            {
                Characters[i].Dispose();
                Characters.RemoveAt(i);
            }
        }
    }
}
