using System;

namespace BehaviorTree
{
	/**
	 * only returns success when a single node passes else fails when every thing else fails
	 **/
	public class Selector : CompositNode
	{
		int actionIndex;

		public Selector (Node[] nodes) : base(nodes)
		{
		}

		public override void Handle (Result result, DataContext context,Node prev)
		{
			if (result == Result.SUCCESS) {
				Reset ();
				context.Pop ();
				context.Peek ().Handle (Result.SUCCESS, context,this);

			} else if (result == Result.FAILED) {
				if (++actionIndex >= nodes.Length) {
					Reset ();
					context.Pop ();
					context.Peek ().Handle (Result.FAILED, context,this);
				} else {
					context.PushNode (nodes [actionIndex]);
				}
			}

			base.Handle (result, context,this);
		}

		private void Reset()
		{
			this.actionIndex = 0;
		}

		public override Result Run (DataContext context)
		{
			if (context.Peek() == this) {
				context.PushNode (nodes [0]);
			}
			return Result.RUNNING;
		}
	}
}

