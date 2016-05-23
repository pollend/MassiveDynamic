using System;
using UnityEngine;
using System.Collections.Generic;


public class UIWindowController : MonoBehaviour
{
	public static UIWindowController Instance;

	[SerializeField]
	private GameObject frameGameObject;

	private List<Panel> panels = new List<Panel> ();



	void Awake()
	{
		UIWindowController.Instance = this;
		
	}

	void Start()
	{
	}

	public void BringToFront(Panel panel)
	{
		int index = this.panels.IndexOf (panel);
		panels.RemoveAt (index);
		panels.Add (panel);

		this.reorder();
	}

	private void reorder()
	{
	}

		
	public PanelFrame RegisterPanel(Panel panel)
	{
		PanelFrame frame =  UnityEngine.GameObject.Instantiate(frameGameObject).GetComponent<PanelFrame>();
		frame.SetPanel (panel);
		panels.Add (panel);
		frame.transform.SetParent (this.transform);


		return frame;
		
	}



}


