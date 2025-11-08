// (C) 2025 Ariverse Studio

using UnityEngine;
namespace AriverseStudio.Singletons
{
    /// <summary>
    /// Persistent Singleton pattern that survives scene loads and prevents duplicate instances.
    /// </summary>
    public class PersistentSingleton<T> : MonoBehaviour where T : Component
    {
        protected static T _instance;

        public static bool HasInstance => _instance != null;

        public static T TryGetInstance() => HasInstance ? _instance : null;

        public static T Current => _instance;

        /// <summary>
        /// Singleton design pattern with persistent instance checking
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name + "_AutoCreated";
                        _instance = obj.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// On awake, we check for existing instances and initialize our singleton.
        /// </summary>
        protected virtual void Awake()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            var existingInstances = FindObjectsOfType<T>();

            if (existingInstances.Length > 1)
            {
                // If this is not the first instance, destroy this one
                if (existingInstances[0] != this)
                {
                    Destroy(gameObject);
                    return;
                }
            }

            InitializeSingleton();
        }

        /// <summary>
        /// Initializes the singleton and makes it persistent.
        /// </summary>
        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            _instance = this as T;

            // Make sure the object persists between scenes
            transform.SetParent(null); // Unparent to avoid destruction with parent
            DontDestroyOnLoad(gameObject);
        }
    }
}