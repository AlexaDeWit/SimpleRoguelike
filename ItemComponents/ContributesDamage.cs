using System;
using Characters;
using BaseClasses;

namespace ItemComponents
{
	public class ContributesDamage : IGrantsEffect
	{
		//A set of dice represents nDn, dungeons and dragons style damage calculation
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

		//Constructors
		public ContributesDamage (int diceSize, int diceCount)
		{
			_diceDamage = new DiceRoll(diceSize,diceCount);
		}
		public ContributesDamage (DiceRoll dice)
		{
			_diceDamage = dice;
		}

		//Interface implementation
		public void OnApplication(Character owner){
			owner.DamageComponents.Add(this);
		}
		public void OnRemoval(Character owner){
			owner.DamageComponents.Remove(this);
		}
	}
}

