using System;
using ProtoBuf;


[ProtoContract]
public class Elevator : Structure
{
	protected override void OnDestroy ()
	{
		base.OnDestroy ();
	}

}

