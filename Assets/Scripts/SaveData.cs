using System;
using System.Collections.Generic;
using ProtoBuf;

[ProtoContract]
public class SaveData
{
	public List<SerializableBehavior> seralizbleCollection = new List<SerializableBehavior> ();


	[ProtoMember(1)]
	private SerializableBehavior[] _seralizedData{ get{ return seralizbleCollection.ToArray ();} set{ seralizbleCollection.AddRange(value);}}

	[ProtoMember(2)]
	public Map map { get { return GameController.Instance.Map; } set { ; } }


	public SaveData()
	{
	}

}

