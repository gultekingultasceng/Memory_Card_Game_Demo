using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InGameSettingsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gridOptionsTextLeft, gridOptionsTextRight;
    [SerializeField] private GameObject gridOptionsLeftSideIndicator, gridOptionsRightSideIndicator;
    [SerializeField] private Button leftGridOptionsButton, rightGridOptionsButton;
    [SerializeField] private TextMeshProUGUI roundTimeText;
    [SerializeField] private Button roundTimeLeftArrow, roundTimeRightArrow;
    [SerializeField] private TextMeshProUGUI roundCountText;
    [SerializeField] private Button roundCountLeftArrow, roundCountRightArrow;
    [SerializeField] private Button topCornerExitButton;
    [SerializeField] private Button cancelButton, startButton;

    private int minRoundTime, maxRoundTime, minRoundCount, maxRoundCount;
    private int currentRoundTime, currentRoundCount;
    private int activeGridOptionIndex;
    private InGameSettings _inGameSettings;
    public void Initialize(InGameSettings inGameSettings)
    {
        if (_inGameSettings == null)
        {
            _inGameSettings = inGameSettings;
            currentRoundTime = _inGameSettings.RoundTime;
            currentRoundCount = _inGameSettings.RoundCount;
            minRoundCount = _inGameSettings._minRoundCount;
            maxRoundCount = _inGameSettings._maxRoundCount;
            minRoundTime = _inGameSettings._minRoundTime;
            maxRoundTime = _inGameSettings._maxRoundTime;
            gridOptionsTextLeft.text = $"{_inGameSettings.gridRowColumnOptions[0].x}x{_inGameSettings.gridRowColumnOptions[0].y}";
            gridOptionsTextRight.text = $"{_inGameSettings.gridRowColumnOptions[1].x}x{_inGameSettings.gridRowColumnOptions[1].y}";

            leftGridOptionsButton.onClick.AddListener(() => GridOptionsSelected(0));
            rightGridOptionsButton.onClick.AddListener(() => GridOptionsSelected(1));
            roundTimeLeftArrow.onClick.AddListener(() => RoundTimeChange(false));
            roundTimeRightArrow.onClick.AddListener(() => RoundTimeChange(true));
            roundCountLeftArrow.onClick.AddListener(() => RoundCountChange(false));
            roundCountRightArrow.onClick.AddListener(() => RoundCountChange(true));
            topCornerExitButton.onClick.AddListener(() => CancelOrExitSettingsPanel());
            cancelButton.onClick.AddListener(() => CancelOrExitSettingsPanel());
            startButton.onClick.AddListener(() => ApplySettingsAndStartGame());
        }
    }
    private void OnEnable()
    {
        SettingsPanel();
    }
    public void SettingsPanel()
    {
        DisplayRoundTime();
        DisplayRoundCount();
        SetGridOptionsPanel();
    }
    private void DisplayRoundTime() => roundTimeText.text = currentRoundTime.ToString();
    private void DisplayRoundCount() => roundCountText.text = currentRoundCount.ToString();

   
    private void SetGridOptionsPanel()
    {
        activeGridOptionIndex = _inGameSettings.gridRowColumnOptions[0].x == _inGameSettings.GridRowCount
                                 ? 0
                                 : 1;
        SetIndicators();
    }
    private void SetIndicators()
    {
        if (activeGridOptionIndex == 0)
        {
            gridOptionsLeftSideIndicator.SetActive(true);
            gridOptionsTextLeft.color = Color.white;
            gridOptionsRightSideIndicator.SetActive(false);
            gridOptionsTextRight.color = Color.black;
        }
        else
        {
            gridOptionsLeftSideIndicator.SetActive(false);
            gridOptionsTextLeft.color = Color.black;
            gridOptionsRightSideIndicator.SetActive(true);
            gridOptionsTextRight.color = Color.white;
        }
    }
    private void GridOptionsSelected(int index)
    {
        activeGridOptionIndex = index;
        SetIndicators();
    }
    private void RoundTimeChange(bool isIncrease)
    {
        if (isIncrease)
        {
            if (currentRoundTime + 1 > maxRoundTime)
                return;
            currentRoundTime++;
        }
        else
        {
            if (currentRoundTime - 1 < minRoundTime)
                return;
            currentRoundTime--;
        }
        DisplayRoundTime();
    }
    private void RoundCountChange(bool isIncrease)
    {
        if (isIncrease)
        {
            if (currentRoundCount + 1 > maxRoundCount)
                return;
            currentRoundCount++;
        }
        else
        {
            if (currentRoundCount - 1 < minRoundCount)
                return;
            currentRoundCount--;
        }
        DisplayRoundCount();
    }
    private void CancelOrExitSettingsPanel()
    {
        UIManager.Instance.CloseSettingsPanel(false);
    }
    private void ApplySettingsAndStartGame()
    {
        _inGameSettings.SettingsApply(currentRoundTime,currentRoundCount,activeGridOptionIndex);
        UIManager.Instance.CloseSettingsPanel(true);
    }
}
