using System;
using Characters;
using Items;

namespace ItemComponents
{
	public class Consumeable : IGrantsEffect, IDestructible
	{
		public int Filling{ get; private set;}
		public bool DestroyConditionMet{ get; private set; }
		public Consumeable (int filling)
		{
			Filling = filling;
			DestroyConditionMet = false;
		}
		//eat the foods
		public void ApplyEffect(Item affected){
			if (!DestroyConditionMet) {
				affected.ItemEffect.Filling += Filling;
				DestroyConditionMet = true;
			}
		}
		//Not likely to ever be used, but allows a character to "vomit up"
		//food that has been consumed, thus losing its filling.
		public void RemoveEffect(Item affected){
			affected.ItemEffect.Filling -= Filling;
		}
	}
}

