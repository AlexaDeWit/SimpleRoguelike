using System;
using BaseClasses;

namespace Characters
{
	/*
	 * <summary>
	 * This class represents a reputation faction, or cultural "group" within the game.
	 * A goblin tribe for instance would be a faction.
	 * </summary>
	 */
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

