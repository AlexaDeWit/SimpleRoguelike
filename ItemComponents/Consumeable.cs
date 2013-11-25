using System;
using Characters;
using Items;

namespace ItemComponents
{
	/// <summary>
	/// Gives an item the functionality to be consumed.
	/// Needed for things such as food and potions.
	/// </summary>
	public class Consumeable : IGrantsEffect, IDestructible
	{
		/// <summary>
		/// Gets the filling(reduction in hunger)
		/// </summary>
		/// <value>The amount of hunger that consuming this item reduces</value>
		public int Filling{ get; private set;}
		/// <summary>
		/// If the item that is using this component definiton should be destroyed when possible.
		/// For example.. once the bread is eaten, consuming this component, the bread Item should not be in 
		/// anyone's inventory
		/// </summary>
		/// <value><c>true</c> if destroy condition met; otherwise, <c>false</c>.</value>
		public bool DestroyConditionMet{ get; private set; }
		private int _chargesRemaining;
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemComponents.Consumeable"/> class.
		/// </summary>
		/// <param name="filling">How filling the item is</param>
		/// <param name="charges">How many charges before it is fully consumed</param>
		public Consumeable (int filling,int charges)
		{
			Filling = filling;
			DestroyConditionMet = false;
			_chargesRemaining = charges;
		}
		/// <summary>
		/// Adds the effect this component has to an item(generally will be the parent item)
		/// </summary>
		/// <param name="affected">Item to accept the effect</param>
		public void ApplyEffect(Item affected){
			affected.ItemEffect.Filling += Filling;
		}
		/// <summary>
		/// Removes the effect this component has from an item(generally will be the parent item)
		/// </summary>
		/// <param name="affected">Item to lose the effect</param>
		public void RemoveEffect(Item affected){
			affected.ItemEffect.Filling -= Filling;
		}
		/// <summary>
		/// Uses up one charge of the component, and updates its destroy condition.
		/// </summary>
		public void ConsumeCharge(){
			this._chargesRemaining -= 1;
			if (this._chargesRemaining < 1) {
				DestroyConditionMet = true;
			}
		}
	}
}

