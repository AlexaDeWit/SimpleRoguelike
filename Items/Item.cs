using System;
using System.Collections.Generic;
using System.Linq;
using ItemComponents;
using Characters;
using Enums;
using Effects;

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

		public float Mass{ get; private set;}
		public ITEM_SLOT EquipSlot{ get; private set; }
		//The behaviour of this item is entirely defined
		//By what components it is given
		public List<IItemComponent> Components;
		public Effect ItemEffect;
		public bool DeleteFlag{ get; private set; }
		//Get me the component requested by type
		public Item(string name, string description, float mass, List<IItemComponent> components, ITEM_SLOT slot){
			Name = name;
			Description = description;
			Mass = mass;
			Components=components;
			EquipSlot = slot;
			ItemEffect = new Effect();

			foreach (IGrantsEffect component in this.ComponentsOfType<IGrantsEffect>()) {
				component.ApplyEffect (this.ItemEffect);
			}
		}
		//implicit super constructors are sly devils.
		public List<T> ComponentsOfType<T> () where T : IItemComponent
		{
			return Components.OfType<T>().ToList();
		}
		public T FirstComponentOf<T>() where T: IItemComponent
		{
			return Components.OfType<T> ().FirstOrDefault ();
		}
		//Does this Item support this component's features:
		public bool Supports<T> () where T:IItemComponent
		{
			if (Components.OfType<T> ().Count () > 0) {
				return true;
			}
			return false;
		}
		public void Update(){
			foreach (IDestructible destroyFlag in this.ComponentsOfType<IDestructible>()) {
				if (destroyFlag.DestroyConditionMet) {
					this.DeleteFlag = true;
				}
			}
		}

		public bool EquipTo (PlayerCharacter character)
		{
			if (this.EquipSlot != ITEM_SLOT.NONE && (!character.EquippedItems.Contains(this))) {
				character.StatusEffects.Add (this.ItemEffect);
				character.EquippedItems.Add(this);
				return true;
			}
			return false;
		}
		public void UnequipFrom(PlayerCharacter character){
			if(character.EquippedItems.Contains(this)){
				character.StatusEffects.Remove(this.ItemEffect);
				character.EquippedItems.Remove(this);
			}
		}
//		public bool ApplyEffects (Character character)
//		{
//			//Am I doing this right?
//			//Components is a List of Type IItemComponent from which IGrantsEffect is inherited
//			List<IGrantsEffect> effects = this.Components.OfType<IGrantsEffect>().ToList();
//			foreach (IGrantsEffect effect in effects) {
//				effect.ApplyEffect(character);
//			}
//			return true;
//		}
//		public bool RemoveEffects(Character character){
//			List<IGrantsEffect> effects = this.Components.OfType<IGrantsEffect>().ToList();
//			foreach (IGrantsEffect effect in effects) {
//				effect.RemoveEffect(character);
//			}
//			return true;
//		}
	}
}

