using System;
using BehaviorTree;

namespace BehaviorTree
{
	public class Decorator : Node
	{
		protected Node node;

		public Decorator (Node n)
		{
			this.node = n;
		}


		public override void Initialize (DataContext context)
		{
			node.parent = this;
			node.Initialize (context);
			base.Initialize (context);
		}

		public override Result Run (DataContext context)
		{
			if (context.Peek () == this) {
				context.PushNode (this.node);
			}
			return Result.RUNNING;
		}

	}
}

