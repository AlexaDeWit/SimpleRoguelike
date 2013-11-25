using System;
using BaseClasses;

namespace Levels
{
	/// <summary>
	/// Defines a 2 dimensional grid of tiles that entities move around within.
	/// Does not contain tile objects upon creation because it would create a mutual dependency.
	/// The tile objects are intended to be able to reference eachother almost directly, and to this 
	/// end must be passed a level object to "know where they are"
	/// </summary>
	public class Level
	{
		/// <summary>
		/// The name of the level
		/// </summary>
		public string Name;
		/// <summary>
		/// The description of the level
		/// </summary>
		public string Description;
		/// <summary>
		/// A 2 dimensional grid of square tiles which make up the level
		/// </summary>
		public Tile[][] Tiles;
		/// <summary>
		/// Initializes a new instance of the <see cref="Levels.Level"/> class.
		/// Important note: The level upon construction does not contain any actual tiles. 
		/// It must be populated by tiles after creation.
		/// </summary>
		/// <param name="levelWidth">Level width.</param>
		/// <param name="levelHeight">Level height.</param>
		public Level(int levelWidth,int levelHeight){
			Tiles= new Tile[levelWidth][];
			for (int i=0; i<levelWidth; i++) {
				Tiles [i] = new Tile[levelHeight];
			}
		}
		/// <summary>
		/// Assigns a tile to a given co-ordinate in the level
		/// </summary>
		/// <param name="tile">Tile.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void setTile(Tile tile, int x, int y){
			Tiles[x][y] = tile;
		}
		/// <summary>
		/// Height of the level(in tiles)
		/// </summary>
		public int Height(){
			return this.Tiles [0].Length;
		}
		/// <summary>
		/// Width of the level(in tiles)
		/// </summary>
		public int Width(){
			return this.Tiles.Length;
		}
	}
}

