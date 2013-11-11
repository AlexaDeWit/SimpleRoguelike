using System;

namespace BaseClasses
{
	public class DiceRoll
	{
		public int DiceSize{ get; }
		public int DiceCount{ get; }
		public DiceRoll(int diceSize, int diceCount)
		{
			DiceSize=diceSize;
			DiceCount=diceCount;
		}
	}
}

