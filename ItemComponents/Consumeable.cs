using System;
using Characters;
using Items;

namespace ItemComponents
{
	public class Consumeable : IGrantsEffect, IDestructible
	{
		public int Filling{ get; private set;}
		public bool DestroyConditionMet{ get; private set; }
		private int _chargesRemaining;
		public Consumeable (int filling,int charges)
		{
			Filling = filling;
			DestroyConditionMet = false;
			_chargesRemaining = charges;
		}
		//eat the foods
		public void ApplyEffect(Item affected){
			affected.ItemEffect.Filling += Filling;
		}
		//Not likely to ever be used, but allows a character to "vomit up"
		//food that has been consumed, thus losing its filling.
		public void RemoveEffect(Item affected){
			affected.ItemEffect.Filling -= Filling;
		}
		public void ConsumeCharge(){
			this._chargesRemaining -= 1;
			if (this._chargesRemaining < 1) {
				DestroyConditionMet = true;
			}
		}
	}
}

