using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Vector3 dragOrigin;
	Vector3 pos = Vector3.zero;
	public float cameraSize = 100f;
	public float minCameraSize;
	float scrollSpeed = 10f;
	// Use this for initialization
	void Start () {
		cameraSize = this.GetComponent<Camera>().orthographicSize;
		minCameraSize = cameraSize;
	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Camera>().orthographicSize = cameraSize;
		if (Input.GetMouseButton(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider != null)
				{
					pos = hit.point;
				}
			}
			if (dragOrigin == new Vector3(-100f, -100f, -100f))
			{
				dragOrigin = pos;
			}
			else
			{
				this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + (dragOrigin.x - pos.x), this.gameObject.transform.position.y + (dragOrigin.y - pos.y), this.gameObject.transform.position.z);
			}
		}
		cameraSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
		if (minCameraSize > cameraSize)
		{
			cameraSize = minCameraSize;
		}
	}
}

