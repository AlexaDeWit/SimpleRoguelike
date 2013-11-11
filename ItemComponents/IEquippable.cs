using System;
using BaseClasses;

namespace ItemComponents
{
	public interface IEquippable
	{	
		void OnEquip();
		void OnUnequip();
	}
}

