using System;
using UnityEngine;
using ProtoBuf.Meta;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	[SerializeField]
	public PlacementController PlacementController;

	public Map Map{ get; private set; }

	[SerializeField]
	private GameObject MapGameObject;

	public Seralizer seralizer = new Seralizer();





	void Awake()
	{
		GameController.Instance = this;
	}

	void Start(){

		AssetManager.Instance.Initialize ();

		//seralizer.RegisterGameObject (new TestSeralization ());
		Map = MapGameObject.GetComponent<Map> ();
		RuntimeTypeModel.Default[typeof(Map)].SetFactory(typeof(Map).GetMethod("Create"));	

		//Create Overlay
		UnityEngine.GameObject.Instantiate (UiAssets.Instance.MainWindoGameObject);

		seralizer.Load ("test.bin");

	}


	void OnDrawGizmos () {
	}
	
}

