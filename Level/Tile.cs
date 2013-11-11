using System;
using BaseClasses;
using System.Collections.Generic;

namespace Level
{
	public class Tile : Entity
	{
		private Tile[][] _tiles;
		private int _x;
		private int _y;
		public TileType TileStyle;
		public List<Entity> Contents{ get; }

		public Tile (int x, int y, Tile[][] tiles, TileType type){
			_x = x;
			_y = y;
			_tiles = tiles;
			TileStyle = type;
			Contents = new List<Entity>();
		}
		public Tile TileToTheRight {
			set;
			get{
				if(_tiles.GetLength(0) >= this._x){
					return _tiles[this._x+1][this._y];
				}
				else{
					return this;
				}
			}
		}
	}
}