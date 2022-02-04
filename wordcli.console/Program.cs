namespace wordcli.console
{
    public class Program
    {
        private static string _word = "moist";


        public static void Main(string[] args)
        {
            bool win = false;

            do
            {
                // See https://aka.ms/new-console-template for more information
                Print("Please enter a guess");
                string guess = Console.ReadLine();

                win = CheckWin(_word, guess, out string pattern);
                Print("Guess pattern: {0}", pattern);
            } while (!win);

        }

        private static void Print(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        private static bool CheckWin(string word, string guess, out string guessPattern)
        {
            guessPattern = string.Empty;
            if (word?.Length != guess?.Length)
            {
                return false;
            }

            // for each character in the source word, determine if the guess has
            // the same letter in the same place, transposed, or not present
            word = word.ToUpper();
            guess = guess.ToUpper();
            for (int i = 0; i < word.Length; i++)
            {
                char wordLetter = word[i];
                char guessLetter = guess[i];
                if (wordLetter == guessLetter)
                {
                    // correct
                    guessPattern += wordLetter;
                }
                else if (guess.Contains(wordLetter))
                {
                    // transposed
                    guessPattern += "/";
                }
                else
                {
                    // letter not present
                    guessPattern += "-";
                }
            }

            return word == guessPattern;
        }
    }
}
