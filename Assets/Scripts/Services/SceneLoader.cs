using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IS.Services
{
    public class SceneLoader : ISceneLoader
    {
        public async Task LoadAsync(string sceneName)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            await asyncOperation;
        }
    }
}
