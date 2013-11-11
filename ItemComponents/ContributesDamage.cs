using System;
using Characters;
using BaseClasses;

namespace ItemComponents
{
	public class ContributesDamage : IEquippable
	{
		private DiceRoll _diceDamage;
		public int DiceSize { 
			get {
				return _diceDamage.DiceSize;
			}
		}
		public int DiceCount { 
			get {
				return _diceDamage.DiceCount;
			}
		}
		public ContributesDamage (int diceSize, int diceCount)
		{
			_diceDamage = new DiceRoll(diceSize,diceCount);
		}
		public ContributesDamage (DiceRoll dice)
		{
			_diceDamage = dice;
		}
		public void OnEquip(Character owner){
		}
		public void OnUnequip(Character owner){
		}
	}
}

