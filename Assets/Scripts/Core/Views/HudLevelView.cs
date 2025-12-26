using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class HudLevelView : View
    {
        private const string XpText = "{0} / {1}";

        [SerializeField] private TextMeshProUGUI _levelTextMesh;
        [SerializeField] private TextMeshProUGUI _xpTextMesh;
        [SerializeField] private Image _levelProgressImage;

        public void OnLevelUpdated(int level, int currentXp, int nextLevelXp)
        {
            _levelTextMesh.text = level.ToString();
            OnXpUpdated(currentXp, nextLevelXp);
        }

        public void OnXpUpdated(int currentXp, int nextLevelXp)
        {
            _xpTextMesh.text = string.Format(XpText, currentXp, nextLevelXp);
            _levelProgressImage.fillAmount = (float)currentXp / nextLevelXp;
        }
    }
}