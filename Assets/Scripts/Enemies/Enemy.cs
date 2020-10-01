using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _damageAmount;

        void Start()
        {
            SetupEnemy();
        }

        private void SetupEnemy()
        {
            Health playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
        }
    }
}
