using System;
using BaseClasses;


namespace Levels
{
	public class LevelTransition : Entity
	{
		public Level TargetLevel;
		public override string Name {
			set {
				TargetLevel.Name = value;
			}
			get {
				return TargetLevel.Name;
			}
		}
		public override string Description {
			set {
				TargetLevel.Description = value;
			}
			get {
				return TargetLevel.Description;
			}
		}
		public LevelTransition(Level target){
			TargetLevel = target;
		}

	}

}

