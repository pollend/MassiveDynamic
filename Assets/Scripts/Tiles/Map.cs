using System;
using UnityEngine;
public class Map : MonoBehaviour
{
	public static Map Instance()
	{
		return GameObject.Find ("Map").GetComponent<Map> ();
	}

	[SerializeField]
	public TileMeta Meta;


	void OnDrawGizmosSelected () {
		Meta.OnDrawGizmosSelected (this.transform);
	}

}
