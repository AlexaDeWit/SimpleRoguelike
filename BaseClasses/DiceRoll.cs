using System;

namespace BaseClasses
{
	/*<summary>
	 * This class represents a dice-based randomization for the game.
	 * The number of faces on the dice to be rolled, and how many times to roll it.
	 * A la DND style rolls.
	 * </summary>
	 * */
	public class DiceRoll
	{
		public int DiceSize{ get; private set;}
		public int DiceCount{ get; private set;}
		public DiceRoll(int diceSize, int diceCount)
		{
			DiceSize=diceSize;
			DiceCount=diceCount;
		}
		public int Roll ()
		{
			int total=0;
			Random rand = new Random ();
			for (int i=0; i< this.DiceCount; i++) {
				total += 1 + rand.Next(DiceSize);
			}
			return total;
		}
	}
}

