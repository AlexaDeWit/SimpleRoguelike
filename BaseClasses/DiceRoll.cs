using System;

namespace BaseClasses {
	/*<summary>
	 * This class represents a dice-based randomization for the game.
	 * The number of faces on the dice to be rolled, and how many times to roll it.
	 * A la DND style rolls.
	 * </summary>
	 * */
	/// <summary>
	/// Dice roll.
	/// </summary>
	public class DiceRoll {
		/// <summary>
		/// Gets the size of the dice.
		/// </summary>
		/// <value>The number of faces on the dice.</value>
		public int DiceSize{ get; private set; }
		/// <summary>
		/// Gets the dice count.
		/// </summary>
		/// <value>The number of times to roll the dice</value>
		public int DiceCount{ get; private set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="BaseClasses.DiceRoll"/> class.
		/// </summary>
		/// <param name="diceSize">Number of faces</param>
		/// <param name="diceCount">Number of times to roll the dice</param>
		public DiceRoll (int diceSize, int diceCount) {
			DiceSize = diceSize;
			DiceCount = diceCount;
		}
		/// <summary>
		/// Roll this dice set
		/// <returns>The sum of the rolls</returns>
		/// </summary>
		public int Roll () {
			int total = 0;
			Random rand = new Random ();
			for (int i=0; i< this.DiceCount; i++) {
				total += 1 + rand.Next (DiceSize);
			}
			return total;
		}
	}
}

