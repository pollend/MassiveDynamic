using System;
using ProtoBuf;

[ProtoContract]
[ProtoInclude(1,typeof(SampleLab))]
public class Lab : Tile
{
	public Lab ()
	{
	}
}

