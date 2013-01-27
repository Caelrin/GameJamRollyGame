using UnityEngine;
using System.Collections;

public class CollisionHelper : MonoBehaviour {
	
	private static float mag = .05f;
	
	public static Vector3 GetVelocityAfterCollision (Vector3 objectNormal, Vector3 playerVelocity)
	{
		Vector3 velNormal = playerVelocity.normalized;
		Vector3 afterHitVelocity = new Vector3();
		afterHitVelocity.y = playerVelocity.y + (objectNormal.y * playerVelocity.y) + (playerVelocity.x * objectNormal.x) + (playerVelocity.z * objectNormal.z);
		afterHitVelocity.x = playerVelocity.x - (objectNormal.x * mag);
		afterHitVelocity.z = playerVelocity.z - (objectNormal.z * mag);
		return afterHitVelocity;
	}
}
