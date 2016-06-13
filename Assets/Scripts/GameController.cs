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

	public ActorCollection ActorCollection;

	public Seralizer seralizer;

	void Awake()
	{
		ActorCollection = new ActorCollection ();
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

	void Update()
	{ 
		Map.Update ();
	}

	void OnDrawGizmos () {
		Map.OnDrawGizmos ();
	}
	
}

