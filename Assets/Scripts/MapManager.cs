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
                    temp.GetComponent<FoundationManager>().isSet = true;
                }
                else
                {
                    pos = new Vector3(((i - (width / 2)) * foundWidth), ((j - (height / 2)) * foundHeight), 0);
                    temp = Instantiate(foundation, pos, Quaternion.identity) as GameObject;
                    temp.GetComponent<SpriteRenderer>().enabled = false;
                }
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
    //TODO: MAKE MORE ROBUST WITH FOUNDATION STATES
    public void toggleLayableFoundation(bool can)
    {
        if (can)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j].GetComponent<FoundationManager>().isSet)
                    {
                        toggleNeighbors(true, i, j);
                    }
                }
            }
        }
    }
    void toggleNeighbors(bool active, int i, int j)
    {
        if (active)
        {
            if (!map[i - 1][j].GetComponent<FoundationManager>().isSet && !map[i - 1][j].GetComponent<SpriteRenderer>().enabled)
            {
                map[i - 1][j].GetComponent<SpriteRenderer>().enabled = true;
            }
            if (!map[i + 1][j].GetComponent<FoundationManager>().isSet && !map[i + 1][j].GetComponent<SpriteRenderer>().enabled)
            {
                map[i + 1][j].GetComponent<SpriteRenderer>().enabled = true;
            }
            if (!map[i][j - 1].GetComponent<FoundationManager>().isSet && !map[i][j - 1].GetComponent<SpriteRenderer>().enabled)
            {
                map[i][j-1].GetComponent<SpriteRenderer>().enabled = true;
            }
            if (!map[i][j + 1].GetComponent<FoundationManager>().isSet && !map[i][j + 1].GetComponent<SpriteRenderer>().enabled)
            {
                map[i][j + 1].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
