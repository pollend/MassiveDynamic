using System;

public class TileContainer : ITileContainer
{
	public Tile Tile {get;private set;}
	public int X {get;private set;}
	public int Y {get;private set;}

	public TileContainer (int x, int y, Tile tile)
	{
		this.X = x;
		this.Y = y;
		this.Tile = tile;
	}


}

