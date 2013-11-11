using System;

namespace ItemComponents
{
	public class CanBlockAttacks
	{
		public double BlockChance{ get; }
		public int BlockAmount{get;}
		public CanBlockAttacks (double chance, int amount)
		{
			BlockChance=chance;
			BlockAmount=amount;
		}
	}
}

