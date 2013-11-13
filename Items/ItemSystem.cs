using System;
using ItemComponents;
using Characters;
using System.Linq;
using Constants;
using System.Collections.Generic;
using Enums;

namespace Items
{
	public static class ItemSystem
	{
		public static bool EquipItem (Item item, PlayerCharacter character)
		{
			if (item.Supports<Equippable> ()) {
				ApplyEffects(item,character);
				character.EquippedItems.Add(item);
				return true;
			}
			return false;
		}
		public static bool ApplyEffects (Item item, Character character)
		{
			//Am I doing this right?
			//Components is a List of Type IItemComponent from which IGrantsEffect is inherited
			List<IGrantsEffect> effects = item.Components.OfType<IGrantsEffect>().ToList();
			foreach (IGrantsEffect effect in effects) {
				effect.ApplyEffect(character);
			}
			return true;
		}
		public static bool RemoveEffects(Item item, Character character){
			return true;
		}
		public static ItemEnums.ITEM_SLOT ItemSlot<T> (Item item) where T: Equippable
		{
			T component = item.Components.OfType<T> ().FirstOrDefault ();
			if (component != null) {
				return component.EquipmentSlot;
			} else {
				return ItemEnums.ITEM_SLOT.NONE;
			}
		}
		public static void UnequipItem(Item item, PlayerCharacter character){
			RemoveEffects(item,character);
			character.EquippedItems.Remove(item);
		}
	}
}

