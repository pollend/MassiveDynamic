using System;
using UnityEngine;

public class PlacementHandle : MonoBehaviour
{

	void Update() {
		Tile tile = this.GetComponent<Tile> ();

		Vector3 pointer = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
		Vector3 p = new Vector3 ( Mathf.FloorToInt(pointer.x + .5f),  Mathf.FloorToInt(pointer.y + .5f), 0) - new Vector3(tile.GetWidth()/2.0f,tile.GetHeight()/2.0f,0);

		this.gameObject.transform.position =  p;

		if (GameController.Instance.Map.Meta.IsTileValid (tile.GetOrigin(),tile)) {
			if (Input.GetButtonUp ("Placement")) {

				//create a new instance for the map
				GameObject room = AssetManager.Instance.Rooms.GetGameObjectByName (this.name);
				GameObject o = (GameObject)UnityEngine.Object.Instantiate (room,this.transform.position,Quaternion.identity);
				o.name = HelperGameObject.RemoveClone (o.name);
				o.transform.parent = GameController.Instance.Map.gameObject.transform;

				UnityEngine.Object.Destroy (this.gameObject);
			}
		} else {
			UnityEngine.Debug.Log ("invalid!");
		}
	}

}

