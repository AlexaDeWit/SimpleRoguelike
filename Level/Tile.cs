using System;
using BaseClasses;
using System.Collections.Generic;

namespace Levels
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
		public int X{ get; private set; }
		public int Y{ get; private set; }
		public TileType TileStyle;
		public List<Entity> Contents{ get; private set;}

		public Tile (int x, int y,Level level, TileType type){
			X = x;
			Y = y;
			_level = level;
			TileStyle = type;
			Contents = new List<Entity>();
		}
		//These will return the current tile if the adjacent tile is out of the level bounds
		//Considering changing it to a wrapping level system.
		public Tile TileRight {
			set {
				TileRight = value;
			}
			get{
				if(_level.Tiles.GetLength(0) >= this.X){
					return _level.Tiles[this.X+1][this.Y];
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
				if(this.X>0){
					return _level.Tiles[this.X-1][this.Y];
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
				if(this.Y > 0){
					return _level.Tiles[this.X][this.Y-1];
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
				if(_level.Tiles.GetLength(1) >= this.Y){
					return _level.Tiles[this.X][this.Y+1];
				}
				else{
					return this;
				}
			}
		}
	}
}