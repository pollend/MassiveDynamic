﻿using System;
using UnityEngine;
using System.Collections.Generic;

public class LabSelectPanel : Panel
{
	[SerializeField]
	private GameObject content;

	[SerializeField]
	private GameObject listItem;


	void Start()
	{
		int index = 0;
		float height = 0;
		foreach (KeyValuePair<Type, Tile> o in AssetManager.Instance.Tiles) {
			GameObject item = UnityEngine.GameObject.Instantiate (listItem);
			item.GetComponent<LabPanelItem> ().Tile = o.Value;

			item.transform.SetParent (content.transform);

			RectTransform transform = item.GetComponent<RectTransform> ();
			transform.localPosition = new Vector3 (0, -(index * (5 + transform.rect.height)), 0);
			height += index * (5 * transform.rect.height);
			index++;
		}
		content.GetComponent<RectTransform> ().sizeDelta = new Vector2(0, height);

	}
}


