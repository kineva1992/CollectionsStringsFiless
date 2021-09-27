using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            string result = string.Empty;
          
            for (int i = 0; i < wordsCount; ++i)
            {
                string[] splitText = phraseBeginning.Split(' ');
                if (splitText.Length == 0)
                    break;
                if (splitText.Length >= 2)
                {
                    if (nextWords.ContainsKey(string.Format("{0} {1}", splitText[splitText.Length - 2], 
                        splitText[splitText.Length - 1])))
                    {
                        phraseBeginning += " " + nextWords[string.Format("{0} {1}", 
                            splitText[splitText.Length - 2], splitText[splitText.Length - 1])];
                        continue;
                    }
                }
                if (nextWords.ContainsKey(splitText[splitText.Length - 1]))
                {
                    phraseBeginning += " " + nextWords[splitText[splitText.Length - 1]];
                    continue;
                }
                break;
            }
            return phraseBeginning;
        }
    }

}