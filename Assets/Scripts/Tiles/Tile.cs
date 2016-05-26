﻿using System;
using UnityEngine;
using ProtoBuf;

[ProtoContract]
[ProtoInclude(1,typeof(Elevator))]
[ProtoInclude(2,typeof(Lab))]
public class Tile: SerializableBehavior
{

	[SerializeField]
	private int width;

	[SerializeField]
	private int height;

	public TileContainer tileContainer { get; private set; }

	protected override bool IsRegistered ()
	{
		return false;
	}

	[ProtoMember(3)]
	public int Width {
		get{ return this.width; }
		set { 
			GameController controller = GameController.Instance;
			if (controller != null) {
				if (!controller.Map.IsTileValid (this, width, Height)) {
					return;
				}
				this.width = value;
				GameController.Instance.Map.UpdateTile (this);
			}
		}
	}

	[ProtoMember(4)]
	public int Height{
		get{ return this.height; }
		set{
			GameController controller = GameController.Instance;
			if (controller != null) {
				if (!controller.Map.IsTileValid (this, width,height)) {
					return;
				}
				this.height = value;
				GameController.Instance.Map.UpdateTile (this);
			}

		}
	}

	protected virtual void Start()
	{
		if (GetComponent<PlacementHandle> () == null) {
			GameController.Instance.Map.RegisterTile(this);
		}
	}



	protected virtual void OnDrawGizmos ()
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.blue;
		Vector3 pos = this.transform.position;

		for (int x = 0; x <= Width; x++) {
			Gizmos.DrawLine (new Vector3 (x + pos.x, pos.y, pos.z - .05f),new  Vector3 (x+ pos.x, Height + pos.y, pos.z - .05f));
		}

		for (int y = 0; y <= Height; y++) {
			Gizmos.DrawLine (new Vector3 (pos.x, y + pos.y, pos.z - .05f),new  Vector3 (Width + pos.x, y+ pos.y, pos.z - .05f));
		}
		//Gizmos.DrawSphere (this.GetRelativeOrigin() + this.transform.position, .09f);

	}

	protected virtual void OnDestroy()
	{
		GameController controller = GameController.Instance;
		if (controller != null) {
			if (GetComponent<PlacementHandle> () == null) {
				controller.Map.Removetile (this);
			}
		}
	}


	protected virtual void OnApplicationQuit() {
		OnDestroy ();
	}

	public virtual Vector2 GetRelativeOrigin()
	{
		return new Vector3(.5f,.5f);
	}


	/*public override void RegisterProtoBuf (ProtoBuf.Meta.MetaType type, int index)
	{
		type.AddSubType (index++, typeof(Tile<T>));
		 base.RegisterProtoBuf (type, index);
	}*/

}


