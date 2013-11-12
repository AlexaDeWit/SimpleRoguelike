using System;
using System.Collections.Generic;
using System.Linq;
using ItemComponents;

namespace Items
{

	public class Item : BaseClasses.Entity
	{
		//The behaviour of this item is entirely defined
		//By what components it is given
		public List<IItemComponent> Components;
		//Get me the component requested by type
		public Item(List<IItemComponent> components){
			Components=components;
		}
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
	}
}

