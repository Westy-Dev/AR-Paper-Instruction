using UnityEngine;


public class TouchGestureManager : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;

    private Touch touch;
    private Vector2 touchPosition;
    private GameObject arObject;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Debug.Log("Touch Phase = " + touch.phase);

            touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                RaycastHit hitARObject;
                Debug.Log("Ray Fired");
                if(Physics.Raycast(ray, out hitARObject))
                {
                    arObject = hitARObject.transform.gameObject;
                    if(arObject != null)
                    {
                        Debug.Log("Hit Object");
                        Debug.Log("Position = " + arObject.transform.position);
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (arObject != null)
                {
                    Vector2 touchMovement = arCamera.ScreenToWorldPoint(touch.deltaPosition)/10;
                    Debug.Log("Delta Touch Position = " + touchMovement);
                    arObject.transform.position = new Vector3(
                                arObject.transform.position.x,
                                arObject.transform.position.y + touchMovement.y,
                                arObject.transform.position.z + touchMovement.x);
                    Debug.Log("New Position = " + arObject.transform.position);
                }
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                arObject = null;
            }
        }
    }
}
