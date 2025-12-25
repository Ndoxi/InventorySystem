using UnityEngine;

namespace IS.Infrastracture
{
    [RequireComponent(typeof(IContextInitializer))]
    public class ContextRunner : MonoBehaviour
    {
        private void Awake()
        {
            var intaller = GetComponent<IContextInitializer>();
            intaller.Run();
        }
    }
}
