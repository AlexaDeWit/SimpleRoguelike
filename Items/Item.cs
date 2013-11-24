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
	 * The item class. This uses a component system whereby all the characteristics of
	 * an item and provided by the items components and can be compined in many ways.
	 * Some components do not support duplication. Reference the component documentation
	 * for specific details.
	 * </summary>
	 */
	public class Item : BaseClasses.Entity
	{

		public float Mass{ get; private set;}
		public ITEM_SLOT EquipSlot{ get; private set; } //May be ITEM_SLOT.NONE
		//Components providing the item's characteristics
		public List<IItemComponent> Components;
		public Effect ItemEffect;
		public bool DeleteFlag{ get; private set; } //Flags the item as needing to be removed
	

		public Item(string name, string description, float mass, List<IItemComponent> components, ITEM_SLOT slot){
			Name = name;
			Description = description;
			Mass = mass;
			Components=components;
			EquipSlot = slot;
			ItemEffect = new Effect();

			foreach (IGrantsEffect component in this.ComponentsOfType<IGrantsEffect>()) {
				component.ApplyEffect (this);
			}
		}
		//implicit super constructors are sly devils.
		public List<T> ComponentsOfType<T> () where T : IItemComponent	{
			return Components.OfType<T>().ToList();
		}


		public T FirstComponentOf<T>() where T: IItemComponent	{
			return Components.OfType<T> ().FirstOrDefault ();
		}


		//Does this Item support this component's features:
		public bool Supports<T> () where T:IItemComponent{
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


		public bool EquipTo (PlayerCharacter character)	{
			if (this.EquipSlot != ITEM_SLOT.NONE && (!character.EquippedItems.Contains(this))) {
				character.StatusEffects.Add (this.ItemEffect);
				character.EquippedItems.Add(this);
				if (this.Supports<ContributesDamage> ()) {
					character.DamageComponents.Add (this.ItemEffect.DamageComponent);
				}
				return true;
			}
			return false;
		}


		public void UnequipFrom(PlayerCharacter character){
			if(character.EquippedItems.Contains(this)){
				character.StatusEffects.Remove(this.ItemEffect);
				character.EquippedItems.Remove(this);
				if (this.Supports<ContributesDamage> () && 
				    	character.DamageComponents.Contains(this.ItemEffect.DamageComponent)) {
					character.DamageComponents.Remove (this.ItemEffect.DamageComponent);
				}
			}
		}


		public void ConsumeCharge(){
			foreach (Consumeable consumeEffect in this.ComponentsOfType<Consumeable>()) {
				consumeEffect.ConsumeCharge ();
				if (consumeEffect.DestroyConditionMet) {
					this.DeleteFlag = true;
				}
			}
			this.Update ();
		}
	}
}

