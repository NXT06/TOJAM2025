using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class KissPlayerAT : ActionTask {

		public BBParameter<Transform> playerTransform;
		private PlayerController playerController;
		
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
			//These are making them go on that slant
			//agent.transform.LookAt(playerTransform.value.position);
			//playerTransform.value.LookAt(agent.transform.position);

			kissTimer += Time.deltaTime;
			if (kissTimer >= kissDuration)
			{
				playerController.isKissing = false;
				EndAction(true);
			}
		}


	}
}