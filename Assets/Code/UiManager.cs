using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    

    public class UIManager : MonoBehaviour
    {
        [System.Serializable]
        public struct AnimalSpriteEntry
        {
            public AnimalType animalType;
            public Sprite sprite;
        }
        
        [Header("Panel końca gry")]
        public GameObject endGamePanel;      // Panel do wyświetlania komunikatu
        public TMP_Text endGameText;         // Tekst w panelu

        public static UIManager Instance { get; private set; }

        [Header("Podstawowe UI")]
        public TMP_Text currentPlayerText;
        public TMP_Text diceResultText;
        public Button actionButton;      // ten sam przycisk do rzutu i końca tury
        public Button tradeButton;

        [Header("Obrazy wylosowanych zwierząt")]
        public Image diceImage1;
        public Image diceImage2;
        public Image diceImage1Shadow;
        public Image diceImage2Shadow;

        [Header("Sprite'y zwierząt")]
        public List<AnimalSpriteEntry> animalSprites;

        [Header("Liczby zwierząt")]
        public TMP_Text rabbitText;
        public TMP_Text sheepText;
        public TMP_Text pigText;
        public TMP_Text cowText;
        public TMP_Text horseText;
        public TMP_Text smallDogText;
        public TMP_Text bigDogText;

        [Header("Liczby zwierząt")]
        public TMP_Text rabbitTextTrade;
        public TMP_Text sheepTextTrade;
        public TMP_Text pigTextTrade;
        public TMP_Text cowTextTrade;
        public TMP_Text horseTextTrade;
        public TMP_Text smallDogTextTrade;
        public TMP_Text bigDogTextTrade;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }

            actionButton.onClick.AddListener(OnActionButtonClicked);
            tradeButton.onClick.AddListener(OnTradeButtonClicked);
        }

        private void OnTradeButtonClicked()
        {
            GameMaster.Instance.OnTradeClicked();
        }

        private void OnActionButtonClicked()
        {
            GameMaster.Instance.OnActionButtonPressed();
        }

        public void UpdateCurrentPlayer(string playerName)
        {
            currentPlayerText.text = $"Tura gracza: {playerName}";
        }

        public void UpdateAnimalCounts(Dictionary<AnimalType, int> animalCounts)
        {
            rabbitText.text = GetCount(animalCounts, AnimalType.Rabbit);
            sheepText.text = GetCount(animalCounts, AnimalType.Sheep);
            pigText.text = GetCount(animalCounts, AnimalType.Pig);
            cowText.text = GetCount(animalCounts, AnimalType.Cow);
            horseText.text = GetCount(animalCounts, AnimalType.Horse);
            smallDogText.text = GetCount(animalCounts, AnimalType.SmallDog);
            bigDogText.text = GetCount(animalCounts, AnimalType.BigDog);
            rabbitTextTrade.text = GetCount(animalCounts, AnimalType.Rabbit);
            sheepTextTrade.text = GetCount(animalCounts, AnimalType.Sheep);
            pigTextTrade.text = GetCount(animalCounts, AnimalType.Pig);
            cowTextTrade.text = GetCount(animalCounts, AnimalType.Cow);
            horseTextTrade.text = GetCount(animalCounts, AnimalType.Horse);
            smallDogTextTrade.text = GetCount(animalCounts, AnimalType.SmallDog);
            bigDogTextTrade.text = GetCount(animalCounts, AnimalType.BigDog);
        }

        private string GetCount(Dictionary<AnimalType, int> dict, AnimalType type)
        {
            return dict.TryGetValue(type, out int count) ? count.ToString() : "0";
        }

        public void ShowTradeChoiceButtons()
        {
            tradeButton.gameObject.SetActive(true);
            actionButton.gameObject.SetActive(true);
            actionButton.GetComponentInChildren<TMP_Text>().text = "Brak Wymiany";
        }

        public void ShowRollDiceButton()
        {
            tradeButton.gameObject.SetActive(false);
            actionButton.GetComponentInChildren<TMP_Text>().text = "Rzut kostką";
        }

        public void ShowEndTurnButton()
        {
            tradeButton.gameObject.SetActive(false);
            actionButton.GetComponentInChildren<TMP_Text>().text = "Koniec tury";
        }

        public void ShowDiceResults(AnimalType result1, AnimalType result2)
        {
            diceImage1.sprite = GetSpriteForAnimal(result1);
            diceImage2.sprite = GetSpriteForAnimal(result2);
            diceImage1.gameObject.SetActive(true);
            diceImage2.gameObject.SetActive(true);
            diceImage1Shadow.gameObject.SetActive(true);
            diceImage2Shadow.gameObject.SetActive(true);
        }
        
        public void HideDiceResults()
        {
            diceImage1.gameObject.SetActive(false);
            diceImage2.gameObject.SetActive(false);
            diceImage1Shadow.gameObject.SetActive(false);
            diceImage2Shadow.gameObject.SetActive(false);
        }

        private Sprite GetSpriteForAnimal(AnimalType animal)
        {
            foreach (var entry in animalSprites)
            {
                if (entry.animalType == animal)
                    return entry.sprite;
            }

            Debug.LogWarning("Brak sprite'a dla: " + animal);
            return null;
        }
        
        public void ShowEndGameMessage(string message)
        {
            if (endGamePanel == null || endGameText == null)
            {
                Debug.LogWarning("End game UI elements are not assigned!");
                return;
            }

            endGameText.text = message;
            endGamePanel.SetActive(true);
        }

    }
}
