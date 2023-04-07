using CodeBase.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI
{
    public class SettingButtons : MonoBehaviour
    {
        public Button restartButton;
        public Button exitButton;
        public TextMeshProUGUI kills;

        [Inject] private GameControl  m_GameControl;
        [Inject] private KillsCounter m_KillsCounter;

        private void Start() => 
            UpdateTextKills(m_KillsCounter.countKills);

        private void UpdateTextKills(int count) => 
            kills.text = "Kills: " + count;

        private void OnEnable()
        {
            restartButton.onClick.AddListener(m_GameControl.Respawn);
            exitButton.onClick.AddListener(m_GameControl.LeaveGame);
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(m_GameControl.Respawn);
            exitButton.onClick.RemoveListener(m_GameControl.LeaveGame);
        }
    }
}