using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour , IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 touchPosition;
    public Vector2 direction;
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("dokundu");
        touchPosition = eventData.position; //dokunduğu yerin poszisyonu değişkene eşitledik..!
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("bıraktı");
        direction = Vector3.zero;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("sürüklüyor");
        var delta = eventData.position - touchPosition;
        direction = delta.normalized;
    }
}
