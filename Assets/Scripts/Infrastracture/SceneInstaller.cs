using UnityEngine;

namespace IS.Infrastracture
{
    public class SceneInstaller : MonoBehaviour
    {
        private IContext _context;

        public void InstallContext(IContext context)
        {
            _context = context;
            context.Install();
        }

        private void OnDestroy()
        {
            _context?.Uninstall();
        }
    }
}
