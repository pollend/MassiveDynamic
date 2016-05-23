using System;
using UnityEngine;

public class Map : MonoBehaviour
{

	[SerializeField]
	public TileMeta Meta;

	void Start(){
		Meta.Start (this);
	}


	void OnDrawGizmos () {
		Meta.DrawGizmos (this.transform);
	}

}
