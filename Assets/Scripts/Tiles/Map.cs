using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using ProtoBuf.Meta;

[ProtoContract]
[System.Serializable]
public class Map : System.Object
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

	public void Start()
	{
		//set a factory for Map
		RuntimeTypeModel.Default[typeof(Map)].SetFactory(typeof(Map).GetMethod("Create"));	
		Meta.Start();
	}


	public TileContainer GetTile(Tile t)
	{
		TileContainer container = null;

		if (tiles.TryGetValue (t,out container)) {
			return container;
		}
		return null;
	}

	public bool IsTileValid(Tile t,int width, int height)
	{
		Vector2 relative = t.GetRelativeOrigin ();
		Vector3 pos =   t.transform.position + new Vector3(relative.x,relative.y,0);
		return Meta.IsTileValid(t,Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y),t.Width,t.Height);
	}

		
	public void RegisterTile(Tile t)
	{
		if (tiles.ContainsKey (t))
			return;

		Vector2 relative = t.GetRelativeOrigin ();
		Vector3 pos = t.transform.position + new Vector3(relative.x,relative.y,0);
		TileContainer container =  Meta.AddTile (Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), t);
		if (container == null)
			return;
		tiles.Add (t, container);
	}

	public void UpdateTile(Tile t)
	{
		if (tiles.ContainsKey (t)) {
			Vector2 relative = t.GetRelativeOrigin ();
			Vector3 pos =  t.transform.position + new Vector3 (relative.x, relative.y, 0);

			Meta.RemoveTile (tiles [t].X, tiles [t].Y);
			tiles.Remove (t);
			TileContainer container = Meta.AddTile (Mathf.FloorToInt (pos.x), Mathf.FloorToInt (pos.y), t);
			tiles.Add (t, container);
		}
	}

	public Tile GetTile(int x, int y)
	{
		return Meta.GetTile (x, y);
	}
		

	public void Removetile(Tile t)
	{
		if (!tiles.ContainsKey (t))
			return;
		Meta.RemoveTile (tiles [t].X, tiles [t].Y);
	}


	public void OnDrawGizmos () {
		Meta.DrawGizmos ();
	}

	public static Map Create(Type t)
	{
		return GameController.Instance.Map;
	}


}
