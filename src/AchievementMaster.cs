using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using Kingmaker;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Achievements;
using Steamworks;

namespace PathfinderKingmakerMaster
{
    class AchievementMaster
    {
        public AchievementsManager AchievementManager;
        public List<string> AllPlayerAchievementNames;
        public List<string> AllPlayerAchievementSteamIds;

        public AchievementMaster()
        {
            AchievementManager = Game.Instance.Player.Achievements;
            AllPlayerAchievementNames = new List<string>();
            AllPlayerAchievementSteamIds = new List<string>();

            foreach (AchievementEntity ach in AchievementManager)
            {
                AllPlayerAchievementNames.Add(ach.Data.name);
                AllPlayerAchievementSteamIds.Add(ach.Data.SteamId);
            }
        }

        public bool AddAchievement(string AchievementId)
        {
            //Debug.Log("AddAchievement called");
            AchievementData achievement = ScriptableObject.CreateInstance("AchievementData") as AchievementData;
            AchievementEntity achievementEntity = new AchievementEntity(achievement);
            achievementEntity.Data.hideFlags = HideFlags.None;            
            achievementEntity.Data.Type = AchievementType.ZenArcher;
            achievementEntity.Data.OnlyMainCampaign = true;            
            achievementEntity.Data.name = AchievementId.Substring(4); // removing "ACH_"
            achievementEntity.Data.SteamId = AchievementId;
            achievementEntity.Data.GogId = AchievementId;
            achievementEntity.Manager = AchievementManager;
            achievementEntity.Unlock();           

            AchievementLogicFactory.Create(achievementEntity).Activate();
            AchievementManager.Append(achievementEntity);


            SteamAchievementsManager sam = SteamAchievementsManager.Instance;
            sam.Achievements = AchievementManager;
            SteamUserStats.SetAchievement(achievementEntity.Data.SteamId);
            
            Debug.Log($"{achievementEntity.Data.name} added to profile");            
            return true;
        }
    }
}
