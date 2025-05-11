using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class KissPlayerAT : ActionTask {

		public BBParameter<Transform> playerTransform;
		private PlayerController playerController;

		public float rotationSpeed;
        private Quaternion currentRotation;

        public float kissDuration;
		private float kissTimer;
		
		protected override string OnInit()
		{
            playerController = playerTransform.value.gameObject.GetComponent<PlayerController>();
			return null;
        }

		protected override void OnExecute() {
			playerController.isKissing = true;
		}

		protected override void OnUpdate() {
       
			//rotate coworker
			Vector3 playerToWorker = playerTransform.value.position - agent.transform.position;
			Quaternion targetRotation1 = Quaternion.LookRotation(playerToWorker.normalized);
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, targetRotation1, rotationSpeed * Time.deltaTime);

			//rotate player
			Vector3 workerToPlayer = agent.transform.position - playerTransform.value.position;
            Quaternion targetRotation2 = Quaternion.LookRotation(workerToPlayer.normalized);
            playerTransform.value.rotation = Quaternion.Slerp(playerTransform.value.rotation, targetRotation2, rotationSpeed * Time.deltaTime);


            //Kiss timer to turn player movement back on
            kissTimer += Time.deltaTime;
			if (kissTimer >= kissDuration)
			{
				playerController.isKissing = false;
				EndAction(true);
			}
		}


	}
}