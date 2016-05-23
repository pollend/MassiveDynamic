using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelFrame : MonoBehaviour, IEventSystemHandler,IPointerDownHandler,IPointerUpHandler
{
	private Panel panel;

	[SerializeField]
	private GameObject container;

	void Update()
	{
	}

	public void SetPanel(Panel p)
	{
		this.panel = p;
		this.panel.transform.SetParent (container.transform);

		RectTransform rectTransform = this.panel.GetComponent<RectTransform> ();
		rectTransform.anchorMin = new Vector2 ();
		rectTransform.anchorMax = new Vector2 (1, 1);
		rectTransform.pivot = new Vector2 (.5f, .5f);

		rectTransform.offsetMax = new Vector2(0,0);
		rectTransform.offsetMin = new Vector2(0,0);

	}


	public void OnPointerDown (PointerEventData eventData)
	{
	}

	public void OnPointerUp (PointerEventData eventData)
	{
	}

}


