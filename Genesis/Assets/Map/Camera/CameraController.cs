using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class CameraController : NetworkBehaviour {

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
    public GameObject camera;

    public override void OnStartAuthority()
    {
        camera.SetActive(true);
    }

    // Use this for initialization
    void Start () 
    {
        if (!isOwned)
            camera.SetActive(false);
        
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = camera.transform.position - transform.position;
        camera.transform.position = transform.position;
    }

    // LateUpdate is called after Update each frame
    void Update () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (SceneManager.GetActiveScene().name != "Menu")
            camera.transform.position = transform.position + offset;
    }
}
