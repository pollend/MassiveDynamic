using System;
using UnityEngine;

public class TileMeta : MonoBehaviour
{
	/*public int width;
	public int height;

	private Tile[,] tiles;*/


    public GameObject[][] tiles;
    public int width = 13;
    public int height = 13;

    public GameObject foundation;
    public float foundWidth;
    public float foundHeight;
    public GameObject lobby;

    public PlayerControler playerControler;

    void Start()
    {
        tiles = new GameObject[width][];
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
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    //Used for determining if a foundation can be layed
    public void toggleLayableFoundation(bool can)
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
    }

}


