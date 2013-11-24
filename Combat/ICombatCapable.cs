using System;
using BaseClasses;
using System.Collections.Generic;

namespace Combat
{
	/// <summary>
	/// The interface that sets out the functionality necessary for an entity to be
	/// able to engage in combat with another.
	/// </summary>
	public interface ICombatCapable
	{
		/// <summary>
		/// Gets the combat level.
		/// </summary>
		/// <value>The combat level.</value>
		int CombatLevel{ get; }
		/// <summary>
		/// Gets or sets the health.
		/// </summary>
		/// <value>The health.</value>
		int Health{ get; set;}
		/// <summary>
		/// Get the armour value
		/// </summary>
		/// <returns>The armour value</returns>
		int ArmourValue();
		/// <summary>
		/// If the entity can block
		/// </summary>
		/// <returns><c>true</c> if this instance can block; otherwise, <c>false</c>.</returns>
		bool CanBlock();
		/// <summary>
		/// The amount the entity can block from attacks
		/// </summary>
		/// <returns>The block amount.</returns>
		int BlockAmount();
		/// <summary>
		/// The entity's chance to block incoming attacks
		/// </summary>
		/// <returns>The block chance.</returns>
		double BlockChance();
		/// <summary>
		/// The entity's chance to evade incoming attacks
		/// </summary>
		/// <returns>The evasion chance.</returns>
		double EvasionChance();
		/// <summary>
		/// The entity's chance to land outgoing attacks
		/// </summary>
		/// <returns>The strike chance.</returns>
		double StrikeChance();
		/// <summary>
		/// Calculates the damage of a single attack.
		/// </summary>
		/// <returns>The damage to deal.</returns>
		int CalculateDamage();
		/// <summary>
		/// Generates a single successrol from 0 to 1 (double)
		/// </summary>
		/// <returns>The roll.</returns>
		double SuccessRoll();
		/// <summary>
		/// Suffer some amount of damage
		/// </summary>
		/// <returns>The base damage to suffer</returns>
		/// <param name="damage">The damage actually suffered</param>
		int SufferDamage(int damage);
	}
}

