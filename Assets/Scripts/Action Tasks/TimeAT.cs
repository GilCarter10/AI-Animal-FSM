using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TimeAT : ActionTask {

		public BBParameter<float> time;
		public BBParameter<Light> sun;

		private Color day;
		private Color night;

		protected override string OnInit() {
			day = new Color(255, 244, 214);
			night = new Color(74, 115, 166);
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			time.value += Time.deltaTime;
			if (time.value >= 30) //is night has ended, reset to morning
			{
				time.value = 0;
			}

			if (time.value < 15)
			{
				//daytime signifiers
				sun.value.intensity = Mathf.Lerp(0.1f, 1, time.value);

			}
			else if (time.value > 15)
			{
				//nighttime signifiers
				sun.value.intensity = Mathf.Lerp(1, 0.1f, time.value);
			}

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}