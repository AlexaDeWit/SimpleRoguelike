using System;
using System.Collections.Generic;
using BaseClasses;
using Combat;
using Constants;
using Effects;

namespace Characters {
	/// <summary>
	/// This is the base and abstracted character class used to derive both player-characters and nonplayer characters,
	/// such that they can have shared functionality and be treated as the same thing externally, but allow them both
	/// to have different systems for deriving things like attack damage
	/// </summary>
	public abstract class Character : BaseClasses.Entity, Combat.ICombatCapable {
		/// <summary>
		/// Gets or sets the character race. The race will provide base atrtibutes as well as
		/// Information about other characteristics of the character.
		/// </summary>
		/// <value>The character race.</value>
		public Race CharacterRace{ get; set; }
		/// <summary>
		/// Gets or sets the base health.
		/// </summary>
		/// <value>The "naked value" of a character's health. What their health would be with no items or attributes</value>
		public int BaseHealth{ get; set; }
		/// <summary>
		/// Gets or sets the base mana.
		/// </summary>
		/// <value>The "naked value" of a character's mana. What their mana would be with no items or attributes</value>
		public int BaseMana{ get; set; }
		/// <summary>
		/// Gets or sets the base armour.
		/// </summary>
		/// <value>The "naked value" of a character's armour. What their armour would be with no items or attributes</value>
		public int BaseArmour{ get; set; }
		/// <summary>
		/// Gets or sets the current health.
		/// </summary>
		/// <value>The current health of the character.</value>
		public int Health{ get; set; }
		/// <summary>
		/// Gets or sets the current mana.
		/// </summary>
		/// <value>The current mana of the character.</value>
		public int Mana{ get; set; }
		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		/// <value>The level of the character in terms of experience and advancement, not the "game stage"</value>
		public int Level{ get; set; }
		/// <summary>
		/// All the Dice Sets that when rolled and summed together determine the attack damage of the character
		/// </summary>
		public List<DiceRoll> DamageComponents = new List<DiceRoll> ();
		/// <summary>
		/// All the status effects the character is currently experiencing.
		/// Used for things like bonus armour and health determination
		/// </summary>
		public List<Effect> StatusEffects = new List<Effect> ();
		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>Text string representing the character's gender, allowing full personal expression,
		/// and privilege checking.
		/// </value>
		public string Gender{ get; set; }
		//Placeholders, will likely be replaced by methods
		public int FireRes{ get; set; }
		public int ColdRes{ get; set; }
		public int LightningRes{ get; set; }
		public int PoisonRes{ get; set; }
		/// <summary>
		/// Gets or sets the character's faction
		/// </summary>
		/// <value>The character's primary faction affiliation</value>
		public Faction CharacterFaction{ get; set; }
		/// <summary>
		/// Gets or sets the amount of money posessed by the character
		/// </summary>
		/// <value>The amount of money the character has, in coins</value>
		public long Currency{ get; set; }
		/// <summary>
		/// Calculates the upper limit of the character's health
		/// </summary>
		/// <returns>The maximum health the character is permitted to have</returns>
		public abstract int MaxHealth ();
		/// <summary>
		/// Calculates the upper limit of the character's mana
		/// </summary>
		/// <returns>The maximum mana the character is permitted to have</returns>
		public abstract int MaxMana ();
		/// <summary>
		/// Calculates the total armour a character has.
		/// </summary>
		/// <returns>Character's total armour</returns>
		public abstract int ArmourValue ();
		/// <summary>
		/// Determines the character's chance to block an attack
		/// </summary>
		/// <returns>The block chance.</returns>
		public abstract double BlockChance ();
		/// <summary>
		/// Determine's the amount of damage a character can block from an attack
		/// </summary>
		/// <returns>The amount to block. (0.0 to 1.0)</returns>
		public abstract int BlockAmount ();
		/// <summary>
		/// Determines the character's chance to land an attack
		/// </summary>
		/// <returns>The hit chance.</returns>
		public abstract double StrikeChance ();
		/// <summary>
		/// Determines the character's chance to dodge an attack
		/// </summary>
		/// <returns>The dge chance. (0.0 to 1.0)</returns>
		public abstract double EvasionChance ();
		/// <summary>
		/// The character's effective level when engaging in combat
		/// </summary>
		/// <returns>The effective level (0.0 to 1.0)</returns>
		public abstract int CombatLevel{ get; }
		/// <summary>
		/// Whether or not the character can block an attack.
		/// </summary>
		public abstract bool CanBlock ();
		/// <summary>
		/// Gets or sets the amount of damage a character can ignore.
		/// </summary>
		/// <value>The amount of damage the character can ignore</value>
		public int DamageIgnore{ get; set; }
		/// <summary>
		/// Calculates the attack damage the character will inflict based on dice rolls.
		/// </summary>
		/// <returns>The attack damage.</returns>
		public int CalculateDamage () {
			int total = 0;
			foreach (DiceRoll d in DamageComponents) {
				total += d.Roll ();
			}
			return total;
		}
		/// <summary>
		/// Generates a double from zero to 1. Used to conceil the Random object and simplify
		/// combat calculations
		/// </summary>
		/// <returns>Random double from 0 to 1 </returns>
		public double SuccessRoll () {
			Random numberGenerator = new Random ();
			return numberGenerator.NextDouble ();
		}
		/// <summary>
		/// Causes the character to suffer damage. It will reduce the actual damage
		/// by any damage ignoring effects the character posesses.
		/// </summary>
		/// <returns>The amount of damage actually taken after damage ignore was applied</returns>
		/// <param name="damage">The damage to inflict</param>
		public virtual int SufferDamage (int damage) {
			int damageToSuffer = damage - DamageIgnore;
			if (damageToSuffer > 0) {
				Health -= damageToSuffer;
				return damageToSuffer;
			} else {
				return 0;
			}
		}
		/// <summary>
		/// Attemps a regular combat attack(melee) against a target
		/// </summary>
		/// <returns>A combat instance object which contains all of the combat data
		/// that occurred during this attack.</returns>
		/// <param name="defender">The target to be attacked. Must implement ICombatCapable interface.</param>
		public CombatInstance RegularAttack (ICombatCapable defender) {

			CombatInstance currentAttack = new CombatInstance ();
			int damageToInflict = 0;

			/*
			 *  Bonus or pentalty in combat due to level differences
			 *  Positive if above target, negative if below
			 */
			double levelDifferenceModifier = Convert.ToDouble (this.CombatLevel - defender.CombatLevel) / 100.0D;

			double missChance = defender.EvasionChance () +
			                    (1.0D - this.StrikeChance ()) - levelDifferenceModifier;

			//Damage to inflict will be progressively reduced
			currentAttack.BaseDamage = this.CalculateDamage ();
			damageToInflict = currentAttack.BaseDamage;

			//Roll for attack
			currentAttack.AttackRoll = this.SuccessRoll ();
			if (currentAttack.AttackRoll > missChance) {

				//Determine if defender is able to block(has a shield?)
				currentAttack.DefenderCanBlock = defender.CanBlock ();
				if (currentAttack.DefenderCanBlock) {

					//Roll to beat defender's block chance
					currentAttack.BypassBlockRoll = this.SuccessRoll ();
					if (currentAttack.BypassBlockRoll < defender.BlockChance ()) {

						currentAttack.WasBlocked = true;
						currentAttack.DamageBlocked = defender.BlockAmount ();
						damageToInflict -= currentAttack.DamageBlocked;
					} else {

						//Attack got through block
						currentAttack.WasBlocked = false;
					}
				}

				//Attack was in some way successful
				//Do the armour damage reduction calculation
				currentAttack.DamageReducedByArmour = ArmourDamageReduction (damageToInflict, defender.ArmourValue ());
				damageToInflict -= currentAttack.DamageReducedByArmour;
				//Inflict the damage, and calculate how much was absorbed(determined by the defender)
				currentAttack.DamageAbsorbed = damageToInflict - defender.SufferDamage (damageToInflict);
				currentAttack.DamageInflicted = damageToInflict - currentAttack.DamageAbsorbed;
			} else {
				currentAttack.AttackSuccess = false;
			}
			return currentAttack;
		}
		/// <summary>
		/// Determines how much damage should be reduced from an attack due to
		/// a character's armour value.
		/// </summary>
		/// <returns>The amount of damage to reduce</returns>
		/// <param name="baseDamage">The damage that the attack was going to inflict</param>
		/// <param name="armour">The flat armour value of the target</param>
		public static int ArmourDamageReduction (int baseDamage, int armour) {
			//the 1 represents the adjustment from a percentage of reduction
			//to a ratio for multiplication
			//IE. -30% damage taken is damage*70%
			return (int)(baseDamage * (ArmourDamageRatio (armour) + 1));
		}
		/// <summary>
		/// Calculates the percentage damage modification to apply based on a flat armour value.
		/// Does support negative armour and thus amplification. The ratio will be negative for
		/// damage reduction, and positive for damage amplification.
		/// </summary>
		/// <returns>The ratio of how much damamge should be ignored</returns>
		/// <param name="armour">The armour to base the calculations on</param>
		public static double ArmourDamageRatio (int armour) {
			double absoluteArmour = Math.Abs (armour);
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
		/// <summary>
		/// Takes a buff/defbuff effect and integrates it into the character, applying
		/// all its effect to the base stats of the character, and removing itself from
		/// the StatusEffects list.
		/// </summary>
		/// <param name="buff">The status effect to merge into the character's base stats</param>
		public virtual void MakeEffectBaseline (Effect buff) {
			this.BaseMana += buff.MaxMana;
			this.BaseHealth += buff.MaxHealth;
			this.BaseArmour += buff.Armour;
			if (this.StatusEffects.Contains (buff)) {
				this.StatusEffects.Remove (buff);
			}
		}
	}
}

