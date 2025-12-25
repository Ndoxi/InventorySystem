using IS.Core.Gameplay.Items;
using UnityEngine;

namespace IS.Data
{
    [CreateAssetMenu(fileName = "HealthPotionItemData", menuName = "Scriptable Objects/Data/HealthPotionItemData")]
    public class HealthPotionItemData : ItemData
    {
        [SerializeField] private float _healingAmount;

        public override IItem ToRuntime()
        {
            return new PotionItem(_healingAmount);
        }
    }
}
