using UnityEngine;

namespace PathfinderKingmakerMaster
{
    class KeyTrap : MonoBehaviour
    {
        void Start()
        {            
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.End))
            {   
                Destroy(GetComponent<ScriptMenu>());
            }

            if (Input.GetKeyDown(KeyCode.Home))
            {                
                gameObject.AddComponent<ScriptMenu>();
            }
        }

        void OnGUI()
        {            
        }
    }
}
