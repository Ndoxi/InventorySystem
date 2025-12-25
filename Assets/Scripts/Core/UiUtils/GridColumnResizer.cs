using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace IS.Core.UiUtils
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class GridColumnResizer : MonoBehaviour
    {
        [SerializeField] private float _targetContentWidth;
        private GridLayoutGroup _gridLayoutGroup;
        private RectTransform _rectTransform;

        private void OnValidate()
        {
            ResizeCells();
        }

        private void OnRectTransformDimensionsChange()
        {
            ResizeCells();
        }

        private void ResizeCells()
        {
            if (_gridLayoutGroup == null)
                _gridLayoutGroup = GetComponent<GridLayoutGroup>();
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();

            if (_gridLayoutGroup.constraint != GridLayoutGroup.Constraint.FixedColumnCount)
                return;

            float totalSpacing = _gridLayoutGroup.spacing.x * (_gridLayoutGroup.constraintCount - 1);
            float availableWidth = _rectTransform.rect.width - totalSpacing;

            float cellWidth = availableWidth / _gridLayoutGroup.constraintCount;
            float cellHeight = _gridLayoutGroup.cellSize.y;

            _gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
        }
    }
}
