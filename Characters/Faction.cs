using System;
using BaseClasses;

namespace Characters
{
	/// <summary>
	///	This class represents a reputation faction, or cultural "group" within the game.
	/// A goblin tribe for instance would be a faction.
	/// </summary>
	public class Faction
	{
		/// <summary>
		/// The name of the faction
		/// </summary>
		public string Name{ get; private set;}
		/// <summary>
		/// A full description of the faction
		/// </summary>
		public string Description{ get; private set; }
		/// <summary>
		/// The standing that a character will be assumed to have with the faction until modified by actions
		/// </summary>
		/// <value>The base standing.</value>
		public int BaseStanding{ get; private set;}
		/// <summary>
		/// Initializes a new instance of the <see cref="Characters.Faction"/> class.
		/// </summary>
		/// <param name="name">The name of the faction</param>
		/// <param name="description">A full description of the faction</param>
		/// <param name="initialStanding">The standing that a character will be assumed to have with the faction until modified by actions</param>
		public Faction(String name, String description, int initialStanding){
			Name=name;
			Description=description;
			BaseStanding = initialStanding;
		}
	}
}

