using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePersionController : MonoBehaviour {

    public GameObject player;
    public GameObject mainCamera;
    public GameObject cameraCollisionBox;
    public CollisionCounter cameraProbe;
    public CollisionCounter frontProbe;

    public float vertiaclRatio;
    public float maxDistance;
    public float moveSpeed;

    // Use this for initialization
    void Start () {
        
    }
	
    // Update is called once per frame
    void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 distance = mainCamera.transform.position - player.transform.position;
        distance.y = 0;

        if (vertical > 0) {
            player.GetComponent<Rigidbody>().velocity = forward * moveSpeed;
            //Camera chases the player
            if (distance.magnitude > maxDistance) {
                float originY = cameraCollisionBox.transform.position.y;
                Vector3 newPosition = player.transform.position + distance.normalized * maxDistance;
                newPosition.y = originY;
                cameraCollisionBox.transform.position = newPosition;
            }

        } else if (vertical < 0) {
            player.GetComponent<Rigidbody>().velocity = -forward * moveSpeed;

            //Camera chases the player
            float originY = cameraCollisionBox.transform.position.y;
            Vector3 newPosition = player.transform.position + distance.normalized * maxDistance;
            newPosition.y = originY;
            cameraCollisionBox.transform.position = newPosition;
        } else {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }


    void CalculateHeight () {
        Vector3 originVector = mainCamera.transform.position;
        Vector3 localVector = mainCamera.transform.localPosition;

        originVector.y = player.transform.position.y;
        localVector.y = maxDistance - (originVector - player.transform.position).magnitude;

        mainCamera.transform.localPosition = localVector * vertiaclRatio;
    }
}
