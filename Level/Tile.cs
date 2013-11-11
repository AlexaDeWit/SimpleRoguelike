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
		//These will return the current tile if the adjacent tile is out of the level bounds
		//Considering changing it to a wrapping level system.
		public Tile TileRight {
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
		public Tile TileLeft {
			set;
			get{
				if(this._x>0){
					return _tiles[this._x-1][this._y];
				}
				else{
					return this;
				}
			}
		}
		public Tile TileAbove {
			set;
			get{
				if(this._y > 0){
					return _tiles[this._x][this._y-1];
				}
				else{
					return this;
				}
			}
		}
		public Tile TileBelow {
			set;
			get{
				if(_tiles.GetLength(1) >= this._y){
					return _tiles[this._x][this._y+1];
				}
				else{
					return this;
				}
			}
		}

	}
}