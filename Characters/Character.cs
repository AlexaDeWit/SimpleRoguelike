using System;
using System.Collections.Generic;
using BaseClasses;
using Combat;
using Constants;

namespace Characters
{
	/*
	 * <summary>
	 * This is the base and abstracted character class used to derive both player-characters and nonplayer characters,
	 * such that they can have shared functionality and be treated as the same thing externally, but allow them both
	 * to have different systems for deriving things like attack damage
	 * </summary>
	 */
	public abstract class Character : BaseClasses.Entity, Combat.ICombatCapable
	{
		//Character Stats
		public Race CharacterRace{ get; set; } 
		public int MaxHealth{ get; set; } 
		public int Health{ get; set; } 
		public int HealthRegen{ get; set; }
		public int MaxMana{ get; set; }
		public int Mana{ get; set; }
		public int ManaRegen{ get; set; }
		public int Level{get;set;}
		//Sum of all attack damage sources
		public List<DiceRoll> DamageComponents=new List<DiceRoll>();
		
		//Gender
		public string Gender{get;set;}

		//Resistances
		public int FireRes{ get; set; }
		public int ColdRes{ get; set; }
		public int LightningRes{ get; set; }
		public int PoisonRes{ get; set; }

		public Faction CharacterFaction{ get; set; }

		//Wallet
		public long Currency{ get; set; }

		//ICombat abstractions, different for each type of character
		public abstract int ArmourValue{get;set;}
		public abstract double BlockChance{ get;set; }
		public abstract int BlockAmount{ get;set; }
		public abstract double StrikeChance{ get; }
		public abstract double EvasionChance{ get;}
		public abstract int CombatLevel{ get;}
		public abstract bool CanBlock{ get; set; }
		//DamageCalculation
		public int CalculateDamage ()
		{
			int total=0;
			foreach (DiceRoll d in DamageComponents) {
				total += d.Roll();
			}
			return total;
		}

		//Percentage Chance
		public double SuccessRoll ()
		{
			Random numberGenerator = new Random ();
			return numberGenerator.NextDouble();
		}
		//Allow a character to attack another
		public abstract int SufferDamage(int damage);

		public CombatInstance RegularAttack(ICombatCapable defender){


			CombatInstance currentAttack = new CombatInstance();
			int damageToInflict=0;

			/*
			 *  Bonus or pentalty in combat due to level differences
			 *  Positive if above target, negative if below
			 */
			double levelDifferenceModifier = Convert.ToDouble(this.CombatLevel - defender.CombatLevel) / 100.0D;
			double missChance = defender.EvasionChance +
				(1.0D - this.StrikeChance) - levelDifferenceModifier;

			//Damage to inflict will be progressively reduced
			currentAttack.BaseDamage = this.CalculateDamage();
			damageToInflict =  currentAttack.BaseDamage;

			//Roll for attack
			currentAttack.AttackRoll = this.SuccessRoll();
			if (currentAttack.AttackRoll > missChance) {

				//Determine if defender is able to block(has a shield?)
				currentAttack.DefenderCanBlock = defender.CanBlock;
				if(currentAttack.DefenderCanBlock){
					//Roll to beat defender's block chance
					currentAttack.BypassBlockRoll = this.SuccessRoll();
					if(currentAttack.BypassBlockRoll < defender.BlockChance){
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
		public static int ArmourDamageReduction(int baseDamage, int armour){
			//the 1 represents the adjustment from a percentage of reduction
			//to a ratio for multiplication
			//IE. -30% damage taken is damage*70%
			return (int)(baseDamage * (ArmourDamageRatio(armour)+1));
		}
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

