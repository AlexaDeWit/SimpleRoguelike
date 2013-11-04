using System;
using System.Collections.Generic;
using BaseClasses;

namespace Equipment
{
	public class Inventory
	{	
		private List<BaseClasses.Item> Items;
		public int WeightLimit{ get; set; }

		public Inventory(){
			Items = new List<Item>();
		}

		public int GetTotalWeight(){
			int sum=0;//running total
			foreach(Item oneItem in Items){
				sum += oneItem.Weight;
			}
			return sum;
		}
		public void PickUpItem (Item item)
		{
			Items.Add(item);
		}
	}

}

