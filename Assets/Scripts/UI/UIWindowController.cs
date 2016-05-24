using System;
using UnityEngine;
using System.Collections.Generic;


public class UIWindowController : MonoBehaviour
{
	public static UIWindowController Instance;

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
		for (int x = panels.Count-1; x >= 0; x--) {
			panels [x].PanelFrame.GetComponent<Canvas> ().sortingOrder = x;
		}
	}

		
	public PanelFrame SpawnPanel(Panel panel)
	{
		PanelFrame frame =  UnityEngine.GameObject.Instantiate(UiAssets.Instance.FrameGameObject).GetComponent<PanelFrame>();
		frame.SetPanel (panel);
		panels.Add (panel);
		frame.transform.SetParent (this.transform);
		return frame;
		
	}

	public void RemovePanel(Panel panel)
	{
		panels.Remove (panel);
		GameObject.Destroy (panel.PanelFrame.gameObject);
	}

}


