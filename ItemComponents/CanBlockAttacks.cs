using System;

namespace ItemComponents
{
	/// <summary>
	/// Provides the data to support blocking mechanics on an item for use in combat
	/// </summary>
	public class CanBlockAttacks : IItemComponent
	{
		/// <summary>
		/// Gets the block chance.
		/// </summary>
		/// <value>The block chance.(as a percentage from 0 to 1)</value>
		public double BlockChance{ get;private set; }
		/// <summary>
		/// Gets the block amount.
		/// </summary>
		/// <value>The block amount.</value>
		public int BlockAmount{get; private set;}
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemComponents.CanBlockAttacks"/> class.
		/// </summary>
		/// <param name="chance">Chance to block(as a percentage from 0 to 1)</param>
		/// <param name="amount">Amount to block</param>
		public CanBlockAttacks (double chance, int amount)
		{
			BlockChance=chance;
			BlockAmount=amount;
		}
	}
}

