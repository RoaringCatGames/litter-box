using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LitterBox.Physics {
	[RequireComponent(typeof(Rigidbody2D))]
	public class VelocityBooster2D : MonoBehaviour {

		public Vector2 forceAdjustments = new Vector2();
		public bool shouldApplyRelative = true;
		public bool isInfinite = true;
		public float lifespan = 1f;

		private Rigidbody2D body;
		private float elapsedTime = 0f;
		// Use this for initialization
		void Awake () {
			body = GetComponent<Rigidbody2D>();	
		}
		
		// Update is called once per frame
		void FixedUpdate () {
			if(!isInfinite){
				elapsedTime += Time.fixedDeltaTime;
			}
			if(isInfinite || elapsedTime < lifespan){
				if(shouldApplyRelative) {
					body.AddRelativeForce(forceAdjustments, ForceMode2D.Force);
				} else {
					body.AddForce(forceAdjustments, ForceMode2D.Force);	
				}
			}else{
				Destroy(this);
			}
		}
	}
}
