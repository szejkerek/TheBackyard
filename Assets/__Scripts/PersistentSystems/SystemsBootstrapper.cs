using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// Static class responsible for bootstrapping systems during the runtime initialization.
/// </summary>
public static class SystemsBootstrapper
{
    /// <summary>
    /// This method is automatically called before the first scene is loaded.
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        Object.DontDestroyOnLoad(Addressables.InstantiateAsync("PersistentSystems").WaitForCompletion());
    }
}