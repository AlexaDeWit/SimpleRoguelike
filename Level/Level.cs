using System;
using BaseClasses;

namespace Level
{
	public class Level
	{
		public Tile[][] _tiles;
		public Level (Tile[][] tileSet)
		{
			_tiles = tileSet;
		}
	}
}

