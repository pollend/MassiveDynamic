using System;

namespace BehaviorTree
{
	public class BehaviorTree
	{
		private Node root;
		private DataContext context;
		public BehaviorTree (Node root)
		{
			this.context = new DataContext ();
			this.root = root;
			this.context.PushNode (root);
		}

		public void Tick()
		{
			Node.Result result =  this.context.Peek ().Run (this.context);
			if (result == Node.Result.FAILED || result == Node.Result.SUCCESS)
				this.context.Pop ();
			this.context.Peek ().Handle(result,context);
		}
	}
}

