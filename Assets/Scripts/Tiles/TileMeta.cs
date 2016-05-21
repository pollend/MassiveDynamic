using System;
using UnityEngine;


[System.Serializable]
public class TileMeta : System.Object
{
	private class RefTile : Tile{
		public int x { get; private set;}
		public int y { get; private set;}
		public RefTile(int x, int y)
		{
			this.x = x;
			this.y = y;
			
		}
	}


	[SerializeField]
	private int width;
	[SerializeField]
	private int height;

	private Tile[,] tiles;

	private Map GetMap{ get { return Map.Instance (); }}

	public int GetWidth()
	{
		return width;
	}

	public int GetHeight()
	{
		return height;
	}

	public void AddTile(int xpos, int ypos,Tile tile)
	{
			int width = tile.GetWidth ();
			int height = tile.GetHeight ();

			for (int x = xpos; x < xpos + width; x++) {
				for (int y = ypos; y < ypos + height; y++) {
					tiles [x, y] = new RefTile (xpos, ypos);
				}
			}
			tiles [xpos, ypos] = tile;


	}

	public void RemoveTile(int x, int y)
	{
		int xpos = 0; 
		int ypos = 0;

		if (tiles [x,y] is RefTile) {
			xpos = ((RefTile)tiles [x, y]).x;
			ypos = ((RefTile)tiles [x, y]).y;
		} else {
			xpos = x;
			ypos = y;
		}
			
		int width = tiles [xpos, ypos].GetWidth ();
		int height = tiles [xpos, ypos].GetHeight ();

		for (int xp = xpos; xp < xpos + width; xp++) {
			for (int yp = ypos; yp < ypos + height; yp++) {
				tiles [xp, yp] = null;
			}
		}


	}

	public void RemoveTile(Vector2 pos)
	{
		Vector3 offset = GetMap.transform.position;
		this.RemoveTile (Mathf.FloorToInt (offset.x + pos.x), Mathf.FloorToInt (offset.y + pos.y));
	}

	public void AddTile(Vector2 pos,Tile tile)
	{
		Vector3 offset = GetMap.transform.position;
		this.AddTile ( Mathf.FloorToInt (offset.x +pos.x), Mathf.FloorToInt (offset.y +pos.y),tile);
	}

	public void OnDrawGizmosSelected (Transform pos) {
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Vector3 offset = GetMap.transform.position;

		for (int x = 0; x <= width; x++) {
			Gizmos.DrawLine (new Vector3 (x + offset.x, offset.y, 0),new  Vector3 (x+ offset.x, height + offset.y, 0));
		}
			
		for (int y = 0; y <= height; y++) {
			Gizmos.DrawLine (new Vector3 (offset.x, y + offset.y, 0),new  Vector3 (width + offset.x, y+ offset.y, 0));
		}
	}


		
}


