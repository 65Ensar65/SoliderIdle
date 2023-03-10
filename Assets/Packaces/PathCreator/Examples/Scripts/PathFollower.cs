using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public List<PathCreator> pathCreator = new List<PathCreator>();
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;

        void Start() 
        {
            GameObject obj = GameObject.Find("PathCreator");

            for (int i = 0; i < pathCreator.Count; i++)
            {
                pathCreator[i] = obj.transform.GetChild(i).GetComponent<PathCreator>();
                break;
            }

            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator[0].pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator[0].path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator[0].path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator[0].path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}