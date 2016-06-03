using UnityEngine;
using System.Collections;
using ProtoBuf;
using ProtoBuf.Meta;
using System;

[ProtoContract]
[ProtoInclude(2,typeof(Map))]
[ProtoInclude(3,typeof(Tile))]
public class SerializableBehavior : MonoBehaviour
{
	protected virtual bool IsRegistered()
	{
		return true;
	}

	protected virtual void Awake()
	{
	}

	// Use this for initialization
	protected virtual void Start ()
	{
		if(this.IsRegistered())
		GameController.Instance.seralizer.RegisterGameObject (this);
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{
	
	}


	protected virtual void OnDestroy() {

		if(this.IsRegistered())
		GameController.Instance.seralizer.DestroyGameObject (this);
	}

	public virtual void OnDeserialize()
	{
	}

	public virtual void OnSerialize()
	{
	}


}

