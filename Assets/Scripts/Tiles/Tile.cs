using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
	[SerializeField]
	private int width;
	[SerializeField]
	private int height;

	public int GetWidth()
	{
		return width;
	}

	public  int GetHeight()
	{
		return height;
	}

	public bool SetWidth(int width)
	{
		GameController controller = GameController.Instance;
		if (controller != null) {
			if (!controller.Map.Meta.IsTileValid (this.transform.position, width,GetHeight())) {
				return false;
			}
			controller.Map.Meta.RemoveTile (GetOrigin ());
			this.width = width;
			GameController.Instance.Map.Meta.AddTile (GetOrigin(), this);
		}
		return true;
	}

	public bool SetHeight(int height)
	{
		GameController controller = GameController.Instance;
		if (controller != null) {
			if (!controller.Map.Meta.IsTileValid (this.transform.position, GetWidth(),height)) {
				return false;
			}
			controller.Map.Meta.RemoveTile (GetOrigin ());
			this.height = height;
			GameController.Instance.Map.Meta.AddTile (GetOrigin(), this);
		}
		return true;
	}


	void Start()
	{
		if (GetComponent<PlacementHandle> () == null) {
			GameController.Instance.Map.Meta.AddTile (GetOrigin(), this);
		}

	}
		

	void OnDrawGizmos ()
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.blue;
		Vector3 pos = this.transform.position;

		for (int x = 0; x <= GetWidth(); x++) {
			Gizmos.DrawLine (new Vector3 (x + pos.x, pos.y, pos.z - .05f),new  Vector3 (x+ pos.x, GetHeight() + pos.y, pos.z - .05f));
		}

		for (int y = 0; y <= GetHeight(); y++) {
			Gizmos.DrawLine (new Vector3 (pos.x, y + pos.y, pos.z - .05f),new  Vector3 (GetWidth() + pos.x, y+ pos.y, pos.z - .05f));
		}
		Gizmos.DrawSphere (GetOrigin(), .09f);

	}



	void OnDestroy()
	{
		GameController controller = GameController.Instance;
		if (controller != null) {
			if (GetComponent<PlacementHandle> () == null) {
				controller.Map.Meta.RemoveTile (GetOrigin ());
			}
		}
	}
	void OnApplicationQuit() {
		OnDestroy ();
	}

	public Vector2 GetOrigin()
	{
		return this.transform.position + new Vector3(.5f,.5f);
	}

}


