using System;
using Levels;
using Characters;
using BaseClasses;
using GameRenderer;

namespace Game
{
	/*
	 * Dummy Class for the time being, intended to handle game logic
	 */
	public class Game
	{
		const int MAP_WIDTH = 15;
		const int MAP_HEIGHT = 15;

		public static void Main (String[] args)
		{
			//define a tile type of Grass
			TileType grass = new TileType ("Grass", "Some grass-covered land", true, false);
			//Create a new map, 15 by 15
			Level GameMap = new Level (MAP_WIDTH, MAP_HEIGHT);
			ConsoleRenderer renderer = new ConsoleRenderer (GameMap);

			//create a place to store references to Tiles as they are generated
			Tile tempTile;

			//fil the map with grass
			for (int x=0; x<MAP_WIDTH; x++) {
				for (int y=0; y<MAP_HEIGHT; y++) {
					tempTile = new Tile (x, y, GameMap, grass);
					GameMap.setTile (tempTile, x, y);
				}
			} 

			//Lets define a race for our character to be
			Race human = new Race ("Human", "Skinny little betas that can't fight orcs to save their lives.",10, 9, 11, 9, 12);
			//okay, race defined, lets give birth to her
			PlayerCharacter myNerd = new PlayerCharacter ("Alexa","Some nerd wasting her time.",human,GameMap.Tiles[1][1]);
			//Put her in the game world, at, say, 1,1 (not at the map edge)
			//uses mutual reference so that the player doesn not need to be "found" on the map every time
			//we wish to act on it.
			myNerd.PresentLocation = GameMap.Tiles [1] [1];
			GameMap.Tiles [1] [1].Contents.Add (myNerd);

			renderer.WriteToConsole ();


			//Lets try moving her to the right.
			myNerd.Move (myNerd.PresentLocation.TileRight);
		}

	}
}

