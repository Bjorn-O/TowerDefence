using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyPathFinder
{
        public class TrailMaker : PathFollower
    {
        new public ParticleSystem particleSystem;

        
        protected override void ReachedEnd() 
        {
            if (particleSystem.particleCount == 0)
            {
                _path.PathIndicator();
                base.ReachedEnd();
            }

        }
    }
}
