using System;
using BaseClasses;

namespace Level
{
	public class Level : Entity
	{
		public Tile[,] Tiles;
		public Level (Tile[,] tileSet)
		{
			Tiles = tileSet;
		}
	}
}

