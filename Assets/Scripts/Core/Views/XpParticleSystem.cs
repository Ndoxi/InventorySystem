using UnityEngine;

namespace IS.Core.Views
{
    public class XpParticleSystem : MonoBehaviour
    {
        [SerializeField] private FloatingXpParticle _particle;
        [SerializeField] private RectTransform _spawnZone;

        public void Emit(int xp)
        {
            var randomPosition = GetRandomPosition();
            var patricle = Instantiate(_particle, randomPosition, Quaternion.identity, transform);
            patricle.Init(xp);
        }

        private Vector3 GetRandomPosition()
        {
            Vector3[] corners = new Vector3[4];
            _spawnZone.GetWorldCorners(corners);

            float x = Random.Range(corners[0].x, corners[2].x);
            float y = Random.Range(corners[0].y, corners[2].y);
            float z = _spawnZone.position.z;

            return new Vector3(x, y, z);
        }
    }
}