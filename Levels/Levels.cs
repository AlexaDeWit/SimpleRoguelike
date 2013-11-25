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
		public string Name;
		public string Description;
		public Tile[][] Tiles;
		public Level(int levelWidth,int levelHeight){
			Tiles= new Tile[levelWidth][];
			for (int i=0; i<levelWidth; i++) {
				Tiles [i] = new Tile[levelHeight];
			}
		}
		public void setTile(Tile tile, int x, int y){
			Tiles[x][y] = tile;
		}
		public int Height(){
			return this.Tiles [0].Length;
		}
		public int Width(){
			return this.Tiles.Length;
		}
	}
}
