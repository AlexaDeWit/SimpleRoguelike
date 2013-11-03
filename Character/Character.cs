using System;
using Equipment;

namespace Character
{
	public abstract class Character : BaseClasses.Entity 
	{
		//Character Stats
		public BaseClasses.Race _race{ get; set; }
		public int _health{ get; set; }
		public int _mana{ get; set; }
		public int _level{get;set;}


		public Faction _faction{ get; set; }

		//Currently Equipped

        public Weapon _weapon { get; set; }
		public Armour _helm{ get; set; }
		public Armour _boots{ get; set; }
		public Armour _chest{ get; set; }
		public Armour _pants{ get; set; }
        public Shield _shield { get; set; }
        public Accessory _ring { get; set; }
        public Accessory _neck { get; set; }

		//Wallet
		public long _currency{ get; set; }



        public void SetLoadout(Armour helm, Armour boots, Armour chest, Armour pants, Weapon weapon, Accessory ring, Accessory neck)
        {
			_helm = helm;
			_boots = boots;
			_chest = chest;
			_pants = pants;
			_weapon = weapon;
            _ring = ring;
            _neck = neck;
		}
	}

}

