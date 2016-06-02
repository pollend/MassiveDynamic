using System;
using ProtoBuf;

[ProtoContract]
[ProtoInclude(1,typeof(SampleLab))]
public class Lab : Structure
{
	public Lab ()
	{
	}
}

