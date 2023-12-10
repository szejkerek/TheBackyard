using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// Static class responsible for bootstrapping systems during the runtime initialization.
/// </summary>
public static class SystemsBootstrapper
{
    /// <summary>
    /// This method is automatically called before the first scene is loaded.
    /// It instantiates the "PersistentSystems" Addressable Asset and marks it as "Don't Destroy On Load."
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        // Instantiate the "PersistentSystems" Addressable Asset and prevent it from being destroyed on scene changes
        Object.DontDestroyOnLoad(Addressables.InstantiateAsync("PersistentSystems").WaitForCompletion());
    }
}