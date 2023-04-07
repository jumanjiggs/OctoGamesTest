using CodeBase.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI
{
    public class UIFactory : MonoBehaviour
    {
        public GameObject loseUI;
        public TextMeshProUGUI killsUI;
        [Inject] private DiContainer m_DiContainer;
        [Inject] private KillsCounter m_KillsCounter;

        private void OnEnable() => 
            m_KillsCounter.OnZombieDie += UpdateTextKills;

        private void OnDisable() => 
            m_KillsCounter.OnZombieDie -= UpdateTextKills;

        private void UpdateTextKills(int count) => 
            killsUI.text = "Kills: " + count;

        public void InstantiateLoseUi()
        {
            m_DiContainer.InstantiatePrefab(loseUI);
            ActivateCursor();
        }
        
        private void ActivateCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}