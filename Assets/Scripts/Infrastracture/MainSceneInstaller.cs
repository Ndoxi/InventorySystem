using UnityEngine;

namespace IS.Infrastracture
{
    public class MainSceneInstaller : SceneInstaller, IContextInitializer
    {
        [SerializeField] private Canvas _viewCanvas;

        public void Run()
        {
            InstallContext(new MainSceneContext(_viewCanvas));
        }
    }
}
