using System;
using BehaviorTree;


public class ConditionalTile<T> : Decorator
{
	private String inputTile;
	public ConditionalTile (String inputTile, Node n) : base (n)
	{
		this.inputTile = inputTile;
	}

	public override Result Run (DataContext context)
	{
		TileContainer container = (TileContainer)context.GetValue (this.inputTile);
		if (!(container is T)) {
			return Result.FAILED;
		}
		return base.Run (context);
	}

	public override void Handle (Result result, DataContext context, Node previous)
	{
		
		base.Handle (result, context, previous);
	}
}
