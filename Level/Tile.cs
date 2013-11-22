using System;
using BaseClasses;
using System.Collections.Generic;

namespace Level
{
	/*
	 * <summary>
	 * An individual tile in the game world. 
	 * Uses 4 methods to return its adjacent tiles by referencing its containing level
	 * </summary>
	 */
	public class Tile 
	{
		private Level _level;
		private int _x;
		private int _y;
		public TileType TileStyle;
		public List<Entity> Contents{ get; private set;}

		public Tile (int x, int y,Level level, TileType type){
			_x = x;
			_y = y;
			_level = level;
			TileStyle = type;
			Contents = new List<Entity>();
		}
		public void MoveEntity (Tile destination, Entity entity)
		{
			destination.Contents.Add(entity);
			this.Contents.Remove(entity);
		}
		//These will return the current tile if the adjacent tile is out of the level bounds
		//Considering changing it to a wrapping level system.
		public Tile TileRight {
			set {
				TileRight = value;
			}
			get{
				if(_level.Tiles.GetLength(0) >= this._x){
					return _level.Tiles[this._x+1][this._y];
				}
				else{
					return this;
				}
			}
		}
		public Tile TileLeft {
			set {
				TileLeft = value;
			}
			get{
				if(this._x>0){
					return _level.Tiles[this._x-1][this._y];
				}
				else{
					return this;
				}
			}
		}
		public Tile TileAbove {
			set {
				TileAbove = value;
			}
			get{
				if(this._y > 0){
					return _level.Tiles[this._x][this._y-1];
				}
				else{
					return this;
				}
			}
		}
		public Tile TileBelow {
			set{
				TileBelow = value;
			}
			get{
				if(_level.Tiles.GetLength(1) >= this._y){
					return _level.Tiles[this._x][this._y+1];
				}
				else{
					return this;
				}
			}
		}
	}
}