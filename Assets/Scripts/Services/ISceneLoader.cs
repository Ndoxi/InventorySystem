using System.Threading.Tasks;

namespace IS.Services
{
    public interface ISceneLoader
    {
        Task LoadAsync(string sceneName);
    }
}
