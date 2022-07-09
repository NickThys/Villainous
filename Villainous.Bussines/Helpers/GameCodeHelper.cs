using System.Text;

namespace Villainous.Bussines.Helpers
{
    public class GameCodeHelper
    {
        private static readonly char[] _characters = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789".ToCharArray();
        private static readonly Random _randomGenerator = new Random();

        public string GenerateGameCode(int lenght = 6)
        {
            var codeBuilder = new StringBuilder(lenght);
            for (int i = 0; i < codeBuilder.Capacity; i++)
            {
                codeBuilder.Append(_characters[_randomGenerator.Next(_characters.Length)]);
            }
            return codeBuilder.ToString();
        }
    }
}
