using System;
using BaseClasses;

namespace Levels
{
	/// <summary>
	/// Defines the type for a given tile, providing its name, description, and information about
	/// whether it is pathable or not.
	/// </summary>
	public class TileType
	{
		/// <summary>
		/// The name of the tile style. 
		/// ie. "Grass"
		/// </summary>
		public string Name;
		/// <summary>
		/// A description of the tile style.
		/// ie. "Smooth plains covered with sparse grass."
		/// </summary>
		public string Description;
		/// <summary>
		/// Gets a value indicating whether this tile type is pathable.
		/// </summary>
		/// <value><c>true</c> if this tile type is pathable; otherwise, <c>false</c>.</value>
		public bool IsPathable{ get;private set; }
		/// <summary>
		/// Gets a value indicating whether this tile type is destructable.
		/// </summary>
		/// <value><c>true</c> if this tile type is destructable; otherwise, <c>false</c>.</value>
		public bool IsDestructable{ get;private set;}
		/// <summary>
		/// Initializes a new instance of the <see cref="Levels.TileType"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="description">Description.</param>
		/// <param name="pathable">If set to <c>true</c> pathable.</param>
		/// <param name="destructable">If set to <c>true</c> destructable.</param>
		public TileType(string name, string description, bool pathable, bool destructable){
			Name = name;
			Description = description;
			IsPathable = pathable;
			IsDestructable = destructable;
		}
	}
}

