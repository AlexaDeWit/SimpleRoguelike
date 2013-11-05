using System;

namespace Equipment
{
	public class Weapon : Equipment, IWeapon
	{
		
	public int MinDamageValue{ get; set; }
	public int MaxDamageValue{ get; set; }
	public bool CanCutWood{ get; set; }
	public bool CanMine{ get; set; }
		
		public Weapon ()
		{
		
		}
	}
}

