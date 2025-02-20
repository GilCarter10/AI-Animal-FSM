using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class SearchAT : ActionTask {

        private NavMeshAgent navAgent;
        private Animator animator;

        public float searchRadius;


		public BBParameter<SeaweedManager> seaweedManager;
		public BBParameter<bool> seaweedFound;
		public BBParameter<GameObject> currentSeaweed;

        protected override string OnInit() {
			animator = agent.GetComponent<Animator>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			animator.SetBool("Searching", true);

			for (int i = 0; i < seaweedManager.value.spawnedSeaweed.Count; i++)
			{
				Vector3 toSeaweed = agent.transform.position - seaweedManager.value.spawnedSeaweed[i].transform.position;
                if (toSeaweed.magnitude < searchRadius)
                {
                    seaweedFound.value = true;
					currentSeaweed.value = seaweedManager.value.spawnedSeaweed[i]; //set found seaweed to the current one in the for loop
                }
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