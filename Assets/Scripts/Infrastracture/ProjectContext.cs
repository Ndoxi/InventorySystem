using IS.Data.Configs;
using IS.Services;

namespace IS.Infrastracture
{
    public class ProjectContext : IContext
    {
        private readonly ScriptableObjectsProviderConfig _scriptableObjectsProviderConfig;

        public ProjectContext(ScriptableObjectsProviderConfig scriptableObjectsProviderConfig)
        {

            _scriptableObjectsProviderConfig = scriptableObjectsProviderConfig;
        }

        public void Install()
        {
            ServiceLocator.Register<IConfigProvider>(new ConfigProvider(_scriptableObjectsProviderConfig.configs));
            ServiceLocator.Register<ISceneLoader>(new SceneLoader());

        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<IConfigProvider>();
            ServiceLocator.Unregister<ISceneLoader>();
        }
    }
}
