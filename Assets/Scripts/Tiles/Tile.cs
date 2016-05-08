using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public bool isPreview{get;set;}
	[Serializable]
	public int width { get; private set; }
	[Serializable]
	public int height { get; private set; }

	protected TileMeta tileMeta;

	void Start()
	{
		this.tileMeta = GameObject.Find ("_root").GetComponent<TileMeta> ();
		if (!isPreview) {
			
		}
	}
		
}


