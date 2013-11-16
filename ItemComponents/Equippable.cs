using System;
using BaseClasses;
using Enums;

namespace ItemComponents
{
	/*
	 * <summary>
	 * Allows items to be equipped to a character
	 * </summary>
	 */
	public class Equippable : IItemComponent
	{	
		public ItemEnums.ITEM_SLOT EquipmentSlot{ get; private set;}
		public Equippable(ItemEnums.ITEM_SLOT itemSlot){
			EquipmentSlot=itemSlot;
		}
	}
}

