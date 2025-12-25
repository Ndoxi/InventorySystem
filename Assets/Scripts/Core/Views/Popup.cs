using UnityEngine;

namespace IS.Core.Views
{
    public abstract class Popup : MonoBehaviour, IPanel
    {
        public void Show()
        {
            //animation could be added here    
        }

        public void Hide()
        {
            Destroy(gameObject);
        }
    }
}