using System;
using Characters;

namespace ItemComponents
{
	public class IGrantsEffect
	{
		void OnApplication(Character affected);
		void OnRemoval(Character affected);
	}
}

