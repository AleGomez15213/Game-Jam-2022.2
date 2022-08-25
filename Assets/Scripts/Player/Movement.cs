using Project.Scripts.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	public InputAction move;
	public Rigidbody rb;

	public Camera gameCamera;

	public float moveSpeed = 5f;
	public float steerSpeed = 180f;
	private float steerDirection;

	private void OnEnable()
	{
		move.Enable();
	}

	private void OnDisable()
	{
		move.Disable();
	}

	private void Update()
	{
		transform.position += transform.forward * moveSpeed * Time.deltaTime;

		steerDirection = move.ReadValue<Vector2>().x;
		Quaternion deltaRotation = Quaternion.Euler(transform.rotation.x, steerDirection, transform.rotation.z);
		rb.MoveRotation(rb.rotation * deltaRotation);

		Ray ray = new Ray(transform.position, Vector3.down);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

	}
}
