using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ToggleLightAT : ActionTask {

		public BBParameter<Light> light;
		public bool active;

		protected override void OnExecute() {
			if (active)
			{
				light.value.enabled = true;
			} else
			{
				light.value.enabled = false;
			}
			EndAction(true);
		}

	}
}