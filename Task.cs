using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsStringsFiless
{
	class Task
	{
		/*
		Вася этим летом отдыхал на море и встретил таинственную незнакомку, которая передала ему крайне странную записку.

		решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ
		дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой
		Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть
		если особенно упорно подойдешь к делу

		будет Трудно конечнО
		Код ведЬ не из простых
		очень ХОРОШИЙ код
		то у тебя все получится
		и я буДу Писать тЕбЕ еще

		чао
		Вася долго лежал на пляже, пытаясь понять, что бы это значило. Дошло до того, что он перегрелся на солнце и у него закружилась голова, но как раз благодаря этому он и понял как разгадать шифр:

		Нужно выписать все слова, начинающиеся с большой буквы, в порядке обратном тому, как они встречались в тексте.

		Вася все еще надеется, что незнакомка пришлет ему еще одно послание. А чтобы приготовиться к этому моменту, решил написать программу, расшифровывающую ее шифр.
		 */
		private static string DecodeMessage(string[] lines)
		{
			string decodedMessage = "";
			for (int i = lines.Length - 1; i >= 0; i--)
			{
				string word = lines[i];
				string[] words = word.Split(' ');

				for (int k = words.Length - 1; k >= 0; k--)
				{
					string res = words[k];
					if ((res.Length != 0) && char.IsUpper(res[0]))
					{
						decodedMessage = decodedMessage + res + " ";
					}
				}
			}
			return decodedMessage;
		}
		/*
		В отпуске Вася не тратил время зря, а заводил новые знакомства. 
		Он знакомился с другими крутыми программистами, отдыхающими с ним в одном отеле, и записывал их email-ы.

		В его дневнике получилось много записей вида <name>:<email>.

		Чтобы искать записи было быстрее, он решил сделать словарь, 
		в котором по двум первым буквам имени можно найти все записи email адресов из его дневника.

		Пример: key: Sа -> value: { sasha1995@sasha.ru, alex99@mail.ru, shurik2020@google.com }

		Вася уже написал функцию GetContacts, которая считывает его каракули из блокнота. Помогите ему сделать все остальное!
		 */
		private static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
		{
			var dictonary = new Dictionary<string, List<string>>();

			foreach (var item in contacts)
			{
				var name = item.Split(':');
				var key = name[0].Substring(0, Math.Min(2, name[0].Length));

				if (!dictonary.ContainsKey(key))
				{
					dictonary[key] = new List<string>();
				}
				else
					dictonary[key].Add(item);
			}
			return dictonary;
		}

		/*
		Вчера Вася узнал про удивительный закон Бенфорда и хочет проверить его действие. 
		Для этого он взял текст с актуальными данными по самым высоким зданиям в мире и хочет получить статистику: 
		сколько раз каждая цифра стоит на месте старшего разряда в числах из его текста.

		Метод GetBenfordStatistics должен вернуть массив чисел, в котором на i-ой позиции находится статистика для цифры i.
		 */

		public static int[] GetBenfordStatistics(string text)
		{
			var statistics = new int[10];
			for (int i = 0; i < text.Length; i++)
			{
				if (char.IsDigit(text[i]) && (i == 0) || !char.IsDigit(text[i - 1]))
				{
					var index = text[i] - '0';
					statistics[index]++;
				}
			}

			return statistics;

		}

		public static string ReplaceIncorrectSeparators(string text)
		{

			string[] separationString = { " ", ":", ": ", ";", ",", "-", " - ", "\t" };
			var splitText = text.Split(separationString, StringSplitOptions.RemoveEmptyEntries);
			return string.Join("\t", splitText);
		}

		private static string ApplyCommands(string[] commands)
		{
			var strBilder = new StringBuilder();
			string keyPush = "push";
			string keyPop = "pop";

            foreach (var item in commands)
            {
				string keyWords = item.Substring(0, item.IndexOf(' '));
				string l = item.Remove(0, keyWords.Length + 1);
				if (keyWords == keyPush)
					strBilder.Append(l);
				else if (keyWords == keyPop)
				{ 
					int c = int.Parse(l);
					strBilder.Remove(strBilder.Length - c, c);
				}
			}
			return strBilder.ToString();
		}
	}
}
