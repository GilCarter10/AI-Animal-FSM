using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatAT : ActionTask {

		private Animator animator;
		private float timer = 0f;
		public float eatTime;
		public BBParameter<bool> foundSeaweed;
		public BBParameter<GameObject> currentSeaweed;

        public BBParameter<GameObject> particleSys;

        protected override string OnInit() {
            animator = agent.GetComponentInChildren<Animator>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			animator.SetBool("Eating", true);
			foundSeaweed.value = false;

			//get the blackboard for the current seaweed and set the eaten bool to true
			Blackboard seaweedBlackboard = currentSeaweed.value.GetComponent<Blackboard>();
			seaweedBlackboard.SetVariableValue("eaten", true);

            particleSys.value.SetActive(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//timer to the turtle has time to do animations
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
            particleSys.value.SetActive(false);

        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}