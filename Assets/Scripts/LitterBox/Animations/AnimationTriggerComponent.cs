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

		public bool isTriggeredOnMouseDown = false;
		public string mouseDownAnimationName = null;

		public bool isTriggeredOnMouseUp = false;
		public string mouseUpAnimationName = null;
		
		public bool isTriggeredOnMouseEnter = false;
		public string mouseEnterAnimationName = null;
		
		public bool isTriggeredOnMouseExit = false;
		public string mouseExitAnimationName = null;

		private Animator animator;

		void Awake() {
			animator = GetComponent<Animator>();
			if (buttonName == null) {
				buttonName = "button-".GenerateRandom(30);
			}
		}

		void OnMouseDown() {
			Kitten.Log("Mouse Down on ", buttonName);
			if (isTriggeredOnMouseDown && mouseDownAnimationName != null) {
				this.PlayAnimation(mouseDownAnimationName);
			}
		}

		void OnMouseUp() {
			Kitten.Log("Mouse Up on ", buttonName);
			if (isTriggeredOnMouseUp && mouseUpAnimationName != null) {
				this.PlayAnimation(mouseUpAnimationName);
			}
		}

		void OnMouseEnter() {
			Kitten.Log("Mouse Enter on ", buttonName);
			if (isTriggeredOnMouseEnter && mouseEnterAnimationName != null) {
				this.PlayAnimation(mouseEnterAnimationName);
			}
		}

		void OnMouseExit() {
			Kitten.Log("Mouse Exit on ", buttonName);
			if (isTriggeredOnMouseExit && mouseExitAnimationName != null) {
				this.PlayAnimation(mouseExitAnimationName);
			}
		}

		/// <summary>
		/// Exposed method to initialize an animation on the component. This
		/// is provided to make it easy to wire up to any Event component that
		/// may also be available on the component (especially useful for UI buttons)
		/// </summary>
		/// <param name="animationName"></param>
		public void PlayAnimation(string animationName) {
			Kitten.Log("Animation Starting", buttonName);
			animator.Play(animationName);
		}

		/// <summary>
		/// This is intended to be wired up in your animation controller, that
		/// can be triggered via an AnimationEvent. It can of course be called
		/// manually from code, if you're tracking Animation states that way
		/// </summary>
		public void OnTriggeredAnimationComplete() {
			Kitten.Log("Animation Trigger Complete", buttonName);
			onAnimationCompleted.Invoke(buttonName);
		}
	}
}