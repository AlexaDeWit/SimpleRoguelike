using System;
using BaseClasses;
using Constants;

namespace ItemComponents
{
	public class Equippable : IItemComponent
	{	
		public int EquipmentSlot{ get; private set;}
		public Equippable(int itemSlot){
			EquipmentSlot=itemSlot;
		}
	}
}

