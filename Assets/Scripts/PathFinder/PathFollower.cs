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
        private Path _path;      
        public Vector3 destination;
        private Waypoint _currentDestination; 
        
        private int _currentPosition = 0;
        private float _speed = 1.5f;
 
       

        void Awake() 
        {
            _path = GameObject.FindObjectOfType<Path>();
            _currentDestination = _path.GetNextWaypoint(_currentDestination);
            destination = _currentDestination.Position;
            transform.LookAt(destination + new Vector3(0, transform.localScale.y / 2, 0 ));
        }

        void Update()
        {   
            if (_path == null) return; 
            if (_path.wayPoints.Length == 0) return;
            if (_currentDestination == null)
            {
                //The End.
                return;
            }     

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(destination.x, destination.y + transform.localScale.y / 2, destination.z), _speed * Time.deltaTime);
            if(transform.position == new Vector3(destination.x, destination.y + transform.localScale.y / 2, destination.z)){
                _currentDestination = _path.GetNextWaypoint(_currentDestination);
                if (_currentDestination != null)
                {
                    destination = _currentDestination.Position;
                    transform.LookAt(destination + new Vector3(0, transform.localScale.y / 2, 0 ));
                }
            }
        }
    }
}