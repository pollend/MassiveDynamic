using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public TileMeta mM;
    public bool canLayFoundation = false;
    BuildFoundations bF;
	// Use this for initialization
	void Start () {
        bF = new BuildFoundations();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.GetComponent<FoundationManager>()
                    && hit.collider.GetComponent<FoundationManager>().state == FoundationManager.currState.POSSIBLE_FOUNDATION)
                {
                    bF.buildFoundation(hit.collider.gameObject);
                    toggleFoundation();
                }
            }
        }
	}
    public void toggleFoundation()
    {
        canLayFoundation = !canLayFoundation;
        mM.toggleLayableFoundation(canLayFoundation);
    }
}
