using UnityEngine;

namespace IS.Infrastracture
{
    public interface IConfigProvider
    {
        T Get<T>() where T : ScriptableObject;
    }
}
