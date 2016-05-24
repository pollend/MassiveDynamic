using System;
using UnityEngine;

public class Panel : MonoBehaviour
{
	public PanelFrame PanelFrame{ get; private set; }

	public void SetFrame(PanelFrame frame)
	{
		this.PanelFrame = frame;

		this.transform.SetParent (frame.transform.Find("Content"));

		//set panel to fill content area
		RectTransform rectTransform = this.GetComponent<RectTransform> ();
		rectTransform.anchorMin = new Vector2 ();
		rectTransform.anchorMax = new Vector2 (1, 1);
		rectTransform.pivot = new Vector2 (.5f, .5f);

		rectTransform.offsetMax = new Vector2(0,0);
		rectTransform.offsetMin = new Vector2(0,0);

	}

	void Awake()
	{
		
	}



}


