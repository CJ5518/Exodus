using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossPattern1.Decorator
{
    public class singletonBoss<T>: MonoBehaviour where T : singletonBoss<Boss>
    {
        static private T instance = null;

        private bool stayAlive = false;
        private bool isInitialized = false;
        static public T Instance
        {
            get
            {
                if(singletonBoss<T>.instance == null)
                {
                    singletonBoss<T>.instance = FindObjectOfType<T>();

                    if(singletonBoss<T>.instance == null)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        singletonBoss<T>.instance = go.AddComponent<T>();
                    }
                }
                if(singletonBoss<T>.instance.isInitialized == false)
                {
                    singletonBoss<T>.instance.OnInitialize();
                }
                GameObject parent = GameObject.Find("Managers"); // optional till next dashh mark

                if(parent == null)
                {
                    parent = new GameObject("Managers");
                    DontDestroyOnLoad(parent);
                }                                                 // here
                if(singletonBoss<T>.instance.StayAlive == true)
                {
                    singletonBoss<T>.instance.gameObject.transform.SetParent(parent.transform);
                }

                return singletonBoss<T>.instance;
            }
        }

        public virtual void  OnInitialize()
        {
             this.isInitialized = true;   
        }

        public virtual bool StayAlive
        {
           get{return this.stayAlive;}
           set{this.stayAlive = value;} 
        }

        public static bool Exist{ get{ return singletonBoss<T>.Instance != null;}}
    }
}
