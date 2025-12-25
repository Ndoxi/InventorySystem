using IS.Data.Configs;
using IS.Data.Constants;
using IS.Services;
using UnityEngine;

namespace IS.Infrastracture.Boostrap
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectsProviderConfig _scriptableObjectsProviderConfig;

        private void Awake()
        {
            Initialize();
            LoadMainScene();
        }

        private void Initialize()
        {
            var go = new GameObject("Project Installer");
            var intaller = go.AddComponent<SceneInstaller>();
            intaller.InstallContext(new ProjectContext(_scriptableObjectsProviderConfig));
            DontDestroyOnLoad(go);
        }

        private async void LoadMainScene()
        {
            var loader = ServiceLocator.Resolve<ISceneLoader>();
            await loader.LoadAsync(SceneNames.MainScene);
        }
    }
}
