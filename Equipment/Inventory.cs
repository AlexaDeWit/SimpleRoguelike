using System;
using System.Collections.Generic;
using BaseClasses;

namespace Equipment
{
	public class Inventory
	{
		private List<BaseClasses.Item> _items;
		public int _weightLimit{ get; set; }
		public int TotalWeight(){
			int sum=0;//running total
			foreach(Item oneItem in _items){
				sum += oneItem._weight;
			}
			return sum;
		}
		public void PickUpItem (Item item)
		{
			_items.Add(item);
		}
		public Inventory(){
			_items = new List<Item>();
		}
	}

}

