using System;
using ProtoBuf;

[ProtoContract]
public class TestSeralization : SerializableBehavior
{
	[ProtoMember(1)]
	public int derp = 0;

	public TestSeralization() : base()
	{
	}



}


