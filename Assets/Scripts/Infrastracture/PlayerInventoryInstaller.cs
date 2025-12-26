using IS.Core.Mediators;
using IS.Core.Models;
using IS.Services;
using UnityEngine;

namespace IS.Infrastracture
{
    [RequireComponent(typeof(PlayerInventoryMediator))]
    public class PlayerInventoryInstaller : MonoBehaviour, IContextInitializer
    {
        public void Run()
        {
            var mediator = GetComponent<PlayerInventoryMediator>();
            var modelService = ServiceLocator.Resolve<IInventoryService>();
            mediator.Install(modelService);
        }
    }
}
