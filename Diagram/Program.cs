using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Diagram
{
	class Program
	{
		static List<User> users = new List<User>();
		static Dictionary<int, Action> actions = new Dictionary<int, Action>();

		static void Main(string[] args)
		{
			InitUsers();
			InitActions();

			Console.Write("введите логин: ");
			string login = Console.ReadLine();


			User p = users.SingleOrDefault(s => s.Login == login);

			if (p != null)
			{
				Console.WriteLine($"Приветствуем Вас, {p.Name}");
				Console.WriteLine("Зачем пожаловали?");

				int i;
				do
				{
					WhatWeCanDo();
					string s = Console.ReadLine();
					if (!int.TryParse(s, out i))
					{
						i = -1;
					}
					if (actions.ContainsKey(i))
					{
						if (!p.IsPremium)
						{
							Console.WriteLine("Но прежде, рекламная пауза");
							ShowAds();
						}
						actions[i].DoIt();
					}
					else
					{
						Console.WriteLine("указанное невыполнимо");
					}

				} while (i != 0);
			}
			else
			{
				Console.WriteLine("К сожалению, Вы не в списке");
			}
		}

		static void InitUsers()
		{
			users.Add(new User() { Login = "cat", Name = "Константин", IsPremium = false });
			users.Add(new User() { Login = "dimon", Name = "Дмитрий", IsPremium = true });
			users.Add(new User() { Login = "eu", Name = "Евгения", IsPremium = false });
		}

		static void InitActions()
		{
			actions.Add(actions.Count + 1, new Action() { counter = actions.Count + 1, Description = "понять" });
			actions.Add(actions.Count + 1, new Action() { counter = actions.Count + 1, Description = "простить" });
			actions.Add(actions.Count + 1, new Action() { counter = actions.Count + 1, Description = "принять" });
			actions.Add(0, new Action() { counter = 0, Description = "выход" });
		}

		static void WhatWeCanDo()
		{
			ConsoleColor lastColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Cyan;

			foreach(KeyValuePair<int, Action> item in actions)
			{
				Console.WriteLine(item.Value.ToString());
			}

			Console.ForegroundColor = lastColor;
		}

		static void ShowAds()
		{
			Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
			// Остановка на 1 с
			Thread.Sleep(1000);

			Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
			// Остановка на 2 с
			Thread.Sleep(2000);

			Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
			// Остановка на 3 с
			Thread.Sleep(3000);
		}
	}
}
