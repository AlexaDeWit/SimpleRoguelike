using System;
using Equipment;

namespace Character
{
	public class Character : BaseClasses.Entity, BaseInterfaces.IAttackable
	{
		public BaseClasses.Race _race{ get; set; }
		public Armour _helm{ get; set; }
		public Weapon _weapon{ get; set; }
		public Armour  _boots{ get; set; }
		public Armour  _chest{ get; set; }
		public Armour  _pants{ get; set; }
		public int _health{ get; set; }
		public int _mana{ get; set; }
		public Faction _faction{ get; set; }
		public long _currency{ get; set; }
		private Inventory _inventory{ get; set; }


		public void SetLoadout(Armour helm, Armour boots, Armour chest, Armour pants, Weapon weapon){
			_helm = helm;
			_boots = boots;
			_chest = chest;
			_pants = pants;
			_weapon = weapon;
		}
	}

}

