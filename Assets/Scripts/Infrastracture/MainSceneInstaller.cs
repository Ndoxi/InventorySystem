using UnityEngine;

namespace IS.Infrastracture
{
    public class MainSceneInstaller : SceneInstaller, IContextInitializer
    {
        [Header("Canvases")]
        [SerializeField] private Canvas _viewCanvas;
        [SerializeField] private Canvas _popupCanvas;

        public void Run()
        {
            InstallContext(new MainSceneContext(_viewCanvas, _popupCanvas));
        }
    }
}
