using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            if (hit.collider != null)
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
       // mM.toggleLayableFoundation(canLayFoundation);
    }
}
