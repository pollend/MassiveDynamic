using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf;

[ProtoContract]
public class Map : SerializableBehavior
{

	private Dictionary<Tile,TileContainer> tiles = new Dictionary<Tile,TileContainer> ();

	[ProtoMember(1)]
	private TileContainer[] _tile{ 
		get { 
			TileContainer[] tiles = new TileContainer[this.tiles.Count];
			this.tiles.Values.CopyTo (tiles, 0);

			return tiles.ToArray(); 
		} 
		set { 
			foreach (TileContainer t in value) {
				this.RegisterTile (t.Tile);
			}
		} 
	}

	[SerializeField]
	private TileMeta Meta;

	protected override void Start ()
	{
		Meta.Start();
		base.Start ();
	}

	public bool IsTileValid(Tile t,int width, int height)
	{
		Vector2 relative = t.GetRelativeOrigin ();
		Vector3 pos = t.transform.TransformPoint(-this.transform.position) + new Vector3(relative.x,relative.y,0);
		return Meta.IsTileValid(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y),t.Width,t.Height);
	}

		
	public void RegisterTile(Tile t)
	{
		if (tiles.ContainsKey (t))
			return;

		t.transform.parent = this.transform;

		Vector2 relative = t.GetRelativeOrigin ();
		Vector3 pos = t.transform.TransformPoint(-this.transform.position) + new Vector3(relative.x,relative.y,0);
		TileContainer container =  Meta.AddTile (Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), t);
		tiles.Add (t, container);
	}

	public void UpdateTile(Tile t)
	{
		if (tiles.ContainsKey (t)) {
			Vector2 relative = t.GetRelativeOrigin ();
			Vector3 pos = t.transform.TransformPoint (-this.transform.position) + new Vector3 (relative.x, relative.y, 0);

			Meta.RemoveTile (tiles [t].X, tiles [t].Y);
			tiles.Remove (t);
			TileContainer container = Meta.AddTile (Mathf.FloorToInt (pos.x), Mathf.FloorToInt (pos.y), t);
			tiles.Add (t, container);
		}
	}
		

	public void Removetile(Tile t)
	{
		Meta.RemoveTile (tiles [t].X, tiles [t].Y);
		t.transform.parent = null;
	}


	void OnDrawGizmos () {
		Meta.DrawGizmos (this.transform);
	}

	public static Map Create(Type t)
	{
		return GameController.Instance.Map;
	}


}
