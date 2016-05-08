using UnityEngine;
using System.Collections;

public class FoundationManager : MonoBehaviour {

    public PlayerControler playerControler;
    bool mouseOver = false;

    public currState state;

    public enum currState
    {
        INVISIBLE,
        POSSIBLE_FOUNDATION,
        FOUNDATION,
        LOBBY,
        ELEVATOR,
        LAB1
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
        if (mouseOver && Input.GetMouseButtonUp(0))
        {
            state = currState.FOUNDATION;
            playerControler.toggleFoundation();
        }
	}

    void OnMouseOver()
    {
        if (state == currState.POSSIBLE_FOUNDATION)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        mouseOver = true;
    }

    void OnMouseExit()
    {
        if (state == currState.POSSIBLE_FOUNDATION)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
        mouseOver = false;
    }
}
