using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MCG.Core.UI
{
    [System.Serializable]
    public class PlayerPanel
    {
        public TextMeshProUGUI playerNameText;
        public TextMeshProUGUI playerPointText;
        public TextMeshProUGUI playerScoreText;
        public Image playerAvatarImage;
        public CanvasGroup playerCanvasGroup;
    }
}