using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlacementController : System.Object
{

	private GameObject selected;

	public void AddPlacement(Tile t)
	{
		if(selected != null && selected.GetComponent<PlacementHandle>() != null)
		{
			UnityEngine.GameObject.Destroy (selected);
		}

		GameObject o = UnityEngine.GameObject.Instantiate (((SerializableBehavior)t).gameObject);
		o.AddComponent<PlacementHandle> ();
		o.name = HelperGameObject.RemoveClone (o.name);
		selected = o;
	}

}

