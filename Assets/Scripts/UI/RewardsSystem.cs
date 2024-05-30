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

            BattleManager.Instance.BattleData = null;

            xpText.text = _xpReward.ToString();
            goldText.text = _goldReward.ToString();
        }

        public void SaveRewards()
        {
            PlayerPrefs.SetInt(NameHelper.XpPrefs, _xpReward);
            PlayerPrefs.SetInt(NameHelper.GoldPrefs, _goldReward);
        }
    }
}
