using System;
using BaseClasses;
using System.Collections.Generic;

namespace Combat
{
	/*
	 * <sumamry>
	 * The interface that sets out the functionality necessary for an entity to be
	 * able to engage in combat with another.
	 * </summary>
	 */
	public interface ICombatCapable
	{
		//Generally will be properties
		//Some of these will be derived from calculations in their implementations.
		int ArmourValue{get;}
		double BlockChance{ get; }
		int BlockAmount{ get; }
		double StrikeChance{ get; }
		double EvasionChance{ get; }
		int CombatLevel{ get; }
		int Health{ get; set;}
		bool CanBlock{ get; }

		//functions
		int CalculateDamage();
		double SuccessRoll();
		int SufferDamage(int damage);
	}
}

