using System;
using System.Collections.Generic;
using Equipment;

namespace Items
{
	public enum ItemSlots { Head, Chest, Legs, Feet, Hands, Neck, RingRight, RingLeft, Weapon, Shield};


	public class Item : BaseClasses.Entity
	{
		public List<IItemComponent> Components;
		public const string MASS_UNIT = "kg";
		public int Weight{ get; set; }//expressed in Kilograms

	}
}

