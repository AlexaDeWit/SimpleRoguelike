using System;
using BaseClasses;


namespace Level
{
	public class LevelTransition : Entity
	{
		public Level TargetLevel;
		public LevelTransition(Level target){
			TargetLevel = target;
		}

	}

}

