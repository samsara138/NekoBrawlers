using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Pattern
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        [SerializeField]
        private bool isPersistentSingleton = false;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(T).Name);
                        _instance = singletonObject.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Debug.LogWarning($"Duplicated singleton componenet {typeof(T)} at object {this.gameObject.name}, removing component");
                Destroy(this.gameObject.GetComponent<T>());
                return;
            }

            _instance = this as T;

            if(isPersistentSingleton)
                DontDestroyOnLoad(this.gameObject);
        }
    }
}

