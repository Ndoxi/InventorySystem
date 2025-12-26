using TMPro;
using UnityEngine;

namespace IS.Core.Views
{
    public class HudGoldView : View
    {
        [SerializeField] private TextMeshProUGUI _textMesh;

        public void UpdateGold(int value)
        {
            _textMesh.text = value.ToString();
        }
    }
}