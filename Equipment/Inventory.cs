using System;
using System.Collections.Generic;
using Items;

namespace Equipment
{
	public class Inventory
	{	
		private List<Item> Items;
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
		public bool PickUpItem (Item item)
		{
			if (item.Weight + GetTotalWeight () > WeightLimit) {
				return false;
			} else {
				Items.Add (item);
			}
		}
	}

}

