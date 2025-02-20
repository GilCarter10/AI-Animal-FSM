using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatAT : ActionTask {

		private Animator animator;
		private float timer = 0f;
		public float eatTime;
		public BBParameter<GameObject> currentSeaweed;

		protected override string OnInit() {
            animator = agent.GetComponentInChildren<Animator>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			animator.SetBool("Eating", true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer += Time.deltaTime;
			if (timer >= eatTime)
			{
                timer = 0f;
                EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
            animator.SetBool("Eating", false);
			
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}