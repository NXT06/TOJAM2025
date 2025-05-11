using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class KissCheckCT : ConditionTask {

		public BBParameter<float> kissRange;
		public BBParameter<Transform> playerTransform;

		protected override bool OnCheck() {
			Vector3 coworkerToPlayer = playerTransform.value.position - agent.transform.position;

			return Input.GetKeyDown("space") && coworkerToPlayer.magnitude <= kissRange.value;
		}
	}
}