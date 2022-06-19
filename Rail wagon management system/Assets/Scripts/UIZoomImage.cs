using UnityEngine;
using UnityEngine.EventSystems;

public class UIZoomImage : MonoBehaviour, IScrollHandler
{
    private Vector3 initialScale;
    [SerializeField] private Canvas canvas;

    [SerializeField]
    private float zoomSpeed = 0.1f;
    [SerializeField]
    private float maxZoom = 10f;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        initialScale = transform.localScale;
    }

    public void OnScroll(PointerEventData eventData)
    {
        var delta = Vector3.one * (eventData.scrollDelta.y * zoomSpeed) /canvas.scaleFactor;
        var desiredScale = transform.localScale + delta;

        desiredScale = ClampDesiredScale(desiredScale);

        transform.localScale = desiredScale;
    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale)
    {
        desiredScale = Vector3.Max(initialScale, desiredScale);
        desiredScale = Vector3.Min(initialScale * maxZoom, desiredScale);
        return desiredScale;
    }
}
