using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace EnemyPathFinder
{
    /// <summary>
    /// De path class beheerd een array van waypoints. En houd bij bij welk waypoint een object is.
    /// Deze vormen samen het pad. 
    /// Logica die op het path niveau plaatsvindt gebeurt in deze class.
    /// Een deel van de functies welke je nodig hebt zijn hier al beschreven.
    /// </summary>
    public class Path : MonoBehaviour
    {
        public Waypoint[] wayPoints;
        public GameObject trailMaker;
        public Enemies.Spawner spawner;

        /// <summary>
        /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen.
        /// </summary>
        
        public void Awake()
        {
            wayPoints = GameObject.Find("Waypoints").GetComponentsInChildren<Waypoint>();
            spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponentInChildren<Enemies.Spawner>();
            PathIndicator();
        }

        public void PathIndicator() 
        {
             Instantiate(trailMaker, new Vector3(spawner.transform.position.x,spawner.transform.position.y + trailMaker.transform.localScale.y / 2, spawner.transform.position.z), Quaternion.identity);
        }

        public Waypoint GetNextWaypoint(Waypoint currentWaypoint)
        {
            if (currentWaypoint == null && wayPoints.Length >= 0)
            {
                return wayPoints[0];
            } else 
            {
                print( wayPoints.Length);
                for (int i = 0; i < wayPoints.Length; i++)
                {
                    if (i >= wayPoints.Length)
                    {
                        return null;
                    }
                    else if (currentWaypoint == wayPoints[i])
                    {
                        if(i + 1 >= wayPoints.Length){
                            break;
                        }
                        return wayPoints[i + 1];
                    }  
                }
            }
            Debug.Log("You have reached the end of the trail");
            return null;
        }
    }
}