using System;
using UnityEngine;

[System.Serializable]
public class Map : System.Object
{
	
	public GameObject Gameobject;

	[SerializeField]
	public TileMeta Meta;

	public void Start()
	{
		Meta.Start ();
	}


	public void DrawGizmos () {
		if(this.Gameobject != null)
			Meta.DrawGizmos (Gameobject.transform);
	}

}
