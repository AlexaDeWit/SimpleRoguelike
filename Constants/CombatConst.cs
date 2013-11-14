using System;

namespace Constants
{
	/*
	 * <summary>
	 * Constants that are used and depended on by the combat system and related classes.
	 * </summary>
	 */
	public static class CombatConst
	{
		public const double BASE_HIT_CHANCE = 0.65D;
		public const double BASE_EVASION_CHANCE =0.0D;
		public const int TARGET_MISSED=-1;
		public const double ARMOUR_SCALING_RATIO = 150.0D;
		public const double STRIKE_CHANCE_SCALING_RATIO = 0.35D;
		public const double AGILITY_BONUS_RATIO_HIT = 10.0D;
	}
}

