using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject player;
    public Camera viewport;
    public Vector3 positionOffset;

    public float radius;
    public float xLimit;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        //This needs some serious cleanup.
        /*Basically, we want to lock the range of movement for our cursor on a half circle above and surrounding the player.
        * The half circle is around the player. We use this to help our player orient their jump to the next block.
        * Right now, the code works as follows.
        * 1) Locate the player, mouse, and cursor/pointer's position. Store them as vectors. Convert the screen location of the mouse to the world location.
        * 2) Create a rotation where the cursor/pointer will point in the direction of the mouse.
        * 3) Get the mouse postion, and apply limits to it. Create a new vector, and apply the rotation and mouse-dependant position to the cursor/pointer.
        */
        Vector3 playerPosition = player.transform.position;
        Vector3 mousePosition = Input.mousePosition;
        Vector3 localMousePosition = viewport.ScreenToWorldPoint(mousePosition);

        float angle = Vector3.Angle(playerPosition, localMousePosition);
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        if(y < 0){
            y = 0;
            if (x < 0){
               x = -xLimit;
            }
            if (x > 0){
                x = xLimit;
            }
        }

        if(x > xLimit){
            x = xLimit;
        }
        Vector3 newPosition = new Vector3(x, y, 0) + positionOffset;
        transform.position = newPosition;

    }
}
