using System;
using BehaviorTree;
using System.Collections.Generic;

public class PathFeed : Decorator
{
	public class PathPair
	{
		public PathPair(TileContainer current,TileContainer next)
		{
			this.current = current;
			this.next = next;
		}

		public TileContainer current;
		public TileContainer next;
	}

	private string pathin;
	private string tileOut;

	private Stack<TileContainer> path = new Stack<TileContainer> ();

	public PathFeed (string tilePath,string tilePair, Node node) : base (node)
	{
		this.pathin = tilePath;
		this.tileOut = tilePair;
	}

	public override void Initialize (DataContext context)
	{
		this.path = (Stack<TileContainer>)context.GetValue (this.pathin);

		base.Initialize (context);
	}

	public override Result Run (DataContext context)
	{
		if (this.path.Count != 0) {
			TileContainer current = this.path.Pop ();
			TileContainer next = this.path.Peek ();

			context.SetValue (tileOut, new PathPair(current,next));
		} else {
			return Result.SUCCESS;
		}

		return base.Run (context);
	}

	public override void Handle (Result result, DataContext context, Node previous)
	{

		base.Handle (result, context, previous);
	}
}