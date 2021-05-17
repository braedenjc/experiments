using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject player;
    public Camera viewport;
    public Vector3 positionOffset;
    public float radius;
    public float calculatedRadius;
    public float sqrtCR;
    public float lowerMouseVerticalMovementLimit; //How far below the player's center we want to move before we stop moving the pointer.

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        //This needs some serious cleanup.
        /*Basically, we want to lock the range of movement for our cursor on a half circle above and surrounding the player.
        * First, we get the player position, and the mouse's world position.
        * Then, we restrict the movement of the mouse to the +y range of the world, starting at the base of the player.
        * Plot a circle, and lock out movement on the interior of the circle.
        */
        Vector3 playerPosition = player.transform.position;
        Vector3 mousePosition = Input.mousePosition;
        Vector3 localMousePosition = viewport.ScreenToWorldPoint(mousePosition);

        //calcuate a circle from a center pointer to act as an exclusion zone. 
        //We use the player position as the center of the exclusion zone.
        float x = localMousePosition.x;
        float y = localMousePosition.y;
        float h = playerPosition.x;
        float k = playerPosition.y;
        float domain = Mathf.Pow(x-h, 2);
        float range = Mathf.Pow(y-k, 2);
        Quaternion rotationOfCursor = Quaternion.FromToRotation(localMousePosition, playerPosition);
        calculatedRadius = domain + range;
        sqrtCR = Mathf.Sqrt(calculatedRadius);

        if(localMousePosition.y > playerPosition.y + lowerMouseVerticalMovementLimit && sqrtCR >= radius){

            LineRenderer lr = GetComponent<LineRenderer>();
            lr.startWidth = .1f;
            lr.endWidth = .1f;
            lr.startColor = lr.endColor = Color.red;
            lr.SetPositions(new Vector3[]{playerPosition, transform.position});
            transform.position = new Vector3(localMousePosition.x, localMousePosition.y, 0f);
            transform.rotation = rotationOfCursor;
        }
    }
}
