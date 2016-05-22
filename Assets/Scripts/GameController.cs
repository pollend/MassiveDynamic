using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	public PlacementController PlacementController;
	[SerializeField]
	public Map Map;

	public static GameController GetGameController()
	{
		if (!GameObject.Find ("_root"))
			return null;
		
		return GameObject.Find ("_root").GetComponent<GameController> ();
	}

	void Start(){
		Map.Start ();
		UnityEngine.GameObject.Instantiate (AssetManager.Instance.UiItems.GetGameObjectByName ("MainOverlay"));

	}

	void OnDrawGizmos () {
		Map.DrawGizmos ();
	}
	
}

