using System;

namespace Character
{
	public interface ICombatCapable
	{
		//Generally will be properties
		int ArmourValue{get;}
		double BlockChance{ get; }
		int BlockAmount{ get; }
		double StrikeChance{ get; }
		double EvasionChance{ get; }
		int CombatLevel{ get; }
		int Health{ get; set;}

		//functions
		int AttackDamage();
		double DamageReductionPercentage();

		int AttackTarget(ICombatCapable target);
		int InflictDamage(int damage);
	}
}

