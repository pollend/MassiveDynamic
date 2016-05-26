using System;
using ProtoBuf;
using UnityEngine;


[ProtoContract]
public class SerializableVector3
{
	[ProtoMember(1)]
	public float x{get;private set;}
	[ProtoMember(2)]
	public float y{get;private set;}
	[ProtoMember(3)]
	public float z{get;private set;}

	public SerializableVector3(Vector3 v)
	{
		this.x = v.x;
		this.y = v.y;
		this.z = v.z;
	}

	public Vector3 Vector3()
	{
		return new UnityEngine.Vector3 (x, y, z);
	}

	
}

