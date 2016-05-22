using UnityEngine;
using System.Collections;

public class FoundationManager : MonoBehaviour {

    public currState state;

    public enum currState
    {
        INVISIBLE,
        POSSIBLE_FOUNDATION,
        FOUNDATION
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (state == currState.INVISIBLE)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (state != currState.POSSIBLE_FOUNDATION)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
	}

    void OnMouseOver()
    {
        if (state == currState.POSSIBLE_FOUNDATION)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnMouseExit()
    {
        if (state == currState.POSSIBLE_FOUNDATION)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
