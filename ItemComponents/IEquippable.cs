using System;
using BaseClasses;
using Constants;

namespace ItemComponents
{
	public class Equippable
	{	
		public int EquipmentSlot{ get; }
		public Equippable(int itemSlot){
			EquipmentSlot=itemSlot;
		}
	}
}

