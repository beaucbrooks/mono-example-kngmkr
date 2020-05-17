using UnityEngine;
using Kingmaker;
using Kingmaker.EntitySystem.Entities;

namespace PathfinderKingmakerMaster
{
    class MoreMoney : MonoBehaviour
    {
        Player player;        
        void Start()
        {
            long money = 5000;
            Debug.Log($"My mmmmoney... {money.ToString()}");
            player = Game.Instance.Player;            
            player.GainMoney(money);
        }

        void Update()
        {

        }

        void OnGUI()
        {

        }
    }
}
