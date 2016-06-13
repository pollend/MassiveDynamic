using System;
using ProtoBuf;


[ProtoInclude(2,typeof(Scientist))]
public class Employee : Actor
{
	public Employee ()
	{
	}
}


