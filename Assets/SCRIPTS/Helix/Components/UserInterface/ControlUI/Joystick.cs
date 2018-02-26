using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : EventTrigger
{

    public Sprite inner_sprite;
    public Sprite outer_sprite;
    public float inner_radius = 50f;
    public float outer_radius = 100f;
    public float activateDamping = 0.3f;
    public GameObject inner;

    public float outputAngle = 0;
    public Vector2 eightPointOutput = Vector2.zero;

    public bool isActive = false;

    // Use this for initialization
    void Start()
    {
        transform.name = "outer";
        SpawnButton();
        SetSprites();
        SetRadius();
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    private void SpawnButton()
    {
        inner = new GameObject("inner");
        inner.AddComponent<Image>();
        inner.transform.SetParent(transform);
        inner.transform.localPosition = Vector3.zero;
    }

    private void SetSprites()
    {
        if (outer_sprite != null)
        {
            gameObject.GetComponent<Image>().sprite = outer_sprite;
        }

        if (inner_sprite != null)
        {
            inner.GetComponent<Image>().sprite = inner_sprite;
        }

    }

    private void SetRadius()
    {
        RectTransform outer_rt = GetComponent<RectTransform>();
        outer_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, outer_radius * 2);
        outer_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, outer_radius * 2);

        RectTransform inner_rt = inner.GetComponent<RectTransform>();
        inner_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inner_radius * 2);
        inner_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inner_radius * 2);

        inner.transform.localPosition = Vector3.zero;
    }

    public override void OnDrag(PointerEventData touch)
    {        

        Vector2 joystickCenter = transform.position;
        float maxDistance = (outer_radius - inner_radius);

        // Uses vectors to find new position
        Vector2 newInnerPosition = joystickCenter - Vector2.ClampMagnitude((joystickCenter - touch.position), maxDistance);

        //set new position
        inner.transform.position = (Vector3)newInnerPosition;

        //set output angle variables
        Vector2 finalVector = newInnerPosition - joystickCenter;
        outputAngle = Mathf.Rad2Deg * Mathf.Atan2(finalVector.x, finalVector.y);


        //normalize for 8 point
        float x = Mathf.Sin(outputAngle * Mathf.Deg2Rad);
        float y = Mathf.Cos(outputAngle * Mathf.Deg2Rad);

        if (Mathf.Abs(x) > 0.5)
        {
            x = x / Mathf.Abs(x);
        }
        else
        {
            x = 0;
        }

        if (Mathf.Abs(y) > 0.5)
        {
            y = y / Mathf.Abs(y);
        }
        else
        {
            y = 0;
        }
            
        if (finalVector.magnitude > activateDamping * outer_radius)
        {
            Debug.Log("ACTIVE");
            isActive = true;
        }

        //set 8 point output variables
        eightPointOutput = new Vector2(x, y);
    }

    public override void OnPointerUp(PointerEventData touch)
    {
        //reset inner position
        inner.transform.position = transform.position;

        //reset output 
        isActive = false;
        outputAngle = 0; 
    }

    public override void OnInitializePotentialDrag(PointerEventData touch)
    {
        this.OnDrag(touch);
    }
		
}
