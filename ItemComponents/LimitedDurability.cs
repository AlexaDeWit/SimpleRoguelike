using System;

namespace ItemComponents {
	/// <summary>
	/// Specifies that an item will have limited durability before it breaks
	/// </summary>
	public class LimitedDurability : IDestructible{
		/// <summary>
		/// Gets the max durability.
		/// </summary>
		/// <value>The max durability.</value>
		public int MaxDurability{ get; private set;}
		/// <summary>
		/// Gets the durability remaining.
		/// </summary>
		/// <value>The durability remaining.</value>
		public int DurabilityRemaining{ get; private set;}
		/// <summary>
		/// Gets a value indicating whether this <see cref="ItemComponents.IDestructible"/> destroy condition is met.
		/// </summary>
		/// <value><c>true</c> if destroy condition is met; otherwise, <c>false</c>.</value>
		public bool DestroyConditionMet{ get; private set;}
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemComponents.LimitedDurability"/> class.
		/// </summary>
		/// <param name="durability">The maximum durability points of the item</param>
		public LimitedDurability (int durability) {
			MaxDurability = durability;
			DurabilityRemaining = MaxDurability;
			DestroyConditionMet = false;
		}
		/// <summary>
		/// Damages the item a specific number of durability points
		/// </summary>
		/// <param name="damage">Damage to inflict on the item</param>
		public void DamageItem(int damage){
			DurabilityRemaining -= damage;
			if (DurabilityRemaining <= 0) {
				DestroyConditionMet = true;
			}
		}
		/// <summary>
		/// Repairs the item a specific number of durability points
		/// </summary>
		/// <returns>Any repairing overflow(trying to repair beyond max durability)</returns>
		/// <param name="repairAmount">Repair amount.</param>
		public int RepairItem(int repairAmount){
			if (DurabilityRemaining + repairAmount > MaxDurability) {
				DurabilityRemaining = MaxDurability;
				return repairAmount + DurabilityRemaining - MaxDurability;
			}else{
				return 0;
			}
		}
	}
}

