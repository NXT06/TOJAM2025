using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DieAT : ActionTask {

		protected override void OnExecute() {
			GameObject.Destroy(agent.gameObject);
			EndAction(true);
		}
		

	}
}