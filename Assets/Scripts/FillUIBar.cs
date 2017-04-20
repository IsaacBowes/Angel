using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFillBar : MonoBehaviour
{
    public enum Alignment { left, top, right, bottom };

    public RectTransform fillBarImage;
    public RectTransform fillBarMask;
    public Alignment fillOrigin;
    //public RectOffset maskPadding;

    float fillBarMaxWidth = 0;
    float fillBarMaxHeight = 0;

    public void Awake()
    {
        RectTransform fillRect = fillBarImage.GetComponent<RectTransform>();
        RectTransform maskRect = fillBarMask.GetComponent<RectTransform>();
        Vector2 anchorPoint = new Vector2(0.0f, 0.5f);

        switch (fillOrigin)
        {
            case Alignment.left:
                anchorPoint = new Vector2(0.0f, 0.5f);
                break;
            case Alignment.top:
                anchorPoint = new Vector2(0.5f, 1.0f);
                break;
            case Alignment.right:
                anchorPoint = new Vector2(1.0f, 0.5f);
                break;
            case Alignment.bottom:
                anchorPoint = new Vector2(0.5f, 0.0f);
                break;
        }
        fillRect.anchorMin = anchorPoint;
        fillRect.anchorMax = anchorPoint;
        fillRect.pivot = anchorPoint;
        maskRect.anchorMin = anchorPoint;
        maskRect.anchorMax = anchorPoint;
        maskRect.pivot = anchorPoint;

        fillBarMaxWidth = fillBarImage.GetComponent<RectTransform>().rect.width;
        fillBarMaxHeight = fillBarImage.GetComponent<RectTransform>().rect.height;
    }

    public void UpdateBar(float currentVal, float maxVal)
    {
        float percentage = Mathf.Clamp(currentVal / maxVal, 0.0f, 1.0f);
        UpdateBar(percentage);
    }

    public void UpdateBar(float percentage)
    {
        RectTransform imageRect = fillBarMask.GetComponent<RectTransform>();
        switch (fillOrigin)
        {
            case Alignment.top:
            case Alignment.bottom:
                imageRect.sizeDelta = new Vector2(fillBarMaxWidth, fillBarMaxHeight * percentage);
                break;
            case Alignment.left:
            case Alignment.right:
                imageRect.sizeDelta = new Vector2(fillBarMaxWidth * percentage, fillBarMaxHeight);
                break;
        }


    }
}