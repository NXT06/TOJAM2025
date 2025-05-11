using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ShowSignifierAT : ActionTask {

		public Sprite newSignifier;
		public BBParameter<SpriteRenderer> signifier;

		protected override void OnExecute() {
            signifier.value.sprite = newSignifier;
			EndAction(true);
		}

		protected override void OnStop() {
            signifier.value.sprite = null;
		}

	}
}