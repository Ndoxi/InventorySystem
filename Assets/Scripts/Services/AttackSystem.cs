using IS.Core.Gameplay;
using System.Collections;
using UnityEngine;

namespace IS.Services
{
    public class AttackSystem : IAttackSystem
    {
        private const float MultiHitInterval = 0.1f;

        private int _hitsPerAttack = 1;

        public void Attack(TrainingDummyView trainingDummy)
        {
            if (_hitsPerAttack < 2)
                trainingDummy.OnHit();
            else
                trainingDummy.StartCoroutine(PerformMultiHitAttack(trainingDummy));
        }

        public void AddMultiHit()
        {
            _hitsPerAttack++;
        }

        private IEnumerator PerformMultiHitAttack(TrainingDummyView trainingDummy)
        {
            int hitsPerAttack = _hitsPerAttack;
            var yieldInstruction = new WaitForSeconds(MultiHitInterval);

            for (int i = 0; i < hitsPerAttack; i++)
            {
                trainingDummy.OnHit();
                yield return yieldInstruction;
            }
        }
    }
}
