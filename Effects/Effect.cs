using System;
using BaseClasses;

namespace Effects
{
	/// <summary>
	/// Represents a buff or debuff to a character. Contains a 
	/// field for every buff/debuff a player can experience.
	/// Shitty approach to doing things, but, hey.
	/// </summary>
	public class Effect
	{
		/// <summary>
		/// Gets or sets the armour bonus of this effect
		/// </summary>
		/// <value>The armour bonus.</value>
		public int Armour{ get; set;}
		/// <summary>
		/// Gets or sets the health bonus of this effect
		/// </summary>
		/// <value>The health bonus.</value>
		public int MaxHealth{ get; set; }
		/// <summary>
		/// Gets or sets the mana bonus of this effect
		/// </summary>
		/// <value>The mana bonus.</value>
		public int MaxMana{ get; set;}
		/// <summary>
		/// Gets or sets the nutritional filling(reduction in hunger) provided by this effect
		/// </summary>
		/// <value>The filling(reduction in hunger) provided.</value>
		public int Filling{ get; set; }
		/// <summary>
		/// Any additional damage rolls granted by this effect
		/// </summary>
		public DiceRoll DamageComponent;
		/// <summary>
		/// Initializes a new instance of the <see cref="Effects.Effect"/> class.
		/// Sets all effects to zero values so they can be called and contribute nothing,
		/// without returning null references or causing execution errors.
		/// </summary>
		public Effect ()
		{
			Armour = 0;
			MaxHealth = 0;
			MaxMana = 0;
			Filling = 0;
			DamageComponent = new DiceRoll (0, 0);
		}
	}
}

