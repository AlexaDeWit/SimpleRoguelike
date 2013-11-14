using System;

namespace Combat
{
	/*
	 * <summary>
	 * Stores one instance of combat for use in both combat logging, as for outputting the results of combat.
	 * </summary>
	 */
	public class CombatInstance
	{
		public int BaseDamage=0;
		public int DamageBlocked=0;
		//Damage done - damage absorbed = actual damage suffered
		public int DamageReducedByArmour=0;
		public int DamageAbsorbed=0;
		public int DamageInflicted=0;
		public double AttackRoll=0;
		public double BypassBlockRoll=0;
		public bool DefenderCanBlock=false;
		public bool WasBlocked=false;
		public bool AttackSuccess=false;


	}
}

