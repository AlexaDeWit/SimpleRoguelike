using System;

namespace ItemComponents
{
	public interface IDestructible : IItemComponent
	{
		bool DestroyConditionMet{ get;}
	}
}

