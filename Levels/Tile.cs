using System;
using BaseClasses;
using System.Collections.Generic;
using System.Linq;

namespace Levels
{
	/// <summary>
	/// An individual tile in the game world. 
	/// All items on the tile are contained within a single list in this class.
	/// The object also contains a reference to the level is is located on, as well as its
	/// position within that level.
	/// </summary>
	public class Tile 
	{
		/// <summary>
		/// Gets the level the tile is present on
		/// </summary>
		/// <value>The level the tile is present on.</value>
		public Level LevelPresent{ get; private set; }
		/// <summary>
		/// The horizontal location of the tile in the level.
		/// </summary>
		/// <value>The horizontal location of the tile in the level.</value>
		public int X{ get; private set; }
		/// <summary>
		/// The vertical location of the tile in the level.
		/// </summary>
		/// <value>The vertical location of the tile in the level.</value>
		public int Y{ get; private set; }
		/// <summary>
		/// A tile style definition object. <see cref="Levels.TileType"/>
		/// </summary>
		public TileType TileStyle{get; private set;}
		/// <summary>
		/// Gets the contents.
		/// </summary>
		/// <value>The contents.</value>
		public List<Entity> Contents{ get; private set;}
		/// <summary>
		/// Initializes a new instance of the <see cref="Levels.Tile"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="level">The level this tile will be present in</param>
		/// <param name="type">The style of tile it is</param>
		public Tile (int x, int y,Level level, TileType type){
			X = x;
			Y = y;
			LevelPresent = level;
			TileStyle = type;
			Contents = new List<Entity>();
		}
		/// <summary>
		/// Gets the adjecent tile to the right of this one
		/// It will return itself it it attempts to "reach" off the map
		/// </summary>
		/// <value>The tile to the right.</value>
		public Tile TileRight {
			get{
				if(LevelPresent.Tiles.GetLength(0) >= this.X){
					return LevelPresent.Tiles[this.X+1][this.Y];
				}
				else{
					return this;
				}
			}
		}
		/// <summary>
		/// Gets the adjecent tile to the left of this one
		/// It will return itself it it attempts to "reach" off the map
		/// </summary>
		/// <value>The tile to the left.</value>
		public Tile TileLeft {
			set {
				TileLeft = value;
			}
			get{
				if(this.X>0){
					return LevelPresent.Tiles[this.X-1][this.Y];
				}
				else{
					return this;
				}
			}
		}
		/// <summary>
		/// Gets the adjecent tile to above this one
		/// It will return itself it it attempts to "reach" off the map
		/// </summary>
		/// <value>The tile above/value>
		public Tile TileAbove {
			set {
				TileAbove = value;
			}
			get{
				if(this.Y > 0){
					return LevelPresent.Tiles[this.X][this.Y-1];
				}
				else{
					return this;
				}
			}
		}
		/// <summary>
		/// Gets the adjecent tile below of this one
		/// It will return itself it it attempts to "reach" off the map
		/// </summary>
		/// <value>The tile below.</value>
		public Tile TileBelow {
			set{
				TileBelow = value;
			}
			get{
				if(LevelPresent.Tiles.GetLength(1) >= this.Y){
					return LevelPresent.Tiles[this.X][this.Y+1];
				}
				else{
					return this;
				}
			}
		}
		public bool ContainsType<T> () where T: Entity{
			if (Contents.OfType<T> ().Count () > 0) {
				return true;
			}
			return false;
		}
		public T FirstEntityOfType<T>() where T: Entity	{
			return Contents.OfType<T> ().FirstOrDefault ();
		}
	}
}