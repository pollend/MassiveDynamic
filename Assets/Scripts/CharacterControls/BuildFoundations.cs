using UnityEngine;
using System.Collections;

public class BuildFoundations{

    public BuildFoundations()
    {
    }

    public void buildFoundation(GameObject obj)
    {
        obj.GetComponent<FoundationManager>().state = FoundationManager.currState.FOUNDATION;
    }
}
