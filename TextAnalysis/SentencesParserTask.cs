using System;
using System.Collections.Generic;
using System.Text;

//В этом задании нужно реализовать метод в классе SentencesParserTask.Метод должен делать следующее:
//Разделять текст на предложения, а предложения на слова.
//a.Считайте, что слова состоят только из букв(используйте метод char.IsLetter) или символа апострофа ' и отделены друг от друга любыми другими символами.
//b.Предложения состоят из слов и отделены друг от друга одним из следующих символов.!?;:()
//Приводить символы каждого слова в нижний регистр.
//Пропускать предложения, в которых не оказалось слов.
//Метод должен возвращать список предложений, где каждое предложение — это список из одного или более слов в нижнем регистре.
namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            string[] sentences = GetSentences(text);
            List<List<string>> result = GetSentencesWords(sentences);
            return result;
        }

        private static List<List<string>> GetSentencesWords(string[] sentences)
        {
            List<List<string>> result = new List<List<string>>();
            StringBuilder word = new StringBuilder();
            List<string> words = new List<string>();

            foreach (string sentence in sentences)
            {
                if (sentence.Length == 0)
                {
                    continue;
                }
                
                foreach (char c in sentence)
                {
                    if (char.IsLetter(c) || c == '\'')
                    {
                        word.Append(char.ToLower(c));
                    }
                    else
                    {
                        if (word.Length > 0)
                        {
                            words.Add(word.ToString());
                        }
                        word.Clear();
                    }
                }
                if (word.Length != 0)
                    words.Add(word.ToString());
                else if (words.Count == 0)
                { 
                    words.Clear(); continue; 
                }
                result.Add(new List<string>(words));
                words.Clear();
            }

            return result;
        }

        private static string[] GetSentences(string text)
        {
            char[] splitters = { '.', '!', '?', ';', ':', '(', ')' };
            string[] sentences = text.Split(splitters);
            return sentences;
        }
    }
}