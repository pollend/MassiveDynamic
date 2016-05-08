using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    public GameObject[][] map;
    public int width = 13;
    public int height = 13;

    public GameObject foundation;
    public float foundWidth;
    public float foundHeight;
    public Sprite lobby;

    public PlayerControler playerControler;

	// Use this for initialization
	void Start () {
        map = new GameObject[width][];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
            for (int j = 0; j < map[i].Length; j++)
            {
                Vector3 pos;
                GameObject temp;
                if (i == width / 2 && j == height / 2)
                {
                    pos = new Vector3(0, 0, 0);
                    temp = Instantiate(foundation, pos, Quaternion.identity) as GameObject;
                    temp.GetComponent<SpriteRenderer>().sprite = lobby;
                    temp.GetComponent<FoundationManager>().state = FoundationManager.currState.LOBBY;
                }
                else
                {
                    pos = new Vector3(((i - (width / 2)) * foundWidth), ((j - (height / 2)) * foundHeight), 0);
                    temp = Instantiate(foundation, pos, Quaternion.identity) as GameObject;
                    temp.GetComponent<FoundationManager>().state = FoundationManager.currState.INVISIBLE;
                }
                temp.GetComponent<FoundationManager>().playerControler = playerControler;
                temp.name = i.ToString() + ":" + j.ToString();
                map[i][j] = temp;
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
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j].GetComponent<FoundationManager>().state != FoundationManager.currState.INVISIBLE &&
                        map[i][j].GetComponent<FoundationManager>().state != FoundationManager.currState.POSSIBLE_FOUNDATION)
                    {
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
            if (i >= 1 && map[i - 1][j].GetComponent<FoundationManager>().state == FoundationManager.currState.INVISIBLE)
            {
                map[i - 1][j].GetComponent<FoundationManager>().state = FoundationManager.currState.POSSIBLE_FOUNDATION;
            }
            if (i <= width - 2 && map[i + 1][j].GetComponent<FoundationManager>().state == FoundationManager.currState.INVISIBLE)
            {
                map[i + 1][j].GetComponent<FoundationManager>().state = FoundationManager.currState.POSSIBLE_FOUNDATION;
            }
            if (j >= 1 && map[i][j - 1].GetComponent<FoundationManager>().state == FoundationManager.currState.INVISIBLE)
            {
                map[i][j - 1].GetComponent<FoundationManager>().state = FoundationManager.currState.POSSIBLE_FOUNDATION;
            }
            if (j <= height - 2 && map[i][j + 1].GetComponent<FoundationManager>().state == FoundationManager.currState.INVISIBLE)
            {
                map[i][j + 1].GetComponent<FoundationManager>().state = FoundationManager.currState.POSSIBLE_FOUNDATION;
            }
        }
        else
        {
            for (int k = 0; k < map.Length; k++)
            {
                for (int l = 0; l < map[k].Length; l++)
                {
                    if (map[k][l].GetComponent<FoundationManager>().state == FoundationManager.currState.POSSIBLE_FOUNDATION)
                    {
                        map[k][l].GetComponent<FoundationManager>().state = FoundationManager.currState.INVISIBLE;
                    }
                }
            }
        }
    }
}
