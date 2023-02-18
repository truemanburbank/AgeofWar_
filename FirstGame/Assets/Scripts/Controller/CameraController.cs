using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public float dragSpeed = 1f;
    public float smoothing = 0.1f;
    private Vector3 beginMousePos = Vector3.zero;
    private Vector3 beginCamPos = Vector3.zero;
    private Vector3 preMousePos = Vector3.zero;

    public float limitMinX, limitMaxX;

    private void Start()
    {

    }

    private void LateUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            beginMousePos = Input.mousePosition;
            beginCamPos = transform.position;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        preMousePos = -(Input.mousePosition - beginMousePos) * dragSpeed;
        Vector3 newCampos = beginCamPos + preMousePos;
        newCampos.x = Mathf.Clamp(newCampos.x, limitMaxX, limitMinX);
        newCampos.y = 0;
        transform.position = Vector3.Lerp(transform.position, newCampos, smoothing);
    }


}
//using UnityEngine;
//using System.Collections;

//public class CameraController : MonoBehaviour
//{
//    public float limitMinX, limitMaxX;
//    public float dragSpeed = 2;
//    private Vector3 dragOrigin;


//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            dragOrigin = Input.mousePosition;
//            return;
//        }

//        if (!Input.GetMouseButton(0)) return;

//        Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
//        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
//        transform.Translate(move, Space.World);
        
//    }


//}