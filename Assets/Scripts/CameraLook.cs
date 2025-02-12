﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {
	public float sensitivity = 60f;
	public float maxAngle = 80f;
	float rotationY = 0.0f;
	float rotationX = -57;

	public bool mouseLock = true;
	public bool allowUnlock = false;
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if(allowUnlock && Input.GetKeyDown(KeyCode.Tab)) mouseLock = !mouseLock;

		if (mouseLock) {
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			Cursor.lockState = CursorLockMode.None;
		}

		if (Input.GetKey(KeyCode.UpArrow)) rotationY += sensitivity * Time.deltaTime;
		if (Input.GetKey(KeyCode.DownArrow)) rotationY -= sensitivity * Time.deltaTime;
		if (Input.GetKey(KeyCode.LeftArrow)) rotationX -= sensitivity * Time.deltaTime;
		if (Input.GetKey(KeyCode.RightArrow)) rotationX += sensitivity * Time.deltaTime;

		rotationX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		rotationY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
		rotationY = Mathf.Clamp(rotationY, -maxAngle, maxAngle);
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	}
}
