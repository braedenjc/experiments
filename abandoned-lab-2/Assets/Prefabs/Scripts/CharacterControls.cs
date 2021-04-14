using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{

    private Transform playerTransform;
    private Transform cameraTransform;

    private GameObject camera;
   
    public float movementSpeed = 0.0f;
    public float cameraPanRate = 0.0f;

    public float cameraTolerance = 0.0f; //Tolerance before the camera moves.

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        
        camera = GameObject.Find("Main Camera");
        cameraTransform = camera.GetComponent<Transform>();

        LoadCheck();
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        CameraDelay();
    }

    //Delayed camera move logic.
    void CameraDelay(){

        //collect XCo-ords for the camera and the player
        float positionPlayerX = playerTransform.position.x;
        float positionCameraX = cameraTransform.position.x;

        //Move the camera based on the following checks
        //If the camera position is further right than the player's co-ord summed with a tolerance
        if(positionCameraX > positionPlayerX + cameraTolerance){
            cameraTransform.position = new Vector3(positionCameraX - cameraPanRate * Time.deltaTime, 
                cameraTransform.position.y, 
                cameraTransform.position.z);
                Debug.Log("Camera should move left");
        }

        //If the camera position is further right than the player's co-ord with a tolerance subtracted.
        else if(positionCameraX < positionPlayerX - cameraTolerance){
            cameraTransform.position = new Vector3(positionCameraX + cameraPanRate * Time.deltaTime, 
                cameraTransform.position.y, 
                cameraTransform.position.z);
                Debug.Log("Camera should move right");

        }

        else{
            Debug.Log("Camera should stay still");
        }

    }

    void MovementUpdate(){
        playerTransform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed);
    }

    //Conduct a quick check of our loaded transforms to make sure that we aren't messing with null items.
    void LoadCheck(){
        if(playerTransform == null){
            Debug.Log("Cannot load player object\n");
        }

        if(camera == null){
            Debug.Log("Cannot load player child camera\n");
        }
        if(cameraTransform == null){
            Debug.Log("Cannot load player child camera transform\n");
        }
    }
}
