using System;
using System.Collections.Generic;

namespace BehaviorTree
{
	public class DataContext
	{
		private Dictionary<String,Object> context = new Dictionary<string, object>();
		private Stack<Node> nodes = new Stack<Node>();

		public DataContext ()
		{
		}

		public Object GetValue(String key)
		{
			Object output = null;
			context.TryGetValue (key, out output);
			return output;
		}

		public void SetValue(String key, Object o)
		{
			if (this.context.ContainsKey (key))
				this.context.Remove (key);
			this.context.Add (key, o);
		}

		public Node Peek()
		{
			return this.nodes.Peek ();
		}

		public Node Pop()
		{
			return this.nodes.Pop ();
		}

		public void PushNode(Node n)
		{
			this.nodes.Push (n);
		}

		public int NodeCount()
		{
			return nodes.Count;
		}

	}
}

