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
	public class Faction
	{
		public string Name;
		public string Description;
		public int BaseStanding{ get; private set;}
		public Faction(String name, String description, int initialStanding){
			Name=name;
			Description=description;
			BaseStanding = initialStanding;
		}
	}
}

