using System;
using UnityEngine;


public class TestUI : MonoBehaviour
{
	public void SetPlacment()
	{
		Tile t = AssetManager.Instance.Rooms.GetGameObjectByName ("Lab").GetComponent<Tile> ();
		GameController.GetGameController().PlacementController.AddPlacement(t);
	}
}

