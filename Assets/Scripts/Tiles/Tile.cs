using System;
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

	[ProtoMember(5)]
	private float _xPos{
		get{return this.transform.position.x;}
		set{
			Vector3 temp = this.transform.position;
			this.transform.position = new Vector3 (value, temp.y, temp.z );}
	}

	[ProtoMember(6)]
	private float _yPos{
		get{return this.transform.position.y;}
		set{
			Vector3 temp = this.transform.position;
			this.transform.position = new Vector3 (temp.x, value, temp.z );}
	}


	[ProtoMember(3)]
	public int Width {
		get{ return this.width; }
		set { 
			GameController controller = GameController.Instance;
			if (controller != null) {
				if (!controller.Map.Meta.IsTileValid (this.transform.position, width, Height)) {
					return;
				}
				controller.Map.Meta.RemoveTile (GetOrigin ());
				this.width = value;
				GameController.Instance.Map.Meta.AddTile (GetOrigin (), this);
			}
		}
	}

	[ProtoMember(4)]
	public int Height{
		get{ return this.height; }
		set{
			GameController controller = GameController.Instance;
			if (controller != null) {
				if (!controller.Map.Meta.IsTileValid (this.transform.position, width,height)) {
					return;
				}
				controller.Map.Meta.RemoveTile (GetOrigin ());
				this.height = value;
				GameController.Instance.Map.Meta.AddTile (GetOrigin(), this);
			}

		}
	}

	protected override void Start()
	{
		GameController.Instance.seralizer.RegisterGameObject (this);
		if (GetComponent<PlacementHandle> () == null) {
			GameController.Instance.Map.Meta.AddTile (GetOrigin(), this);
		}
		base.Start ();
	}



	void OnDrawGizmos ()
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
		Gizmos.DrawSphere (GetOrigin(), .09f);

	}

	protected override void OnDestroy()
	{
		GameController controller = GameController.Instance;
		if (controller != null) {
			if (GetComponent<PlacementHandle> () == null) {
				controller.Map.Meta.RemoveTile (GetOrigin ());
			}
		}
		base.OnDestroy ();
	}

	public override void OnDeserialize ()
	{
		this.transform.parent = GameController.Instance.Map.gameObject.transform;

		base.OnDeserialize ();
	}


	void OnApplicationQuit() {
		OnDestroy ();
	}

	public Vector2 GetOrigin()
	{
		return this.transform.position + new Vector3(.5f,.5f);
	}


	/*public override void RegisterProtoBuf (ProtoBuf.Meta.MetaType type, int index)
	{
		type.AddSubType (index++, typeof(Tile<T>));
		 base.RegisterProtoBuf (type, index);
	}*/

}


