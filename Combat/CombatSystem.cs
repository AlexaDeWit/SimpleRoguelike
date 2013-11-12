using System;
using Characters;
using Constants;


namespace Combat
{
	public static class CombatSystem
	{
		//Allows an attacker to make one attack against a defender using the regular attack system
		public static CombatInstance RegularAttack(ICombatCapable attacker, ICombatCapable defender){


			CombatInstance currentAttack = new CombatInstance();
			int damageToInflict=0;

			/*
			 *  Bonus or pentalty in combat due to level differences
			 *  Positive if above target, negative if below
			 */
			double levelDifferenceModifier = Convert.ToDouble(attacker.CombatLevel - defender.CombatLevel) / 100.0D;
			double missChance = defender.EvasionChance +
				(1.0D - attacker.StrikeChance) - levelDifferenceModifier;

			//Damage to inflict will be progressively reduced
			currentAttack.BaseDamage = attacker.CalculateDamage();
			damageToInflict =  currentAttack.BaseDamage;

			//Roll for attack
			currentAttack.AttackRoll = attacker.SuccessRoll();
			if (currentAttack.AttackRoll > missChance) {

				//Determine if defender is able to block(has a shield?)
				currentAttack.DefenderCanBlock = defender.CanBlock;
				if(currentAttack.DefenderCanBlock){
					//Roll to beat defender's block chance
					currentAttack.BypassBlockRoll = attacker.SuccessRoll();
					if(currentAttack.BypassBlockRoll < defender.BlockChance){
						//Attack was blocked
						currentAttack.WasBlocked = true;
						currentAttack.DamageBlocked = defender.BlockAmount;
						damageToInflict -= currentAttack.DamageBlocked;
					}else{
						//Attack got through block
						currentAttack.WasBlocked=false;
					}
				}else{
				}
				//Attack was in some way successful
				//Do the armour damage reduction calculation
				currentAttack.DamageReducedByArmour = ArmourDamageReduction(damageToInflict,defender.ArmourValue);
				damageToInflict -= currentAttack.DamageReducedByArmour;
				//Inflict the damage, and calculate how much was absorbed(determined by the defender)
				currentAttack.DamageAbsorbed = damageToInflict - defender.SufferDamage(damageToInflict);
				currentAttack.DamageInflicted = damageToInflict -  currentAttack.DamageAbsorbed;
			} else {
				currentAttack.AttackSuccess=false;
			}
			return currentAttack;
		}
		//Returns the amount of damage that will be taken after armour is calculated against an attack
		public static int ArmourDamageReduction(int baseDamage, int armour){
			//the 1 represents the adjustment from a percentage of reduction
			//to a ratio for multiplication
			//IE. -30% damage taken is damage*70%
			return (int)(baseDamage * (ArmourDamageRatio(armour)+1));
		}
		//returns the percentage of damage to be reduced or amplified
		public static double ArmourDamageRatio (int armour)
		{
			double absoluteArmour =Math.Abs (armour);
			double damageRatio = absoluteArmour / (absoluteArmour + CombatConst.ARMOUR_SCALING_RATIO);
			//if armour mitigates 30%..
			// -0.3 if the damage should be reduced
			// +0.3 if the damage should be amplified.
			if (armour >= 0) {
				return 0.0 - damageRatio;
			} else {
				return damageRatio;
			}
		}
	}
}

