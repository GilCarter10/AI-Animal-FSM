using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class SearchAT : ActionTask {

        private NavMeshAgent navAgent;
        private Animator animator;

        public float searchRadius;
		public BBParameter<Transform> seaweed;
		public static bool seaweedFound = false;

        protected override string OnInit() {
			animator = agent.GetComponent<Animator>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			animator.SetBool("Searching", true);
			
			Vector3 toSeaweed = seaweed.value.position - agent.transform.position;
			if (toSeaweed.magnitude < searchRadius)
			{
				seaweedFound = true;
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

		}

		//Called when the task is disabled.
		protected override void OnStop() {
            animator.SetBool("Searching", false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}