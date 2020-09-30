//Created By Ben Westcott, 2020
using UnityEngine;

/// <summary>
/// Manages the touch-based interactions with the AR Instructions
/// </summary>
public class TouchGestureManager : MonoBehaviour
{
    [Tooltip("The ARCamera for the scene")]
    [SerializeField]
    private Camera arCamera;

    [Tooltip("The GameObject to texture instructions onto")]
    // GameObject which represents the instructions in the AR space
    private GameObject arInstructions;

    [Tooltip("Movement Sensitivity for touch movement")]
    [SerializeField]
    private float movementSensitivity = 0.001f;

    float initialFingersDistance;
    Vector3 initialArObjectScale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            scaleInstructions();
        }
        else if (Input.touchCount == 1)
        {
            moveInstructions();
        }
    }

    /// <summary>
    /// Pinch and zoom scale functionality for the AR Instructions
    /// </summary>
    private void scaleInstructions()
    {
        Touch touch1 = Input.touches[0];
        Touch touch2 = Input.touches[1];

        //If we have two touches and either one has just touched
        if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
        {
            //Calculate distance between the two positions is calculated and stored as the initial distance
            initialFingersDistance = Vector2.Distance(touch1.position, touch2.position);

            //Fire a ray from the AR camera at the screen position touched into the AR space
            Ray ray = arCamera.ScreenPointToRay(touch1.position);
            RaycastHit hitARObject;

            //If we hit our AR Instructions get a reference to them and their initial scale
            if (Physics.Raycast(ray, out hitARObject))
            {
                arInstructions = hitARObject.transform.gameObject;
                initialArObjectScale = arInstructions.transform.localScale;
            }
        }
        // If either touches move we need to start scaling
        else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
        {
            //Get the new distance between the two fingers on the screen
            var newFingersDistance = Vector2.Distance(touch1.position, touch2.position);

            //Calculate how much to scale by taking the new distance and dividing it by the old
            var scaleFactor = newFingersDistance / initialFingersDistance;
            if (arInstructions != null)
            {
                //Apply this scale factor to the AR Instructions
                arInstructions.transform.localScale = initialArObjectScale * scaleFactor;
            }

        }
    }
    /// <summary>
    /// Move functionality for the AR Instructions
    /// </summary>
    private void moveInstructions()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            //Fire a ray from the AR camera at the screen position touched into the AR space
            Ray ray = arCamera.ScreenPointToRay(touchPosition);
            RaycastHit hitARObject;

            //If we hit our AR Instructions get a reference to them
            if (Physics.Raycast(ray, out hitARObject))
            {
                arInstructions = hitARObject.transform.gameObject;
            }
        }

        if (touch.phase == TouchPhase.Moved)
        {
            //If we are moving and have a reference to the instructions
            if (arInstructions != null)
            {
                //Create a vector based on the position move since last update 
                //and the defined sensitivity
                Vector2 touchMovement = (touch.deltaPosition) * movementSensitivity;
                
                //Apply this vector to the transform of the instructions
                arInstructions.transform.position = new Vector3(
                            arInstructions.transform.position.x + touchMovement.x,
                            arInstructions.transform.position.y + touchMovement.y,
                           arInstructions.transform.position.z);
           
            }
        }

        //If the finger is removed from the screen then remove our refence to the 
        //AR Instructions so that we don't move or scale them by accident
        if (touch.phase == TouchPhase.Ended)
        {
            arInstructions = null;
        }
    }
}
