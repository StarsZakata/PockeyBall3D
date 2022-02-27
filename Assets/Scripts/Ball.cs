using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball: MonoBehaviour{
	private Rigidbody rigidbody;
	[SerializeField] private float JumpForce;

	[SerializeField] private GameObject Tree;

	private void Start()	{
		rigidbody = GetComponent<Rigidbody>();
		TreeActiveFalse();
	}

	private void Update()	{
		if (Input.GetMouseButtonDown(0)) {
			TreeActiveFalse();
			rigidbody.isKinematic = false;
			rigidbody.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
		}

		if (Input.GetMouseButtonUp(0)) {
			Ray ray = new Ray(transform.position, Vector3.forward);
			if (Physics.Raycast(ray, out RaycastHit hitInfo)) {
				if (hitInfo.collider.TryGetComponent(out Segment segment))
				{
					rigidbody.isKinematic = true;
					rigidbody.velocity = Vector3.zero;
					Tree.SetActive(true);
				}
				else if (hitInfo.collider.TryGetComponent(out Block block)) {
					Debug.Log("GameOver");
					TreeActiveFalse();

				} else if (hitInfo.collider.TryGetComponent(out Finish fifnish)) {
					///< Реализация
					Debug.Log("You Win");
					TreeActiveFalse();
				}
			}	
		}
	}
	private void TreeActiveFalse() {
		Tree.SetActive(false);
	}
}
