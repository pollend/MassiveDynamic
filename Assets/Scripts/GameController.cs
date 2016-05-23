using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	[SerializeField]
	public PlacementController PlacementController;

	public Map Map{ get; private set; }

	[SerializeField]
	private GameObject MapGameObject;


	void Awake()
	{
		GameController.Instance = this;
	}

	void Start(){
		Map = MapGameObject.GetComponent<Map> ();

		//Create Overlay
		UnityEngine.GameObject.Instantiate (AssetManager.Instance.UiItems.GetGameObjectByName ("MainOverlay"));

	}

	void OnDrawGizmos () {
	}
	
}

