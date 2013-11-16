using System;
using Characters;
using BaseClasses;

namespace ItemComponents
{
	/*
	 * <summary>
	 * Interface that allows items to contribute to their wielder's attack damage.
	 * Dependant upon the DiceRoll class which determines its damage component
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
		public void ApplyEffect(Character owner){
			owner.DamageComponents.Add(this._diceDamage);
		}
		public void RemoveEffect(Character owner){
			owner.DamageComponents.Remove(this._diceDamage);
		}
	}
}

