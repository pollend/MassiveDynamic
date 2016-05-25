using UnityEngine;
using System.Collections;
using ProtoBuf;
using ProtoBuf.Meta;
using System;

[ProtoContract]
[ProtoInclude(1,typeof(Tile))]
public class SerializableBehavior : MonoBehaviour
{

	// Use this for initialization
	protected virtual void Start ()
	{
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{
	
	}


	protected virtual void OnDestroy() {
		GameController.Instance.seralizer.DestroyGameObject (this);
	}

	public virtual void OnDeserialize()
	{
	}

	public virtual void OnSerialize()
	{
	}


}

