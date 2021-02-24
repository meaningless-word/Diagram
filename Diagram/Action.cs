using System;

namespace Diagram
{
	public class Action
	{
		public int counter { get; set; }
		public string Description { get; set; }

		public void DoIt()
		{
			Console.WriteLine("сделано");
		}

		public override string ToString()
		{
			return counter.ToString() + ": " + Description;
		}

	}
}
