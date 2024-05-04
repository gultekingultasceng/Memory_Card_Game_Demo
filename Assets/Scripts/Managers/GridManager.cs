using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using MCG.Core.Utils;
using MCG.Core.Singleton;
using MCG.Core.Constants;
using MCG.Core.Base;

namespace MCG.Core.Managers
{
    public class GridManager : Singleton<GridManager>
    {
        private int rowCount;
        private int columnCount;
        public Vector2Int RowAndColumn => new Vector2Int(rowCount, columnCount);
        public float[] GetWorldPositionCenterOfGrid => new float[2] {
        Mathf.CeilToInt(rowCount * .5f) * GridConstants.DistanceBtwSlots - GridConstants.DistanceBtwSlots * .5f + 1,
        Mathf.CeilToInt(columnCount * .5f) * GridConstants.DistanceBtwSlots - GridConstants.DistanceBtwSlots * .5f + 1,
    };
        [SerializeField] private List<SlotInfo> slotInfos;
        private void GenerateGridAndGetCardsFromDeck()
        {
            DeckManager.Instance.Initialize(rowCount, columnCount);
            slotInfos = new List<SlotInfo>();
            var deck = DeckManager.Instance.GetDeck();
            int deckIndex = 0;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    CardScript card = deck[deckIndex];
                    card.transform.position = VectorUtils.GetWorldPositionFromCoordinates(new Vector2Int(i, j));
                    slotInfos.Add(new SlotInfo(new Vector2Int(i, j), card));
                    deckIndex++;
                }
            }
        }
        public void ReArrangeTheGridForNewPlay()
        {
            DeckManager.Instance.PutCardsBackToDeck();
            GenerateGridAndGetCardsFromDeck();
        }
        public void Initialize(int rowCount, int columnCount)
        {
            this.rowCount = rowCount;
            this.columnCount = columnCount;
            GenerateGridAndGetCardsFromDeck();
        }
        [System.Serializable]
        public class SlotInfo
        {
            public Vector2Int slotCoordinate;
            public CardScript holdedCard;
            public SlotInfo(Vector2Int slotCoordinate, CardScript holdedCard)
            {
                this.slotCoordinate = slotCoordinate;
                this.holdedCard = holdedCard;
            }
        }
        public CardScript GetCardFromCoordinate(Vector2Int coordinate)
        {
            return slotInfos
                           .Where(slot => slot.slotCoordinate == coordinate)
                           .Select(slot => slot.holdedCard)
                           .FirstOrDefault();
        }


    }
}