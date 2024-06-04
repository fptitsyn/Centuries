using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExperienceSystem : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private Image xpBar;
    
        private int _xp;
        private int _level = 1;
        private int _xpToLevelUp;
        private int _gold;
    
        private void Start()
        {
            if (PlayerPrefs.HasKey(NameHelper.XpPrefs))
            {
                _xp = PlayerPrefs.GetInt(NameHelper.XpPrefs);
            }

            if (PlayerPrefs.HasKey(NameHelper.LevelPrefs))
            {
                _level = PlayerPrefs.GetInt(NameHelper.LevelPrefs);
            }

            if (PlayerPrefs.HasKey(NameHelper.GoldPrefs))
            {
                _gold = PlayerPrefs.GetInt(NameHelper.GoldPrefs);
            }

            goldText.text = _gold.ToString();
        }

        private void Update()
        {
            levelText.text = _level.ToString();
            _xpToLevelUp = 1000 + _level * 100;

            if (_xp >= _xpToLevelUp)
            {
                _level++;
                PlayerPrefs.SetInt(NameHelper.LevelPrefs, _level);
                _xp -= _xpToLevelUp;
                PlayerPrefs.SetInt(NameHelper.XpPrefs, _xp);
            }
            
            xpBar.fillAmount = (float) _xp / _xpToLevelUp;
        }
    }
}
