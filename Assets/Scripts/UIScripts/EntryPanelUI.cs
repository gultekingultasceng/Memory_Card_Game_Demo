using MCG.Core.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MCG.Core.UI
{
    public class EntryPanelUI : MonoBehaviour
    {
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button startButton;

        public void Initialize()
        {
            settingsButton.onClick.AddListener(() => UIManager.Instance.OpenSettingsPanel());
            startButton.onClick.AddListener(() => UIManager.Instance.CloseAllPanelsBeforeGameStart());
        }

    }
}