using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RestAT : ActionTask {

		public BBParameter<float> eggProgress;
		public float gestationRate;

		public BBParameter<GameObject> eyes;

        public BBParameter<GameObject> particleSys;
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//close eyes and start particle sys
			eyes.value.SetActive(false);
            particleSys.value.SetActive(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//increase egg progress
			eggProgress.value += gestationRate * Time.deltaTime;

		}

		//Called when the task is disabled.
		protected override void OnStop() {
            eyes.value.SetActive(true);
            particleSys.value.SetActive(false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}