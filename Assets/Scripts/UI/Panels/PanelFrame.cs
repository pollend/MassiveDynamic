using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelFrame : MonoBehaviour, IEventSystemHandler,IPointerDownHandler,IPointerUpHandler
{
	public Panel panel { get; private set; }

	void Update()
	{
	}

	public void SetPanel(Panel p)
	{
		this.panel = p;
		this.panel.SetFrame (this);


	}
	public void Close()
	{
		UIWindowController.Instance.RemovePanel (panel);
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		UIWindowController.Instance.BringToFront (panel);
	}

	public void OnPointerUp (PointerEventData eventData)
	{
	}

}


