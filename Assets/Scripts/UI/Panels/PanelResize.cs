using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelResize : MonoBehaviour , IEventSystemHandler,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
	public RectTransform rectTransform{ get; private set; }
	public PanelFrame panelFrame{ get; private set; }

	private Vector2 localPosition = Vector2.zero;

	void Awake()
	{
		rectTransform = this.GetComponent<RectTransform> ();
		panelFrame = this.GetComponentInParent<PanelFrame> ();
	}


	public void OnDrag (PointerEventData eventData)
	{
	}

	public void OnPointerDown (PointerEventData eventData)
	{
	}

	public void OnPointerUp (PointerEventData eventData)
	{
	}
}

