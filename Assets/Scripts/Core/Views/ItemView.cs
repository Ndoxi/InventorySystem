using IS.Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class ItemView<TData> : MonoBehaviour where TData : IItemData
    {
        public Guid itemInstanceId => _runtimeData.instanceId;

        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _nameTextMesh;
        [SerializeField] private TextMeshProUGUI _descriptionTextMesh;
        protected IRuntimeItemData<TData> _runtimeData;

        public void Init(IRuntimeItemData<TData> data)
        {
            _runtimeData = data;
            UpdateView();
        }

        protected virtual void UpdateView()
        {
            _icon.sprite = _runtimeData.data.icon;
            _nameTextMesh.text = _runtimeData.data.itemName;
            _descriptionTextMesh.text = _runtimeData.data.description;
        }
    }
}