using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI
{
    public class ChooseBattle : MonoBehaviour
    {
        [SerializeField] private List<BattleButton> buttons;
        private int _enemyAmount;
        private int _goldReward;
        private int _xpReward;
        private int _level = 1;
        
        private void Start()
        {
            if (PlayerPrefs.HasKey(NameHelper.LevelPrefs))
            {
                _level = PlayerPrefs.GetInt(NameHelper.LevelPrefs);
            }
            
            foreach (BattleButton button in buttons)
            {
                _enemyAmount = Random.Range(Math.Max(_level - 2, 1), _level + 3);
                _goldReward = Random.Range(100, 150) + _enemyAmount * 100 + _level * 10;
                _xpReward = Random.Range(300, 450) + _enemyAmount * 100 + _level * 10;
                
                button.textField.text = $"Количество противников: {_enemyAmount}\n" +
                                 $"Золото за бой: {_goldReward}\nОпыт за бой: {_xpReward}";

                button.BattleData = new BattleData(_enemyAmount, _goldReward, _xpReward);
            }
        }
    }
}
