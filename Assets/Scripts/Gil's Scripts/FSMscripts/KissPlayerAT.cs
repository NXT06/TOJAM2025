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

		public BBParameter<Light> visionConeLight;
		ParticleSystem particleSystem;

        protected override string OnInit()
		{
			particleSystem = agent.GetComponent<ParticleSystem>();
            playerController = playerTransform.value.gameObject.GetComponent<PlayerController>();
			
			return null;
        }

		protected override void OnExecute() {
			playerController.isKissing = true;
			kissTimer = 0;
			particleSystem.Play();
		}

		protected override void OnUpdate() {


			//rotate coworker
			Vector3 playerToWorker = playerTransform.value.position - agent.transform.position;
			playerToWorker.y = 0;
			Quaternion targetRotation1 = Quaternion.LookRotation(playerToWorker.normalized);
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, targetRotation1, rotationSpeed * Time.deltaTime);

			//rotate player
			Vector3 workerToPlayer = agent.transform.position - playerTransform.value.position;
			workerToPlayer.y = 0;
            Quaternion targetRotation2 = Quaternion.LookRotation(workerToPlayer.normalized);
            playerTransform.value.rotation = Quaternion.Slerp(playerTransform.value.rotation, targetRotation2, rotationSpeed * Time.deltaTime);

			//deactivate vision cone
			visionConeLight.value.enabled = false;

            //Kiss timer to turn player movement back on
            kissTimer += Time.deltaTime;
			if (kissTimer >= kissDuration)
			{
                //reactivate vision cone
				particleSystem.Stop();
                visionConeLight.value.enabled = true;

                playerController.isKissing = false;
				EndAction(true);
			}
		}


	}
}