using System;

namespace Constants
{
	/// <summary>
	/// Constants that are used and depended on by the combat system and related classes.
	/// </summary>
	public static class CombatConst
	{
		/// <summary>
		/// The base hit chance of an entity agaisnt another in combat
		/// </summary>
		public const double BASE_HIT_CHANCE = 0.65D;
		/// <summary>
		/// The base chance all entities have to dodge an attack
		/// </summary>
		public const double BASE_EVASION_CHANCE =0.0D;
		/// <summary>
		/// A constant that represents a target being missed in combat
		/// </summary>
		public const int TARGET_MISSED=-1;
		/// <summary>
		/// A ratio that determines how beneficial armour is. 
		/// The higher it is the less beneficial
		/// </summary>
		public const double ARMOUR_SCALING_RATIO = 150.0D;
		/// <summary>
		/// A scaling factor used for bonuses to an entity's hit chance.
		/// </summary>
		public const double STRIKE_CHANCE_SCALING_RATIO = 1.0 - BASE_HIT_CHANCE;
		/// <summary>
		/// A scaling factor to determine how beneficial agility is in increasing one's chance to hit.
		/// The higher it is, the less beneficial
		/// </summary>
		public const double AGILITY_BONUS_RATIO_HIT = 10.0D;
		/// <summary>
		/// A scaling factor to determine how beneficial agility is in increasing one's chance to evade.
		/// The higher it is, the less beneficial
		/// </summary>
		public const double AGILITY_BONUS_RATIO_EVADE = 10.0D;
	}
}

