using UnityEngine;
using System.Collections;

public class TestUiWindow : MonoBehaviour {
	[SerializeField]
	GameObject test;

	// Use this for initialization
	void Start () {
		//UnityEngine.Object.Instantiate<Fram
		UIWindowController.Instance.RegisterPanel (GameObject.Instantiate(test).GetComponent<Panel> ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
