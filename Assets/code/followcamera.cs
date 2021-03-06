using UnityEngine;

public class followcamera : MonoBehaviour
{
    public Transform target;

	public float smoothSpeed = .1f;
	public Vector3 offset;

	void LateUpdate ()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}
}
