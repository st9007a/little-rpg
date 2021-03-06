﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePersonController : MonoBehaviour {

    public GameObject player;
    public GameObject mainCamera;
    public GameObject cameraCollisionBox;
    public CollisionCounter cameraProbe;
    public CollisionCounter frontProbe;

    public float vertiaclRatio;
    public float maxDistance;
    public float moveSpeed;

    public bool isHoriMove;
    public bool isVertMove;

    public Vector3 horiVelocity;
    public Vector3 vertVelocity;

    Rigidbody rb;

    private float idleTimer;
    private float jumpTimer;

    void Start () {
        rb = player.GetComponent<Rigidbody>();
    }

    void Update () {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = mainCamera.transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 distance = mainCamera.transform.position - player.transform.position;
        distance.y = 0;

        if (vertical > 0) {
            vertVelocity = forward * moveSpeed;
            if (distance.magnitude > maxDistance) {
                float originY = cameraCollisionBox.transform.position.y;
                Vector3 newPosition = player.transform.position + distance.normalized * maxDistance;
                newPosition.y = originY;
                cameraCollisionBox.transform.position = newPosition;
            }

            isVertMove = true;

            if (cameraProbe.counter > 0) {
                CalculateHeight();
            }

        } else if (vertical < 0) {
            vertVelocity = -forward * moveSpeed;
            if (cameraProbe.counter <= 0) {
                float originY = cameraCollisionBox.transform.position.y;
                Vector3 newPosition = player.transform.position + distance.normalized * maxDistance;
                newPosition.y = originY;
                cameraCollisionBox.transform.position = newPosition;
            } else {
                CalculateHeight();
            }

            isVertMove = true;
        } else {
            isVertMove = false;
        }

        if (horizontal > 0) {
            if (frontProbe.counter > 0) {
                cameraCollisionBox.transform.position += -right * moveSpeed * Time.deltaTime;
            }

            horiVelocity = right * moveSpeed;
            isHoriMove = true;

        } else if (horizontal < 0) {
            if (frontProbe.counter > 0) {
                cameraCollisionBox.transform.position += right * moveSpeed * Time.deltaTime;
            }
            horiVelocity = -right * moveSpeed;
            isHoriMove = true;
        } else {
            isHoriMove = false;
        }


        Draw();
    }

    void CalculateHeight () {
        Vector3 originVector = mainCamera.transform.position;
        Vector3 localVector = mainCamera.transform.localPosition;

        originVector.y = player.transform.position.y;
        localVector.y = maxDistance - (originVector - player.transform.position).magnitude;

        mainCamera.transform.localPosition = localVector * vertiaclRatio;
    }

    public void Draw() {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        if (isHoriMove) {
            rb.velocity += horiVelocity;
        }
        if (isVertMove) {
            rb.velocity += vertVelocity;
        }

        if (isVertMove || isHoriMove) {
            float rotate = Mathf.Atan2(rb.velocity.x, rb.velocity.z);
            player.transform.rotation = Quaternion.Euler(0, rotate / Mathf.PI * 180, 0);

            idleTimer = 0.05f;
        } else {
            if (idleTimer >= 0) {
                idleTimer -= Time.deltaTime;
            } else {
                Vector3 newVel = rb.velocity;
                newVel.x = 0;
                newVel.z = 0;
                rb.velocity = newVel;
            }
        }

    }
}
