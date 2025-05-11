using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class WalkingAnimAT : ActionTask {

		public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<Animator> animator;

        protected override void OnUpdate()
        {
            if (navAgent.value.velocity.magnitude > 0)
            {
                //walking
                animator.value.SetBool("isWalking", true);
            }
            else if (animator.value.velocity.magnitude == 0)
            {
                //stopped
                animator.value.SetBool("isWalking", false);
            }
        }

    }
}