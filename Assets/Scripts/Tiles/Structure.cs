using System;
using ProtoBuf;

[ProtoContract]
[ProtoInclude(1,typeof(Elevator))]
[ProtoInclude(2,typeof(Lab))]
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
}

