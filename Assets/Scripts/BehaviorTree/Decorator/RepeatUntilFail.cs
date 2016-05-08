using System;

namespace BehaviorTree
{
	public class RepeatUntilFail : Decorator
	{
		public RepeatUntilFail (Node n) : base(n)
		{
		}

		public override void Handle (Result result, DataContext context,Node prev)
		{
			//don't handle the success case and just pass the node up if the pass failes
			if (result == Result.FAILED) {
				base.Handle (Result.FAILED, context,this);	
			}

		}


	}
}

