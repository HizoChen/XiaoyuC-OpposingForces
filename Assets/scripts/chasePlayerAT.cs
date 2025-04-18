using System.ComponentModel.Design.Serialization;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using UnityEngine;
using System.Text.RegularExpressions;


namespace NodeCanvas.Tasks.Actions {

	public class chasePlayerAT : ActionTask {
		public BBParameter<Transform> Player;
        public BBParameter<GameObject> targetObject;
        public float checkDistance = 6f;
		public BBParameter<Vector3> destination;
		public BBParameter<bool> isChasing;
	

        protected override string OnInit() {
			return null;
		}

	
		protected override void OnExecute() {
			if(isChasing.value || Vector3.Distance(Player.value.position,agent.transform.position) < checkDistance)//Detect if the player has entered the pursuit range
            {
				destination.value = Player.value.position;
				isChasing.value = true;
                float distanceToPlayer = Vector3.Distance(Player.value.position, agent.transform.position);
                if (distanceToPlayer < 3.5f)// When the agent and the player are close enough, the player is captured.
                {
                    Debug.Log("Catch the thief");
                    targetObject.value.SetActive(false);
                }
                EndAction(false); //If the pursuit starts, it returns false, so that the patrol operation will not be performed in the behavior tree
			}
			else
			{
				EndAction(true);
			}
		}

	
		protected override void OnUpdate() {
			
		}


		protected override void OnStop() {
			
		}

	
		protected override void OnPause() {
			
		}
	}
}