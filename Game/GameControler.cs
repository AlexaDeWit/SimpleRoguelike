using System;
using Levels;
using GameRenderer;
using Enums;

namespace Game {
	public class GameControler {
		private Renderer _gameDisplay;
		private Level _currentLevel;

		/// <summary>
		/// Initializes a new instance of the <see cref="Game.GameControler"/> class.
		/// </summary>
		/// <param name="renderSystem">Render system.</param>
		/// <param name="startLevel">Level to initial begin in level.</param>
		GameControler (Renderer renderSystem) {
			_gameDisplay = renderSystem;
			//Placeholder to avoid null references
			_currentLevel = new Level (1, 1);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Game.GameControler"/> class.
		/// Does not specify a render system
		/// </summary>
		GameControler () {
			//Placeholder to avoid null references
			_currentLevel = new Level (1, 1);
		}
		/// <summary>
		/// Interprets game commands to provide abstraction between game engine logic and game control
		/// </summary>
		/// <param name="command">Game Command.</param>
		/// <param name="args">Arguments needed for that command</param>
		public void CommandInterpreter (GAME_COMMAND command, Object[] args) {
			switch (command) {
			case GAME_COMMAND.USE_CLI_DISPLAY:
				this._gameDisplay = new ConsoleRenderer (_currentLevel);
				break;
			case GAME_COMMAND.USE_GUI_DISPLAY:
				this._gameDisplay = new GraphicalRenderer (_currentLevel);
				break;
			case GAME_COMMAND.SPAWN_PLAYER:
				this.SpawnPlayer (args);
				break;
			default:
				;
			}
		}
		public void SpawnPlayer(Object[] args){
		}
	}
}

