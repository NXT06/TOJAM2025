using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class WaitRandomTimeCT : ConditionTask {

		public BBParameter<Vector2> randomRange;
		private float randomValue;
		private float timer;

		protected override string info => $"Wait between <b>{randomRange.value.x}</b> and <b>{randomRange.value.y}</b> seconds";
		
		protected override void OnEnable() {
			timer = 0;
			randomValue = Random.Range(randomRange.value.x, randomRange.value.y);
		}

		protected override bool OnCheck() {
			timer += Time.deltaTime;
			return timer >= randomValue;
		}
	}
}