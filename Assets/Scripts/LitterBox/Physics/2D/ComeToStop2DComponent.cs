using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LitterBox.Physics {
	public class ComeToStop2DComponent : MonoBehaviour {

		public float duration = 1f;

		private float elapsedTime = 0f;	
		private Vector3 initialVelocity;
		private Vector3 targetVelocity = new Vector3(0f, 0f, 0f);

		private Rigidbody2D bodyToSlowdown;
		// Use this for initialization
		void Awake () {
			//Pull out the parent RigidBody if exists
			bodyToSlowdown = GetComponentInParent<Rigidbody2D>();
			if(bodyToSlowdown == null){
				bodyToSlowdown = GetComponent<Rigidbody2D>();
			}		
			initialVelocity = bodyToSlowdown.velocity;
		}
		
		// Update is called once per frame
		void LateUpdate () {
			if(bodyToSlowdown != null){
				if(elapsedTime < duration){
					elapsedTime += Time.deltaTime;
					
					float stepPosition = Mathf.Clamp(duration - (duration - elapsedTime), 0f, duration);				
					Vector3 newVelocity = Vector3.Lerp(initialVelocity, targetVelocity, stepPosition);				
					bodyToSlowdown.velocity = newVelocity;
				}else{
					bodyToSlowdown.velocity = targetVelocity;
				}
			}
		}
	}
}