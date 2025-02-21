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

		//variables for finding seaweed
		public BBParameter<SeaweedManager> seaweedManager; //a script on another game object to spawn the seaweed
		public BBParameter<bool> seaweedFound; //bool for whether a seaweed has been found or not
		public BBParameter<GameObject> currentSeaweed; //the current seaweed game object (if one has been found)

		public float searchTime;
		private float searchTimer;

		public BBParameter<GameObject> particleSys;

        protected override string OnInit() {
			animator = agent.GetComponentInChildren<Animator>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			animator.SetBool("Searching", true);
			searchTimer = 0;

			//for all the seaweed currently in the world
			for (int i = 0; i < seaweedManager.value.spawnedSeaweed.Count; i++)
			{
				//check the distance to them
				Vector3 toSeaweed = agent.transform.position - seaweedManager.value.spawnedSeaweed[i].transform.position;

				//if the distance is less than the search radius, we've found a seaweed and assign that to the current seaweed variable
                if (toSeaweed.magnitude < searchRadius)
                {
                    seaweedFound.value = true; //we have found a seaweed
					currentSeaweed.value = seaweedManager.value.spawnedSeaweed[i]; //set found seaweed to the current one in the for loop
                }
            }

			particleSys.value.SetActive(true);

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//a timer so the turtle stays in search state long enough for it to do the animation
			searchTimer += Time.deltaTime;
			if (searchTimer >= searchTime)
			{
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
            animator.SetBool("Searching", false);
            particleSys.value.SetActive(false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}