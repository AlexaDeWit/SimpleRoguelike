using System;
using BaseClasses;

namespace Equipment
{
	public interface IEquippable
	{	
		void OnEquip();
		void OnUnequip();
	}
}

