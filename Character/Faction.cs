using System;
using BaseClasses;

namespace Character
{
	public class Faction : Entity
	{
		public int BaseStanding{ get; }
		public Faction(String name, String description, int initialStanding){
			this.Name=name;
			this.Description=description;
			BaseStanding = initialStanding;
		}
	}
}

