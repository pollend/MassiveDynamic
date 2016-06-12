using System;
using BehaviorTree;
using System.Collections.Generic;

public class PathFeed : Decorator
{
	private string pathin;
	private string tileOut;

	private Stack<TileContainer> path = new Stack<TileContainer> ();

	public PathFeed (string pathin,string tileOut, Node node) : base (node)
	{
		this.pathin = pathin;
		this.tileOut = tileOut;
	}

	public override void Initialize (DataContext context)
	{
		this.path = (Stack<TileContainer>)context.GetValue (this.pathin);

		base.Initialize (context);
	}

	public override Result Run (DataContext context)
	{
		if (this.path.Count != 0) {
			TileContainer container = this.path.Pop ();
			context.SetValue (tileOut, container);
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