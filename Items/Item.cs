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
	}
}

