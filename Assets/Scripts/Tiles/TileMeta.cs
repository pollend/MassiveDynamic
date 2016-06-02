using System;
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class TileMeta : System.Object
{

	[SerializeField]
	private int mapWidth;
	[SerializeField]
	private int mapHeight;

	[NonSerialized]
	private ITileContainer[,] tiles;

	public void Start()
	{
		tiles = new ITileContainer[mapWidth,mapHeight];
	}


	public int GetWidth()
	{
		return mapWidth;
	}

	public int GetHeight()
	{
		return mapHeight;
	}

	public TileContainer AddTile(int xpos, int ypos,Tile tile)
	{
		
		int width = tile.Width;
		int height = tile.Height;

		TileContainer container = new TileContainer (tile, xpos, ypos, width, height);
		//destory the object if it's not valid
		if (!tile.IsValid (container)) {
			UnityEngine.GameObject.Destroy (tile.gameObject);
			return null;
		}

		for (int x = xpos; x < xpos + width; x++) {
			for (int y = ypos; y < ypos + height; y++) {
				tiles [x, y] = new TileRefrence (xpos, ypos);
			}
		}
		tiles [xpos, ypos] = container;
		return (TileContainer)tiles [xpos, ypos];
	}

	public Tile GetTile(int x, int y)
	{
		if (!IsContainedInBoard (x, y, 1, 1)) {
			return null;
		}
		int xpos = 0; 
		int ypos = 0;

		if (tiles [x,y] is TileRefrence) {
			xpos = ((TileRefrence)tiles [x, y]).X;
			ypos = ((TileRefrence)tiles [x, y]).Y;
		} else {
			xpos = x;
			ypos = y;
		}
		if (tiles [xpos, ypos] == null) {
			return;
		}

		return ((TileContainer)tiles [xpos, ypos]).Tile;

	}

	public void RemoveTile(int x, int y)
	{
		int xpos = 0; 
		int ypos = 0;

		if (tiles [x,y] is TileRefrence) {
			xpos = ((TileRefrence)tiles [x, y]).X;
			ypos = ((TileRefrence)tiles [x, y]).Y;
		} else {
			xpos = x;
			ypos = y;
		}

		if (tiles [xpos, ypos] == null) {
			return;
		}

		int tileWidth = ((TileContainer)tiles [xpos, ypos]).Tile.Width;
		int tileHeight =  ((TileContainer)tiles [xpos, ypos]).Tile.Height;

		for (int xp = xpos; xp < xpos + tileWidth; xp++) {
			for (int yp = ypos; yp < ypos + tileHeight; yp++) {
				tiles [xp, yp] = null;
			}
		}
	}

	public bool IsTileValid(int x, int y,int width, int height)
	{
		if (IsContainedInBoard(x,y,width,height)) {

			for (int xp = x; xp < x + width; xp++) {
				for (int yp = y; yp < y + height; yp++) {
					if (tiles [xp, yp] != null)
						return false;
				}
			}

			return true;
		}
		return false;
	}

	private bool IsContainedInBoard(int x, int y, int width, int height)
	{
		if (x >= 0 && y >= 0 && x < mapWidth && y < mapHeight && x + width - 1 < mapWidth  && y + height - 1 < mapHeight ) {
			return true;
		}
		return false;
	}
		

	public void DrawGizmos (Transform transform) {
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Vector3 offset = transform.position;

		for (int x = 0; x <= mapWidth; x++) {
			Gizmos.DrawLine (new Vector3 (x + offset.x, offset.y, 0),new  Vector3 (x+ offset.x, mapHeight + offset.y, 0));
		}
			
		for (int y = 0; y <= mapHeight; y++) {
			Gizmos.DrawLine (new Vector3 (offset.x, y + offset.y, 0),new  Vector3 (mapWidth + offset.x, y+ offset.y, 0));
		}
	}


		
}


