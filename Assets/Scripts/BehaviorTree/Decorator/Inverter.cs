using System;

namespace BehaviorTree
{
	public class Inverter : Decorator
	{
		public Inverter (Node n) : base(n)
		{
		}

		public override void Handle (Result result,DataContext context)
		{
			if (result == Result.FAILED) {
				base.Handle (Result.SUCCESS, context);
			} else if (result == Result.SUCCESS) {
				base.Handle (Result.FAILED, context);
			}
			
		}
			
	

	}
}

