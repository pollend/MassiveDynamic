using System;

public class TileRefrence : ITileContainer
{
	public int X { get; private set;}
	public int Y { get; private set;}

	public TileRefrence(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}
}


