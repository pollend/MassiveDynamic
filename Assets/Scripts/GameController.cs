using System;
using UnityEngine;
using ProtoBuf.Meta;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	[SerializeField]
	public PlacementController PlacementController;

	[SerializeField]
	public Map Map;

	public Seralizer seralizer;

	void Awake()
	{
		GameController.Instance = this;
		Map.Start ();
		seralizer = new Seralizer ();
	}

	void Start(){

		AssetManager.Instance.Initialize ();


		//Create Overlay
		UnityEngine.GameObject.Instantiate (UiAssets.Instance.MainWindoGameObject);

		seralizer.Load ("test.bin");

	}


	void OnDrawGizmos () {
		Map.OnDrawGizmos ();
	}
	
}

