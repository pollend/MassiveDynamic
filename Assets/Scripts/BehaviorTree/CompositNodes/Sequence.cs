﻿using System;

namespace BehaviorTree
{
	/**
	 * Proceedes in a sequence until the node hits a failure
	 **/
	public class Sequence : CompositNode
	{

		protected int actionIndex  = -1;
		public Sequence(Node[] nodes) : base(nodes)
		{
		}


		public override void Handle (Result result, DataContext context,Node prev)
		{
			if (result == Result.SUCCESS) {
				if (++actionIndex >= nodes.Length) {
					Reset ();
					context.Pop ();
					context.Peek ().Handle (Result.SUCCESS, context,this);
				} else {
					context.PushNode (nodes [actionIndex]);
				}
			} else if (result == Result.FAILED) {
				Reset ();
				context.Pop ();
				context.Peek ().Handle (Result.FAILED, context,this);
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

