using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class TimeOfDayCT : ConditionTask {

		public enum timeOfDay { Daytime, Nighttime}
		public timeOfDay timeToCheckFor;

		public BBParameter<float> time;

		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (time.value < 15)
			{
				//daytime
				if (timeToCheckFor == timeOfDay.Daytime) return true;
			} else if (time.value >= 15)
			{
				//nighttime
				if (timeToCheckFor == timeOfDay.Nighttime) return true;
			}
			return false;

		}
	}
}