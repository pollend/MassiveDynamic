using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LabPanelItem : MonoBehaviour
{

	public GameObject Tile { get; set; }


	void Start()
	{
		//TODO: change this to use not just the text
		this.transform.Find ("Display").gameObject.GetComponent<Text> ().text = Tile.name;
	}

	public void OnClick()
	{
		GameController.Instance.PlacementController.AddPlacement(Tile.GetComponent<Tile>());
	}


}
