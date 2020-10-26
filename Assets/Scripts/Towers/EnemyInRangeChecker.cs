using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class EnemyInRangeChecker : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layer;
        public Enemies.Enemy GetFirstEnemyInRange()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
            if (cols.Length < 1)
                return null;

            return cols[0].GetComponent<Enemies.Enemy>();
        }

        public Enemies.Enemy[] GetAllEnemiesInRange()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
            if (cols.Length < 1)
                return null;

            List<Enemies.Enemy> enemiesInRange = new List<Enemies.Enemy>();
            foreach (var col in cols)
            {
                enemiesInRange.Add(col.GetComponent<Enemies.Enemy>());
            }

            return enemiesInRange.ToArray();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
