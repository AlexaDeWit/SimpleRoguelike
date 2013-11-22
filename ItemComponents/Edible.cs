using System;
using Characters;

namespace ItemComponents
{
	public class Edible : IConsumeable
	{
		public int MaxCharges{ get; private set; }
		public int ChargesRemaining{ get; set; }
		public int Filling{ get; private set;}
		public Edible (int charges, int filling)
		{
			MaxCharges = charges;
			Filling = filling;
			ChargesRemaining = MaxCharges;
		}
		//eat the foods
		public void ApplyEffect(PlayerCharacter affected){
			affected.Hunger -= Filling;
			ChargesRemaining -= 0;
		}
		//Not likely to ever be used, but allows a character to "vomit up"
		//food that has been consumed, thus losing its filling.
		public void RemoveEffect(PlayerCharacter affected){
			affected.Hunger += Filling;
		}
	}
}

