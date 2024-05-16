using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BattleManager : MonoBehaviour
    {
        public static BattleManager Instance;
        public BattleData BattleData;

        [SerializeField] private Button toBattleButton;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            toBattleButton.interactable = BattleData != null;
        }

        public void BattleChosen(BattleButton button)
        {
            BattleData = button.BattleData;
        }
    }
}
