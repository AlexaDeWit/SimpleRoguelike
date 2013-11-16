using System;

namespace ItemComponents
{
	/*
	 * <summary>
	 * Interface used to permit an item to block attacks using shield mechanics
	 * </summary>
	 */
	public class CanBlockAttacks : IItemComponent
	{
		public double BlockChance{ get;private set; }
		public int BlockAmount{get; private set;}
		public CanBlockAttacks (double chance, int amount)
		{
			BlockChance=chance;
			BlockAmount=amount;
		}
	}
}

