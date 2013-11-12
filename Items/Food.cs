using System;
using System.Collections.Generic;
using ItemComponents;

namespace Items
{
	public class Food : Item
	{
		public Food(List<IItemComponent> components){
			Components=components;
		}
	}
}

