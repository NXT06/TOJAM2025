using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class TakeHitAT : ActionTask {

		protected override void OnExecute() {
            Lives.Hit();
            EndAction(true);
        }

	}
}