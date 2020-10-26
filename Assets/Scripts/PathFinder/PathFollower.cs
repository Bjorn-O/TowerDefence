using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyPathFinder
{
    /// <summary>
    /// De path follower class is verantwoordelijk voor de beweging.
    /// Deze class zorgt ervoor dat het object (in Tower Defense) vaak een enemy, het path afloopt
    /// tip: je kunt de transform.LookAt() functie gebruiken en vooruitbewegen.
    /// </summary>
    public class PathFollower : MonoBehaviour
    {
        protected Path _path;      
        protected Vector3 destination;
        protected Waypoint _currentDestination; 
        [SerializeField] protected float _speed = 10f;

        [SerializeField] protected bool looping;
 

        protected void Awake() 
        {
            FindPath();
        }

        protected void Update()
        {   
            MoveGameObject();       
        }

        protected void MoveGameObject()
        {
            if (_path == null) return; 
            if (_path.wayPoints.Length == 0) return;
            if (_currentDestination == null)
            {
                Debug.Log("Pathfollower has reached it's end");
                ReachedEnd();
                return;
            }     

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(destination.x, destination.y + transform.localScale.y / 2, destination.z), _speed * Time.deltaTime);
            DestinationChecker(transform.position);

        }
        
        protected void DestinationChecker(Vector3 currentPos)
        {
            if (currentPos == new Vector3(destination.x, destination.y + transform.localScale.y / 2, destination.z))
            {
                RequestNextWaypoint();
            }
        }

        protected void RequestNextWaypoint()
        {
            _currentDestination = _path.GetNextWaypoint(_currentDestination);
            
            if (_currentDestination != null)
            {
                destination = _currentDestination.Position;
                transform.LookAt(destination + new Vector3(0, transform.localScale.y / 2, 0 ));
            }
        }

        protected void FindPath()
        {
            _path = GameObject.FindObjectOfType<Path>();
            _currentDestination = _path.GetNextWaypoint(_currentDestination);
            destination = _currentDestination.Position;
            transform.LookAt(destination + new Vector3(0, transform.localScale.y / 2, 0 ));
        }

        protected virtual void ReachedEnd()
        {
            Destroy(gameObject);    
        }
    }
}