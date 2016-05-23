using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelHeader : MonoBehaviour, IEventSystemHandler,IDragHandler,IPointerDownHandler,IPointerUpHandler
{

	public RectTransform rectTransform{ get; private set; }
	public PanelFrame panelFrame{ get; private set; }

	private Vector2 localPosition = Vector2.zero;
	private Vector2 oldPosition = Vector2.zero;

	void Awake()
	{
		rectTransform = this.GetComponent<RectTransform> ();
		panelFrame = this.GetComponentInParent<PanelFrame> ();
	}

	public void OnDrag (PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Left) {
			return;
		}

		Vector2 pos = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (rectTransform, eventData.position, eventData.pressEventCamera, out pos);


		panelFrame.GetComponent<RectTransform> ().position += new Vector3(pos.x - localPosition.x,pos.y - localPosition.y,0);


	}

	public void OnPointerDown (PointerEventData eventData)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle (rectTransform, eventData.position, eventData.pressEventCamera, out localPosition);
		oldPosition = panelFrame.GetComponent<RectTransform> ().position;
	}


	public void OnPointerUp (PointerEventData eventData)
	{
	}


}


