using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (GravityBody))]
public class Controller : MonoBehaviour
 {
	
	// public vars
	public float mouseSensitivityX = 1f;
	public float mouseSensitivityY = 1f;
	public float walkSpeed = 6;
	public float jumpForce = 220;
	public LayerMask groundedMask;
	
	// System vars
	bool grounded;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	float verticalLookRotation;
	Transform cameraTransform;
	Rigidbody rb;
	
	
	void Awake() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cameraTransform = Camera.main.transform;
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update() {
		
		// Look rotation:
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY ;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation,-30,15);
		cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
		
		// Calculate movement:
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
		
		Vector3 moveDir = new Vector3(inputX,0, inputY).normalized * Time.deltaTime;
		Vector3 targetMoveAmount = moveDir * walkSpeed * Time.smoothDeltaTime;
		moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);
		
		// Jump
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (grounded) {
				rb.AddForce(transform.up * jumpForce);
                Debug.Log("Is jumping");
			}
		}
		
		// Grounded check
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask)) {
			grounded = true;
			Debug.Log("Grounded");
		}
		else {
			grounded = false;
		}
		
	}
	
	void FixedUpdate() {
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + localMove);
	}
}
