using System;
using Characters;

namespace ItemComponents
{
	public class Edible : IConsumeEffect, IDestructible
	{
		public int Filling{ get; private set;}
		public bool DestroyConditionMet{ get; private set; }
		public Edible (int filling)
		{
			Filling = filling;
			DestroyConditionMet = false;
		}
		//eat the foods
		public void ApplyEffect(PlayerCharacter affected){
			if (!DestroyConditionMet) {
				affected.Hunger -= Filling;
				DestroyConditionMet = true;
			}
		}
		//Not likely to ever be used, but allows a character to "vomit up"
		//food that has been consumed, thus losing its filling.
		public void RemoveEffect(PlayerCharacter affected){
			affected.Hunger += Filling;
		}
	}
}

