using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helix.Components.Operator;

public class HealthBar : MonoBehaviour
{
    private GameObject maxHpBar;
    private GameObject curHpBar;

    public Sprite healthBarSprite;

    //sizing
    public float vertOffset = 60;
    public float barWidth = 100;
    public float barHeight = 15;

    // Use this for initialization
    void Start()
    {
        
    }

    void Awake()
    {
        BuildHealthBar();
    }
	
    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    public void BuildHealthBar()
    {
        GameObject canvas = GameObject.Find("Canvas");

        maxHpBar = new GameObject();
        maxHpBar.transform.SetParent(canvas.transform);
        maxHpBar.AddComponent<CanvasRenderer>();
        RectTransform maxRt = maxHpBar.AddComponent<RectTransform>();
        Image maxHpBarImage = maxHpBar.AddComponent<Image>();
        maxHpBarImage.sprite = healthBarSprite;
        maxHpBarImage.color = Color.red;

        curHpBar = new GameObject();
        curHpBar.transform.SetParent(maxHpBar.transform);
        curHpBar.AddComponent<CanvasRenderer>();
        RectTransform minRt = curHpBar.AddComponent<RectTransform>();
        Image minHpBarImage = curHpBar.AddComponent<Image>();
        minHpBarImage.sprite = healthBarSprite;
        minHpBarImage.color = Color.green;

        maxRt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, barWidth);
        maxRt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, barHeight);

        minRt.anchorMin = new Vector2(0, 0.5f);
        minRt.anchorMax = new Vector2(0, 0.5f);
        minRt.pivot = new Vector2(0, 0.5f);

        SetHealth(1f);
    }

    public void OnDestroy()
    {
        if (maxHpBar != null)
        {
            GameObject.Destroy(maxHpBar);
        }

        if (curHpBar != null)
        {
            GameObject.Destroy(curHpBar);
        }
    }


    private void UpdatePosition()
    {
        RectTransform maxRt = maxHpBar.GetComponent<RectTransform>();
        maxRt.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, vertOffset, 0);

    }

    public void SetHealth(float healthPercentage)
    {        
        RectTransform minRt = curHpBar.GetComponent<RectTransform>();

        float currentWidth = barWidth * Mathf.Clamp(healthPercentage, 0, 1);
        minRt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, currentWidth);
        minRt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, barHeight);
    }

    public void HealthUpdated(Operator sender)
    {
        if (sender.GetMaxStats().GetHealth() != 0)
        {            
            float healthPerc = sender.GetStats().GetHealth() / sender.GetMaxStats().GetHealth();
            SetHealth(healthPerc);
        }
        else
        {
            Debug.Log("Max health is 0");    
        }
    }

    public void Link(Operator oper)
    {
        oper.HealthUpdated += HealthUpdated;
    }

}
