using System;

namespace BehaviorTree
{
	public class CompositNode : Node
	{
		protected Node[] nodes;

		public CompositNode (Node[] nodes)
		{
			this.nodes = nodes;
		}



		public override void Initialize (DataContext context)
		{
			foreach (Node n in nodes) {
				n.parent = this;
				n.Initialize (context);
			}
			base.Initialize (context);
		}

		public override void Handle (Result result, DataContext context)
		{
			
		}

		public override Result Run (DataContext context)
		{
			return Result.RUNNING;
		}

	}
}

