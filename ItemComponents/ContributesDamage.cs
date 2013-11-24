using System;
using Characters;
using BaseClasses;
using Items;

namespace ItemComponents
{
	/*
	 * <summary>
	 * Interface that allows items to contribute to their wielder's attack damage.
	 * Dependant upon the DiceRoll class which determines its damage component
	 * 
	 * Only one Damage component is allowed on a given item.
	 * </summary>
	 */
	public class ContributesDamage : IGrantsEffect
	{
		//A set of dice represents nDn, dungeons and dragons style damage calculation
		public DiceRoll _diceDamage{ private set;get; }
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
		public void ApplyEffect(Item owner){
			owner.ItemEffect.DamageComponent = _diceDamage;
		}
		public void RemoveEffect(Item owner){
			owner.ItemEffect.DamageComponent = _diceDamage;
		}
	}
}

