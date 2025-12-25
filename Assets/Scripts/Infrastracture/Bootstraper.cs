using IS.Data.Constants;
using IS.Services;
using UnityEngine;

namespace IS.Infrastracture.Boostrap
{
    public class Bootstraper : MonoBehaviour
    {
        private void Awake()
        {
            Initialize();
            LoadMainScene();
        }

        private void Initialize()
        {
            ServiceLocator.Register<ISceneLoader>(new SceneLoader());
        }

        private void LoadMainScene()
        {
            var loader = ServiceLocator.Resolve<ISceneLoader>();
            loader.LoadAsync(SceneNames.MainScene);
        }
    }
}
