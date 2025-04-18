using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{
    public class PatrolAT : ActionTask
    {
        public BBParameter<List<Transform>> waypoints;
        public BBParameter<Vector3> destination;
        public BBParameter<int> currentIndex;
        public BBParameter<bool> isChasing;
        public BBParameter<bool> isGemExist;

       

        protected override string OnInit()
        {
           
            return null;
        }

        protected override void OnExecute()
        {
            Vector3 endpoint = destination.value; endpoint.y = 0;
            Vector3 nowpoint = agent.transform.position; nowpoint.y = 0;
            if(Vector3.Distance(endpoint, nowpoint) < 3f) //When the player reaches a point, it switches to the next point in the list and loops to implement the patrol logic
            {
                currentIndex.value = (currentIndex.value + 1) % waypoints.value.Count;
                isChasing.value = !isGemExist.value && currentIndex.value == waypoints.value.Count - 1;
            }
            destination.value = waypoints.value[currentIndex.value].position;
            EndAction();
        }

        protected override void OnUpdate()
        {

        }
    }
}