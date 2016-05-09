using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
	void Start()
	{
		Map.Instance ().Meta.AddTile ((int)this.transform.position.x,(int) this.transform.position.y, this);

	}

	void OnDestroy()
	{
		Map.Instance ().Meta.RemoveTile ((int)this.transform.position.x, (int)this.transform.position.y);
	}

}


