using System;

namespace Combat
{
	public struct CombatInstance
	{
		public int BaseDamage;
		public int DamageBlocked;
		//Damage done - damage absorbed = actual damage suffered
		public int DamageReducedByArmour;
		public int DamageAbsorbed;
		public int DamageInflicted;
		public double AttackRoll;
		public double BypassBlockRoll;
		public bool DefenderCanBlock;
		public bool WasBlocked;
		public bool AttackSuccess;


	}
}

