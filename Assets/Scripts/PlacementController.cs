using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlacementController : System.Object
{

	private List<GameObject> placementHandles = new List<GameObject>();

	public void AddPlacement(Tile t)
	{
		if (placementHandles.Count > 0) {
			for (int x = 0; x < placementHandles.Count; x++) {
				UnityEngine.GameObject.Destroy (placementHandles [x]);
			}
		}

		GameObject o = UnityEngine.GameObject.Instantiate (t.gameObject);
		o.AddComponent<PlacementHandle> ();
		placementHandles.Add (o);
	}

}

