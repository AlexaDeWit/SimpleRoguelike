using System;
using BaseClasses;

namespace Characters
{
	public class Faction : Entity
	{
		public int BaseStanding{ get; private set;}
		public Faction(String name, String description, int initialStanding){
			this.Name=name;
			this.Description=description;
			BaseStanding = initialStanding;
		}
	}
}

