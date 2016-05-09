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
	public int width { get; private set; }
	[SerializeField]
	public int height { get; private set; }

	private Tile[,] tiles;

	public void AddTile(int xpos, int ypos,Tile tile)
	{
		if (tile is IMultiTile) {
			int width = ((IMultiTile)tile).GetWidth ();
			int height = ((IMultiTile)tile).GetHeight ();

			for (int x = xpos; x < xpos + width; x++) {
				for (int y = ypos; y < ypos + height; y++) {
					tile [x, y] = new RefTile (xpos, ypos);
				}
			}
			tile [xpos, ypos] = tile;

		} else {
			tiles [xpos, ypos] = tile;
		}
	}

	public void RemoveTile(int x, int y)
	{
		if (tiles [x, y] is RefTile) {
			int xpos = ((RefTile)tiles [x, y]).x;
			int ypos = ((RefTile)tiles [x, y]).y;

			int width = ((IMultiTile)tiles [xpos, ypos] ).GetWidth ();
			int height = ((IMultiTile)tiles[xpos, ypos] ).GetHeight ();

			for (int xp = xpos; xp < xpos + width; xp++) {
				for (int yp = ypos; yp < ypos + height; yp++) {
					tiles[xp, yp] = null;
				}
			}


		} else {
			tiles [x, y] = null;
		}
	}

	public void RemoveTile(Vector2 pos)
	{
		this.RemoveTile (Mathf.FloorToInt (pos.x), Mathf.FloorToInt (pos.y));
	}




  

    public GameObject foundation;
    public float foundWidth;
    public float foundHeight;
    public GameObject lobby;

    public PlayerControler playerControler;

    void Start()
    {
		
        /*tiles = new GameObject[width][];
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = new GameObject[height];
            for (int j = 0; j < tiles[i].Length; j++)
            {
                Vector3 pos;
                GameObject temp;
                if (i == width / 2 && j == height / 2)
                {
                    pos = new Vector3(0, 0, 0);
                    temp = Instantiate(lobby, pos, Quaternion.identity) as GameObject;
                }
                else
                {
                    pos = new Vector3(((i - (width / 2)) * foundWidth), ((j - (height / 2)) * foundHeight), 0);
                    temp = Instantiate(foundation, pos, Quaternion.identity) as GameObject;
                    temp.GetComponent<FoundationManager>().state = FoundationManager.currState.INVISIBLE;
                }
                temp.name = i.ToString() + ":" + j.ToString();
                temp.GetComponent<Tile>().setXY(i, j);
                tiles[i][j] = temp;
            }
        }*/

    }

    // Update is called once per frame
    void Update()
    {
    }

    //Used for determining if a foundation can be layed
   /* public void toggleLayableFoundation(bool can)
    {
        if (can)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                for (int j = 0; j < tiles[i].Length; j++)
                {
                    if (tiles[i][j].GetComponent<LobbyManager>() || tiles[i][j].GetComponent<FoundationManager>().state == FoundationManager.currState.FOUNDATION)
                    {
                        Debug.Log("here");
                        toggleNeighbors(true, i, j);
                    }
                }
            }
        }
        else
        {
            toggleNeighbors(false, 0, 0);
        }
    }
    void toggleNeighbors(bool active, int i, int j)
    {
        Debug.Log(i + ":" + j);
        if (active)
        {
            if (i >= 1 && tiles[i - 1][j].GetComponent<FoundationManager>()&& 
                tiles[i - 1][j].GetComponent<FoundationManager>().state == FoundationManager.currState.INVISIBLE)
            {
                tiles[i - 1][j].GetComponent<FoundationManager>().state = FoundationManager.currState.POSSIBLE_FOUNDATION;
            }
            if (i <= width - 2 && tiles[i + 1][j].GetComponent<FoundationManager>() &&
                tiles[i + 1][j].GetComponent<FoundationManager>().state == FoundationManager.currState.INVISIBLE)
            {
                tiles[i + 1][j].GetComponent<FoundationManager>().state = FoundationManager.currState.POSSIBLE_FOUNDATION;
            }
            if (j >= 1 && tiles[i][j - 1].GetComponent<FoundationManager>() &&
                tiles[i][j - 1].GetComponent<FoundationManager>().state == FoundationManager.currState.INVISIBLE)
            {
                tiles[i][j - 1].GetComponent<FoundationManager>().state = FoundationManager.currState.POSSIBLE_FOUNDATION;
            }
            if (j <= height - 2 && tiles[i][j + 1].GetComponent<FoundationManager>()&& 
                tiles[i][j + 1].GetComponent<FoundationManager>().state == FoundationManager.currState.INVISIBLE)
            {
                tiles[i][j + 1].GetComponent<FoundationManager>().state = FoundationManager.currState.POSSIBLE_FOUNDATION;
            }
        }
        else
        {
            for (int k = 0; k < tiles.Length; k++)
            {
                for (int l = 0; l < tiles[k].Length; l++)
                {
                    if (tiles[k][l].GetComponent<FoundationManager>())
                    {
                        if (tiles[k][l].GetComponent<FoundationManager>().state == FoundationManager.currState.POSSIBLE_FOUNDATION)
                        {
                            tiles[k][l].GetComponent<FoundationManager>().state = FoundationManager.currState.INVISIBLE;
                        }
                    }
                }
            }
        }
    }*/

}


