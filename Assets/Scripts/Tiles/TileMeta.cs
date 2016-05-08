using System;
using UnityEngine;

public class TileMeta : MonoBehaviour
{
	private class RefrenceTile : Tile
	{
		public int x{ get;private set;}
		public int y{ get;private set;}

		public RefrenceTile(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	[SerializeField]
	private int width;
	[SerializeField]
	private int height;

	[SerializeField]
	private int tileWidth;
	[SerializeField]
	private int tileHeight;


	private Tile[,] tiles;

	void Start()
	{

	}

	public bool isTileValid(Tile t)
	{
		
	}

	public void SetTile(Tile t)
	{
		Vector3 relative = t.gameObject.transform.InverseTransformPoint (this.gameObject.transform);
		
	}

	public void RemoveTile(int x, int y)
	{
		if (tiles [x, y] is RefrenceTile) {
			int posX = ((RefrenceTile)tiles [x, y]).x;
			int posY = ((RefrenceTile)tiles [x, y]).y;
			for(int px = posX; px < tiles[posX,posY].width + posX; px++)
			{
				for(int py = posX; py < tiles[posX,posY].width + posX; py++)
				{
				}
			}


		}
	}

}


