using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
	[SerializeField]
	private int width;
	[SerializeField]
	private int height;


	public int GetWidth ()
	{
		return width;
	}

	public int GetHeight()
	{
		return height;
	}

	public void SetWidth(int width)
	{
		
	}

	public void SetHeight(int height)
	{
		
	}

	void OnDrawGizmosSelected ()
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.blue;
		Vector3 pos = this.transform.position;

		for (int x = 0; x <= width; x++) {
			Gizmos.DrawLine (new Vector3 (x + pos.x, pos.y, pos.z - .05f),new  Vector3 (x+ pos.x, height + pos.y, pos.z - .05f));
		}

		for (int y = 0; y <= height; y++) {
			Gizmos.DrawLine (new Vector3 (pos.x, y + pos.y, pos.z - .05f),new  Vector3 (width + pos.x, y+ pos.y, pos.z - .05f));
		}
		Gizmos.DrawSphere (GetOrigin(), .09f);

	}


	void Start()
	{
		if (GetComponent<PlacementHandle> () == null) {
			Map.Instance ().Meta.AddTile ((int)this.transform.position.x, (int)this.transform.position.y, this);
		}
	
	}

	void OnDestroy()
	{
		if(GetComponent<PlacementHandle>() == null) {
			Map.Instance ().Meta.RemoveTile ((int)this.transform.position.x, (int)this.transform.position.y);
		}
	}

	public Vector2 GetOrigin()
	{
		return this.transform.position + new Vector3(.5f,.5f);
	}

}


