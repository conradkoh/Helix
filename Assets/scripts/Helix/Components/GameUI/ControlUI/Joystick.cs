using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : EventTrigger {

	public Sprite inner_sprite;
	public Sprite outer_sprite;
	public float inner_radius = 50f;
	public float outer_radius = 100f;

	public GameObject inner;

	public Vector2 currentOutput = Vector2.zero;

	// Use this for initialization
	void Start () {
		transform.name = "outer";
		SpawnButton ();
		SetSprites ();
		SetRadius ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SpawnButton()
	{
		inner = new GameObject ("inner");
		inner.AddComponent<Image> ();
		inner.transform.SetParent(transform);
		inner.transform.localPosition = Vector3.zero;
	}

	private void SetSprites ()
	{
		if(outer_sprite != null)
		{
			gameObject.GetComponent<Image> ().sprite = outer_sprite;
		}

		if(inner_sprite != null)
		{
			inner.GetComponent<Image> ().sprite = inner_sprite;
		}

	}

	private void SetRadius ()
	{
		RectTransform outer_rt = GetComponent<RectTransform> ();
		outer_rt.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, outer_radius*2);
		outer_rt.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, outer_radius*2);

		RectTransform inner_rt = inner.GetComponent<RectTransform> ();
		inner_rt.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, inner_radius*2);
		inner_rt.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, inner_radius*2);

		inner.transform.localPosition = Vector3.zero;
	}

	public override void OnDrag(PointerEventData touch)
	{
		Vector2 joystickCenter = transform.position;
		float maxDistance = (outer_radius - inner_radius);

		// Uses vectors to find new position
		Vector2 newInnerPosition = joystickCenter - Vector2.ClampMagnitude((joystickCenter-touch.position),maxDistance);

		//set new position
		inner.transform.position = (Vector3)newInnerPosition;

		//get output component vectors
		float outputXComponentVector = (newInnerPosition.x - joystickCenter.x)/maxDistance;
		float outputYComponentVector = (newInnerPosition.y - joystickCenter.y)/maxDistance;

		//normalize output to be whole values (e.g. -1/0/1)
		if (Mathf.Abs (outputXComponentVector) > 0.5) {
			//make into 1/-1
			outputXComponentVector = outputXComponentVector / Mathf.Abs (outputXComponentVector);
		} else {
			outputXComponentVector = 0;
		}

		if (Mathf.Abs (outputYComponentVector) > 0.5) {
			//make into 1/-1
			outputYComponentVector = outputYComponentVector / Mathf.Abs (outputYComponentVector);
		} else {
			outputYComponentVector = 0;
		}

		currentOutput = new Vector2(outputXComponentVector,outputYComponentVector);
	}

	public override void OnEndDrag(PointerEventData touch)
	{
		//reset inner position
		inner.transform.position = transform.position;

		//reset output 
		currentOutput = Vector2.zero;
	}
		
}
