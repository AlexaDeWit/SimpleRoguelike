using System;

namespace ItemComponents
{
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

