using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class SeesPlayerCheatingCT : ConditionTask {

        public BBParameter<Transform> playerTransform;
        private PlayerController playerController;

		public BBParameter<bool> playerInSight;

        protected override string OnInit(){
            playerController = playerTransform.value.gameObject.GetComponent<PlayerController>();
            return null;
		}

		protected override bool OnCheck() {
			return playerInSight.value && playerController.isKissing;
		}
	}
}