using System;

namespace Constants
{
	/// <summary>
	/// Constants to be used throughout the game that deal with game mechanics,
	/// or simply just removing "magic numbers" from as much of the game as possible.
	/// </summary>
	public static class Mechanics
	{
		/// <summary>
		/// The minimum reputation one must have with a faction for them to react as friendly
		/// </summary>
		public const int REPUTATION_MINIMUM_FRIENDLY=100;
		/// <summary>
		/// The minimum reputation one must have with a faction for them to react as neutral
		/// </summary>
		public const int REPUTATION_MINIMUM_NEUTRAL=0;
		/// <summary>
		/// The maximum reputation an entity will react as hostile toward another.
		/// </summary>
		public const int REPUTATION_MAXIMUM_HOSTILE=-1;
		/// <summary>
		/// A string which represents how mass is displayed in the game
		/// </summary>
		public const string MASS_UNIT = "kg";
		/// <summary>
		/// The amount of health gained for each point of endurance
		/// </summary>
		public const int HEALTH_PER_ENDURANCE = 12;
		/// <summary>
		/// The amount of mana gained for each point of intelligence
		/// </summary>
		public const int MANA_PER_INTELLIGENCE =15;
		/// <summary>
		/// The amount of armour gained for each point of agility
		/// </summary>
		public const int ARMOUR_PER_AGILITY = 10;
		/// <summary>
		/// The point of hunger where a character will die.
		/// </summary>
		public const int DIE_OF_HUNGER = 100;
	}
}

