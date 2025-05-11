using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class TakeHitAT : ActionTask {

		private bool takenHit;
		protected override void OnExecute() {
			takenHit = false;
		}

		protected override void OnUpdate() {
			if (!takenHit)
			{
				Lives.Hit();
			}
		}

	}
}