using System;

namespace BehaviorTree
{
	public class RepeatUntilFail : Decorator
	{
		public RepeatUntilFail ()
		{
		}

		public override void Handle (Result result, DataContext context)
		{
			if (result == Result.FAILED) {
				base.Handle (Result.FAILED, context);	
			}

		}


	}
}

