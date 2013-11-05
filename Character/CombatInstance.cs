using System;

namespace Character
{
	public struct CombatInstance
	{
		public int BaseDamage=0;
		public int DamageBlocked=0;
		//Damage done - damage absorbed = actual damage suffered
		public int DamageReducedByArmour=0;
		public int DamageAbsorbed=0;
		public int DamageInflicted=0;
		public double AttackRoll=0D;
		public double BypassBlockRoll=0D;
		public bool DefenderCanBlock=false;
		public bool WasBlocked=false;
		public bool AttackSuccess=false;


	}
}

