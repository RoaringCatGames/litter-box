using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitterBox.Extensions;
using LitterBox.Debug;

namespace LitterBox.Animations {

	[RequireComponent(typeof(Animator))]
	public class AnimationTriggerComponent : MonoBehaviour {

		public string buttonName;
		public AnimationTriggerCompleteEvent onAnimationCompleted;

		private Animator animator;

		void Awake() {
			animator = GetComponent<Animator>();
			if (buttonName == null) {
				buttonName = "button-".GenerateRandom(30);
			}
		}

		public void PlayAnimation(string animationName) {
			Kitten.Log("Animation Trigger Complete", buttonName);
			animator.Play(animationName);
		}

		public void OnTriggeredAnimationComplete() {
			Kitten.Log("Animation Trigger Complete", buttonName);
			onAnimationCompleted.Invoke(buttonName);
		}
	}
}