using Kingmaker.Designers.EventConditionActionSystem.Actions;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PathfinderKingmakerMaster
{
    public class Loader
    {
        public static GameObject inGameObject;
        public static void Load()
        {            
            inGameObject = new GameObject();
            inGameObject.AddComponent<InGameConsole>();
            inGameObject.AddComponent<Banner>();
            inGameObject.AddComponent<ScriptMenu>();
            //inGameObject.AddComponent<KeyTrap>();            
            UnityEngine.Object.DontDestroyOnLoad(inGameObject);
        }

        public static void Unload()
        {            
            UnityEngine.Object.Destroy(inGameObject);
        }
    }
}
