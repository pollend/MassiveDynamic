using System;
using ProtoBuf;


[ProtoContract]
public class Elevator : Tile
{
	protected override void OnDestroy ()
	{
		base.OnDestroy ();
	}

}

