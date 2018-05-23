using System;
using System.Text;

namespace LitterBox.Extensions {
  
  public static class StringExtensions {
  private static Random rand = new Random();
  private static string[] alphabet = new string[52] {
    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
    "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
  };

  public static string GenerateRandom(this string prefix, int characterCount = 20) {
    StringBuilder sb = new StringBuilder(prefix);
    for(int i = 0;i<characterCount;i++) {
      sb.Append(alphabet[rand.Next(0, alphabet.Length)]);
    }
    return sb.ToString();
  }
}
}