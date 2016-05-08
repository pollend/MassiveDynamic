using System;
using BehaviorTree;

namespace AssemblyCSharp
{
	public class RetrySelector : CompositNode
	{
		protected Node node;
		int actionIndex;

		public RetrySelector (Node n,Node[] nodes) : base(nodes)
		{
			this.node = n;
		}

		public override void Handle (Result result, DataContext context,Node prev)
		{
			if (result == Result.SUCCESS) {
				if (node == prev) {
					Reset ();
					context.Pop ();
					context.Peek ().Handle (Result.SUCCESS, context, this);
				} else {
					Reset ();
					context.PushNode (node);
				}

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
			return base.Run (context);
		}
	}
}

