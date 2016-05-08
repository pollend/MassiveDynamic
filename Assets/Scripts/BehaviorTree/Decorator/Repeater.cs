using System;

namespace BehaviorTree
{
	public class Repeater : Decorator
	{
		public Repeater(Node n) :base(n)
		{
		}

		public override void Handle (Result result, DataContext context,Node prev)
		{
			//don't handle anything
		}

		public override Result Run (DataContext context)
		{
			
			return base.Run (context);
		}
		
	}
}

