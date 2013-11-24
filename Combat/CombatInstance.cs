using System;

namespace Combat
{
	/// <summary>
	/// Stores one instance of combat for use in both combat logging, as for outputting the results of combat.
	/// </summary>
	public class CombatInstance
	{
		/// <summary>
		/// The damage that was originally going to be dealt
		/// </summary>
		public int BaseDamage=0;
		/// <summary>
		/// The damage reduced by shield blocking
		/// </summary>
		public int DamageBlocked=0;
		/// <summary>
		/// The damage reduced my armour bonuses
		/// </summary>
		public int DamageReducedByArmour=0;
		/// <summary>
		/// The damage absorbed by other effects on the target
		/// </summary>
		public int DamageAbsorbed=0;
		/// <summary>
		/// The actual damage inflicted on the target(basedamage-all sources of reduction/absorbtion)
		/// </summary>
		public int DamageInflicted=0;
		/// <summary>
		/// The the roll to attack that was generated
		/// </summary>
		public double AttackRoll=0.0;
		/// <summary>
		/// The roll to get through the defender's block chance that was generated
		/// </summary>
		public double BypassBlockRoll=0.0;
		/// <summary>
		/// The ability if any of the defender to block
		/// </summary>
		public bool DefenderCanBlock=false;
		/// <summary>
		/// If the attack was or was not blocked
		/// </summary>
		public bool WasBlocked=false;
		/// <summary>
		/// If the attack was or was not successful at hitting the target
		/// </summary>
		public bool AttackSuccess=false;
	}
}

