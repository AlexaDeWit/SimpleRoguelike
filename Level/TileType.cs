using System;
using BaseClasses;

namespace Level
{
	/*
	 * <summary>
	 * Defines the type for a given tile, providing its name, description, and information about
	 * whether it is pathable or not.
	 * </summary>
	 */
	public class TileType : Entity
	{
		public bool IsPathable{ get;private set; }
		public bool IsDestructable{ get;private set;}

		public TileType(string name, string description, bool pathable, bool destructable){
			Name = name;
			Description = description;
			IsPathable = pathable;
			IsDestructable = destructable;
		}
	}
}

