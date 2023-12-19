using UnityEngine;

/// <summary>
/// Acts similar to a singleton but when creating a new instance, it overwrites the previous one.
/// </summary>
/// <typeparam name="T">The type of MonoBehaviour for which to create a static instance.</typeparam>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// Gets the static instance of the type T.
    /// </summary>
    public static T Instance { get; private set; }

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    protected virtual void Awake()
    {
        Instance = this as T;
    }

    /// <summary>
    /// Called when the application is quitting.
    /// </summary>
    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
/// Transforms a static instance into a basic singleton.
/// </summary>
/// <typeparam name="T">The type of MonoBehaviour for which to create a singleton.</typeparam>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
{
    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    protected override void Awake()
    {
        // If an instance already exists, do not create a new one.
        if (Instance != null)
        {
            return;
        }

        base.Awake();
    }
}