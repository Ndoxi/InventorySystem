using UnityEngine;

namespace IS.Core.Views
{
    public abstract class View : MonoBehaviour, IPanel
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}