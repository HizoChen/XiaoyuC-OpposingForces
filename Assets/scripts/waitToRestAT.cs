using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class waitToRestAT : ActionTask {
        public BBParameter<bool> isRest;
        public BBParameter<Vector3> destination;

        public BBParameter<Transform> switchGuide;
        public BBParameter<Transform> rest;
      
        protected override string OnInit() {
			return null;
		}

		
		protected override void OnExecute() {
			
		}

	
		protected override void OnUpdate() {
            if (Vector3.Distance(agent.transform.position, switchGuide.value.position) < 3f) //When a police officer is meeting with another police officer, navigate to the lounge to rest.
            {
                isRest.value = true;
                Debug.Log(agent.name + ": Rest time!");
                destination.value = rest.value.position;
                EndAction(false);
            }
        }

		
		protected override void OnStop() {
			
		}

	
		protected override void OnPause() {
			
		}
	}
}