using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public MapManager mM;
    public bool canLayFoundation = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.F))
        {
            toggleFoundation();
        }
	}
    public void toggleFoundation()
    {
        canLayFoundation = !canLayFoundation;
        mM.toggleLayableFoundation(canLayFoundation);
    }
}
