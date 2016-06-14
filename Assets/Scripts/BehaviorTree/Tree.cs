using System;

namespace BehaviorTree
{
	public class Tree
	{
		private Node root;
		private DataContext context;
		public Tree (Node root)
		{
			this.context = new DataContext ();
			this.root = root;
			this.context.PushNode (root);
		}
		public Tree (Node root,DataContext context)
		{
			this.context = context;
			this.root = root;
			this.context.PushNode (root);
		}

		public void ResetContext()
		{
			this.context = new DataContext();
		}

		public DataContext GetContext()
		{
			return this.context;
		}

		public void Tick()
		{
			Node.Result result =  this.context.Peek ().Run (this.context);
			Node prev = null;
			if (result == Node.Result.FAILED || result == Node.Result.SUCCESS)
				prev = this.context.Pop ();
			else
				prev = this.context.Peek ();
			this.context.Peek ().Handle(result,context,prev);
		}
	}
}

