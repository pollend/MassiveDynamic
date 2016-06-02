using System;
using ProtoBuf;

[ProtoContract]
public class TileContainer: ITileContainer
{
	[ProtoMember(1)]
	public Tile Tile {get;private set;}
	[ProtoMember(2)]
	public int X {get;private set;}
	[ProtoMember(3)]
	public int Y {get;private set;}
	[ProtoMember(4)]
	public int Width{get;private set;}
	[ProtoMember(5)]
	public int Height{get;private set;}


	public TileContainer(Tile tile,int x, int y, int width, int height)
	{
		this.X = x;
		this.Y = y;
		this.Tile = tile;
		this.Width = width;
		this.Height = height;
	}

	public TileContainer()
	{
	}


}

