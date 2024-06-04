using TMPro;
using UnityEngine;

namespace UI
{
    public class RewardsSystem : MonoBehaviour
    {
        [SerializeField] private TMP_Text xpText;
        [SerializeField] private TMP_Text goldText;

        private int _xpReward;
        private int _goldReward;
        
        private void Start()
        {
            _xpReward = BattleManager.Instance.BattleData.XpReward;
            _goldReward = BattleManager.Instance.BattleData.GoldReward;

            Destroy(BattleManager.Instance);

            xpText.text = _xpReward.ToString();
            goldText.text = _goldReward.ToString();
        }

        public void SaveRewards()
        {
            int prevXp = 0;
            int prevGold = 0;
            
            if (PlayerPrefs.HasKey(NameHelper.XpPrefs))
            {
                prevXp = PlayerPrefs.GetInt(NameHelper.XpPrefs);
            }
            if (PlayerPrefs.HasKey(NameHelper.GoldPrefs))
            {
                prevGold = PlayerPrefs.GetInt(NameHelper.GoldPrefs);
            }
            
            PlayerPrefs.SetInt(NameHelper.XpPrefs, _xpReward + prevXp);
            PlayerPrefs.SetInt(NameHelper.GoldPrefs, _goldReward + prevGold);
        }
    }
}
