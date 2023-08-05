using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchController : MonoBehaviour , IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RawImage pivotImage;
    private Vector2 touchPosition;
    public Vector2 direction;
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("dokundu");
        touchPosition = eventData.position; //dokunduğu yerin poszisyonu değişkene eşitledik..!
        pivotImage.enabled = true;
        pivotImage.transform.position = touchPosition;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("bıraktı");
        direction = Vector3.zero;
        pivotImage.enabled = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("sürüklüyor");
        var delta = eventData.position - touchPosition;
        direction = delta.normalized;
    }
}
