using System;
using System.Collections.Generic;
using System.Linq;
using ItemComponents;
using Characters;
using Enums;

namespace Items
{
	/*
	 * <summary>
	 * The item class. This uses a component system whereby all characteristics
	 * of an item are defined by its components, and managed by an axternal system.
	 * </summary>
	 */
	public class Item : BaseClasses.Entity
	{
		//The behaviour of this item is entirely defined
		//By what components it is given
		public List<IItemComponent> Components;
		//Get me the component requested by type
		public Item(List<IItemComponent> components){
			Components=components;
		}
		//implicit super constructors are sly devils.
		public T Component<T> () where T : IItemComponent
		{
			return Components.OfType<T>().FirstOrDefault();
		}
		//Does this Item support this component's features:
		public bool Supports<T> () where T:IItemComponent
		{
			if (Components.OfType<T> ().Count () > 0) {
				return true;
			}
			return false;
		}


		public static bool Equip (PlayerCharacter character)
		{
			if (this.Supports<Equippable> ()) {
				this.ApplyEffects(character);
				character.EquippedItems.Add(this);
				return true;
			}
			return false;
		}
		public static bool ApplyEffects (Character character)
		{
			//Am I doing this right?
			//Components is a List of Type IItemComponent from which IGrantsEffect is inherited
			List<IGrantsEffect> effects = this.Components.OfType<IGrantsEffect>().ToList();
			foreach (IGrantsEffect effect in effects) {
				effect.ApplyEffect(character);
			}
			return true;
		}
		public static bool RemoveEffects(Character character){
			List<IGrantsEffect> effects = this.Components.OfType<IGrantsEffect>().ToList();
			foreach (IGrantsEffect effect in effects) {
				effect.RemoveEffect(character);
			}
			return true;
		}
		public static ItemEnums.ITEM_SLOT ItemSlot<T>() where T: Equippable
		{
			T component = this.Components.OfType<T> ().FirstOrDefault ();
			if (component != null) {
				return component.EquipmentSlot;
			} else {
				return ItemEnums.ITEM_SLOT.NONE;
			}
		}
		public static void UnequipItem(PlayerCharacter character){
			this.RemoveEffects(character);
			character.EquippedItems.Remove(this);
		}
	}
}

