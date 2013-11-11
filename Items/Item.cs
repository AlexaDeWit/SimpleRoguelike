using System;
using System.Collections.Generic;
using ItemComponents;

namespace Items
{

	public class Item : BaseClasses.Entity
	{
		//The behaviour of this item is entirely defined
		//By what components it is given
		public List<IItemComponent> Components;
	}
}

