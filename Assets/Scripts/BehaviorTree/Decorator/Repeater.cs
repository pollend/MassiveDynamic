using System;

namespace BehaviorTree
{
	public class Repeater : Decorator
	{
		public override void Handle (Result result, DataContext context)
		{
			//don't handle anything
		}

		public override Result Run (DataContext context)
		{
			
			return base.Run (context);
		}
		
	}
}

