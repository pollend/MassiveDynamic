using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Root : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene ("Scenes/Map", LoadSceneMode.Additive);

	}

	// Update is called once per frame
	void Update () {

	}
}
