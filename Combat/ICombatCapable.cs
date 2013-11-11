using System;
using BaseClasses;
using System.Collections.Generic;

namespace Combat
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
		bool CanBlock{ get; }
		List<DiceRoll> DamageComponents;

		//functions
		int CalculateDamage();
		double DamageReductionPercentage();
		double SuccessRoll();
		int SufferDamage(int damage);
	}
}

