using Kingmaker.Visual.Trails;
using SharpNav;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace PathfinderKingmakerMaster
{
    class ScriptMenu : MonoBehaviour
    {
        KeyCode toggleKey = KeyCode.Home;
        
        string windowTitle = "Script_Menu";
        string requestedAchievementName;
        
        int margin = 20;

        float scaleFactor = 1f;        
        float menuWidth = 120;
        float menuHeight = 50;

        bool isVisible;
        
        Rect windowRect;
        
        AchievementMaster AchievementMaster;        

        void Start()
        {
            isVisible = true;
            requestedAchievementName = "";
            AchievementMaster = new AchievementMaster();
            windowRect = new Rect(Screen.width - ((int)menuWidth + margin), margin, menuWidth, menuHeight);
        }

        void OnGUI()
        {
            if (!isVisible)
                return;

            Rect newWindowRect = GUILayout.Window(55545, windowRect, DrawWindow, windowTitle);
        }

        void Update()
        {
            if (Input.GetKeyDown(toggleKey))
                isVisible = !isVisible;
        }

        void DrawWindow(int windowID)
        {            
            requestedAchievementName = GUILayout.TextField(requestedAchievementName, 50);
            if (GUILayout.Button("List Achievements"))
            {
                foreach(string s in AchievementMaster.AllPlayerAchievementSteamIds)
                {
                    Debug.Log(s);
                }
            }

            if(GUILayout.Button("Add Achievement"))
            {
                if (AchievementMaster.AllPlayerAchievementSteamIds.Contains(requestedAchievementName))
                {
                    AchievementMaster.AddAchievement(requestedAchievementName);
                    Debug.Log($"Added {requestedAchievementName}");
                }
                else
                {
                    Debug.Log($"{requestedAchievementName} Not in Achievement List");
                }
            }
        }
    }
}
