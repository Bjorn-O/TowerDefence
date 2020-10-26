using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawner;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(enemy, new Vector3(spawner.position.x,spawner.position.y + enemy.transform.localScale.y / 2 ,spawner.position.z ), Quaternion.identity);
        }
    }
}
}
