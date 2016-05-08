using System;

namespace BehaviorTree
{
	public class Node
	{
		public Node parent { get; internal set; }

		public enum Result{
			SUCCESS,
			FAILED,
			RUNNING
		}
			
		public Node ()
		{
		}

		public virtual void Initialize(DataContext context)
		{
		}

		public virtual Result Run(DataContext context)
		{
			return Result.SUCCESS;
		}

		public virtual void Handle(Node.Result result,DataContext context)
		{

			if (result == Result.SUCCESS || result == Result.FAILED) {
				if (context.NodeCount () != 0) {
					context.Pop ();
					context.Peek ().Handle (result,context);
				}
			}

		}
			
	}
}

