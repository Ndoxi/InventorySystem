using TMPro;
using UnityEngine;

namespace IS.Core.Views
{
    public class FloatingXpParticle : MonoBehaviour 
    {
        private const string Text = "+{0} XP";

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _lifetime = 1f;
        [SerializeField] private float _floatSpeed = 1f;

        private float _time;

        public void Init(int xp)
        {
            _text.text = string.Format(Text, xp);
        }

        private void Update()
        {
            transform.localPosition += _floatSpeed * Time.deltaTime * Vector3.up;

            _time += Time.deltaTime;

            float alpha = Mathf.Lerp(1f, 0f, _time / _lifetime);
            _text.alpha = alpha;

            if (_time >= _lifetime)
                Destroy(gameObject);
        }
    }
}