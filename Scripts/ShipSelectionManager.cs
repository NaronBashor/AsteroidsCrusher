using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelectionManager : MonoBehaviour
{
        [SerializeField] private Image currentShipSprite;

        [SerializeField] private TextMeshProUGUI cannonCountText;
        [SerializeField] private TextMeshProUGUI modelNumberText;
        [SerializeField] private Image speedLevelSprite;
        [SerializeField] private Image fuelLevelSprite;
        [SerializeField] private Image healthLevelSprite;

        public List<Sprite> shipSprites = new List<Sprite>();
        public List<string> modelNumbers = new List<string>();
        public List<Sprite> itemLevelSprites = new List<Sprite>();

        private int index = 0;

        private void Start()
        {
                UpdateShipSelection();
        }

        public void LeftArrow()
        {
                index--;
                if (index < 0)
                {
                        index = shipSprites.Count - 1;
                }
                UpdateShipSelection();
        }

        public void RightArrow()
        {
                index++;
                if (index > shipSprites.Count - 1)
                {
                        index = 0;
                }
                UpdateShipSelection();
        }

        public void UpdateShipSelection()
        {
                currentShipSprite.sprite = shipSprites[index];
                modelNumberText.text = modelNumbers[index];

                switch (index)
                {
                        case 0:
                                {
                                        speedLevelSprite.sprite = itemLevelSprites[0];
                                        fuelLevelSprite.sprite = itemLevelSprites[1];
                                        healthLevelSprite.sprite = itemLevelSprites[0];
                                        break;
                                }
                        case 1:
                                {
                                        speedLevelSprite.sprite = itemLevelSprites[1];
                                        fuelLevelSprite.sprite = itemLevelSprites[1];
                                        healthLevelSprite.sprite = itemLevelSprites[1];
                                        break;
                                }
                        case 2:
                                {
                                        speedLevelSprite.sprite = itemLevelSprites[1];
                                        fuelLevelSprite.sprite = itemLevelSprites[1];
                                        healthLevelSprite.sprite = itemLevelSprites[2];
                                        break;
                                }
                        case 3:
                                {
                                        speedLevelSprite.sprite = itemLevelSprites[2];
                                        fuelLevelSprite.sprite = itemLevelSprites[1];
                                        healthLevelSprite.sprite = itemLevelSprites[2];
                                        break;
                                }
                        case 4:
                                {
                                        speedLevelSprite.sprite = itemLevelSprites[2];
                                        fuelLevelSprite.sprite = itemLevelSprites[2];
                                        healthLevelSprite.sprite = itemLevelSprites[2];
                                        break;
                                }
                        case 5:
                                {
                                        speedLevelSprite.sprite = itemLevelSprites[3];
                                        fuelLevelSprite.sprite = itemLevelSprites[2];
                                        healthLevelSprite.sprite = itemLevelSprites[3];
                                        break;
                                }
                        case 6:
                                {
                                        speedLevelSprite.sprite = itemLevelSprites[3];
                                        fuelLevelSprite.sprite = itemLevelSprites[3];
                                        healthLevelSprite.sprite = itemLevelSprites[3];
                                        break;
                                }
                        case 7:
                                {
                                        speedLevelSprite.sprite = itemLevelSprites[3];
                                        fuelLevelSprite.sprite = itemLevelSprites[4];
                                        healthLevelSprite.sprite = itemLevelSprites[3];
                                        break;
                                }
                        case 8:
                                {
                                        speedLevelSprite.sprite = itemLevelSprites[4];
                                        fuelLevelSprite.sprite = itemLevelSprites[4];
                                        healthLevelSprite.sprite = itemLevelSprites[4];
                                        break;
                                }
                }

                switch (index)
                {
                        case 0:
                        case 3:
                        case 6:
                                {
                                        cannonCountText.text = "1";
                                        break;
                                }
                        case 1:
                        case 4:
                        case 7:
                                {
                                        cannonCountText.text = "2";
                                        break;
                                }
                        case 2:
                        case 5:
                        case 8:
                                {
                                        cannonCountText.text = "3";
                                        break;
                                }
                }
        }
}
