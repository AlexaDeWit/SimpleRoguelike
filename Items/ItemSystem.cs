using System;
using ItemComponents;
using Characters;
using System.Linq;
using Constants;
using System.Collections.Generic;

namespace Items
{
	public static class ItemSystem
	{
		public static bool EquipItem (Item item, PlayerCharacter character)
		{
			if (item.Supports<Equippable> ()) {
				ApplyEffects(item,character);
				character.EquippedItems.Add(item);
			}
		}
		public static bool ApplyEffects (Item item, Character character)
		{
			//Am I doing this right?
			//Components is a List of Type IItemComponent from which IGrantsEffect is inherited
			List<IGrantsEffect> effects = item.Components.OfType<IGrantsEffect>().All();
			foreach (IGrantsEffect effect in effects) {
				effect.ApplyEffect(character);
			}
		}
		public static bool RemoveEffects(Item item, Character character){
		}
		public static int ItemSlot<T> (Item item) where T: Equippable
		{
			T component = item.Components.OfType<T> ().FirstOrDefault ();
			if (component != null) {
				return component.EquipmentSlot;
			} else {
				return ITEM_SLOT.NONE;
			}
		}
		public static void UnequipItem(Item item, PlayerCharacter character){
			RemoveEffects(item,character);
			character.EquippedItems.Remove(item);
		}
	}
}

