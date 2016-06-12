using System;
using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
[ProtoInclude(1,typeof(ElevatorRoom))]
[ProtoInclude(2,typeof(Lab))]
[ProtoInclude(3,typeof(DiningHallRoom))]
[ProtoInclude(4,typeof(LobbyRoom))]
public class Structure : Tile
{

	public override bool IsValid (TileContainer container)
	{
		if (GameController.Instance.Map.GetTile (container.X - 1, container.Y) != null)
			return true;
		if (GameController.Instance.Map.GetTile (container.X + container.Width + 1, container.Y) != null)
			return true;
	
		return false;
	}

	public override ITileContainer[] connections ()
	{
		List<ITileContainer> containers = new List<ITileContainer> ();
		ITileContainer temp1 = GameController.Instance.Map.GetTile(this.TileContainer.X - 1,this.TileContainer.Y);
		ITileContainer temp2 = GameController.Instance.Map.GetTile(this.TileContainer.X + this.TileContainer.Width + 1,this.TileContainer.Y);
		if (temp1 != null)
			containers.Add (temp1);
		if (temp2 != null)
			containers.Add (temp2);
		return containers.ToArray();
	}
}

