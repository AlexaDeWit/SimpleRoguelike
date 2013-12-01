using System;
using Levels;

namespace GameRenderer {
	public class Renderer {
		protected Level _level;
		public Renderer(Level levelToRender){
			_level = levelToRender;
		}
		public void SetLevel(Level newLevel){
			_level =newLevel;
		}
	}
}

