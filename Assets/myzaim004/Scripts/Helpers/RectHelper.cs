using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class RectHelper : MonoBehaviour
{
    RectTransform RectTransform { get; set; }

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        RectTransform.anchorMin = anchorMin;
        RectTransform.anchorMax = anchorMax;
    }
}
