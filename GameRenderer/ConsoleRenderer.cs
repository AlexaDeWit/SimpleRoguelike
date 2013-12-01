using System;
using Levels;
using Characters;

namespace GameRenderer {
	public class ConsoleRenderer : Renderer {

		public ConsoleRenderer(Level levelToRender): base(levelToRender){
		}

		public void WriteToConsole(){
			for (int x=0; x<_level.Width(); x++) {
				for (int y=0; y<_level.Height(); y++) {
					Console.Write(SingleTileConverter(_level.Tiles[x][y]));
				}
				Console.WriteLine ();
			}
		}
		private string SingleTileConverter(Tile someTile){
			if (someTile.ContainsType<PlayerCharacter> ()) {
				return "U";
			}
			if (someTile.ContainsType<NonPlayerCharacter> ()) {
				return "H";
			}
			switch (someTile.TileStyle.Name.ToLower()) {
			case "grass":
				return "G";
			default:
				return "?";
			}
		}
	}
}

