using System;
using BaseClasses;

namespace Level
{
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

