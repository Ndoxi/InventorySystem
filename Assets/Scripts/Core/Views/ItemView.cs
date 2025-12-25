using IS.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class ItemView<TData> : MonoBehaviour where TData : IItemData
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _nameTextMesh;
        [SerializeField] private TextMeshProUGUI _descriptionTextMesh;
        protected TData _data;

        public void Init(TData data)
        {
            _data = data;
            UpdateView();
        }

        protected virtual void UpdateView()
        {
            _icon.sprite = _data.icon;
            _nameTextMesh.text = _data.itemName;
            _descriptionTextMesh.text = _data.description;
        }
    }
}