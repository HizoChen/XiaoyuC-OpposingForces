using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class goToWorkAT : ActionTask {
		public BBParameter<bool> isRest;
        public BBParameter<float> speed;
        public BBParameter<Vector3> destination;
		public BBParameter<float> originalSpeed;

		public BBParameter<Transform> switchGuide;
		public BBParameter<bool> isToWork;
        public BBParameter<int> currentIndex;

		public Blackboard board;

       
        protected override string OnInit() {
			
			return null;
		}


		protected override void OnExecute() {
            //If the current agent is not in the is To work state, it will go to the next wait to rest state
            if (!isToWork.value)
			{
				EndAction(true);
			}
			else
			{
              
            }
			
		}

		protected override void OnUpdate() {
            destination.value = switchGuide.value.position;
            //Navigate to another police officer's location for shift
            if (Vector3.Distance(agent.transform.position, destination.value) < 5f)
			{
				
				isRest.value = false;
				isToWork.value = false;
                Debug.Log(agent.name + ": It's my time!");
                currentIndex.value = board.GetVariableValue<int>("Current Index");
                EndAction(false);
            }
        }

		
		protected override void OnStop() {
			
		}

	
		protected override void OnPause() {
			
		}
	}
}