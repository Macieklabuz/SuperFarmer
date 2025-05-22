using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class GameMaster : MonoBehaviour
    {
        public static GameMaster Instance { get; private set; }

        private Dice dice1;
        private Dice dice2;
        private int currentPlayerIndex = 0;
        public GameObject WymianaGUI;


        private enum TurnPhase
        {
            TradeOrNot,
            ReadyToRoll,
            DiceRolled,
            GameEnded
        }

        private TurnPhase currentPhase;

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
        }

        private void Start()
        {
            dice1 = Dice.CreateDice1();
            dice2 = Dice.CreateDice2();

            PlayerManager.Instance.InitializePlayersFromInput();

            Debug.Log("Gra rozpoczęta. Zaczyna: " + GetCurrentPlayer().Name);
            StartTurn();
            
            if (WymianaGUI != null)
            {
                WymianaGUI.SetActive(false);
            }
        }

        private void StartTurn()
        {
            currentPhase = TurnPhase.TradeOrNot;

            var player = GetCurrentPlayer();
            Debug.Log("Tura gracza: " + player.Name);

            UIManager.Instance.UpdateCurrentPlayer(player.Name);
            UIManager.Instance.UpdateAnimalCounts(player.Herd.GetAnimalCounts());
            UIManager.Instance.ShowTradeChoiceButtons();
            UIManager.Instance.HideDiceResults(); 
        }

        public Player GetCurrentPlayer()
        {
            return PlayerManager.Instance.Players[currentPlayerIndex];
        }

        public void OnTradeClicked()
        {
            if (currentPhase == TurnPhase.GameEnded)
            {
                Debug.Log("Gra zakończona. Nie można wykonać ruchu.");
                return;
            }
            Debug.Log("Gracz wybrał wymianę.");
    
            if (WymianaGUI != null)
            {
                WymianaGUI.SetActive(true);
            }
            else
            {
                Debug.LogWarning("WymianaGUI nie jest przypisane w inspektorze!");
            }
        }
        
        public void ConfirmTradeAndRoll()
        {
            Debug.Log("Zatwierdzono wymianę. Przechodzę do rzutu kostką.");

            if (currentPhase == TurnPhase.TradeOrNot)
            {
                currentPhase = TurnPhase.ReadyToRoll;
            }

            if (WymianaGUI != null)
            {
                WymianaGUI.SetActive(false); // Ukryj GUI wymiany
            }

            OnActionButtonPressed(); // Wywołuje logikę rzutu
        }

        public void OnActionButtonPressed()
        {
            if (currentPhase == TurnPhase.GameEnded)
            {
                Debug.Log("Gra zakończona. Nie można wykonać ruchu.");
                return;
            }
            if (currentPhase == TurnPhase.TradeOrNot)
            {
                Debug.Log("Gracz nie chce wymieniać.");
                currentPhase = TurnPhase.ReadyToRoll;
                UIManager.Instance.ShowRollDiceButton();
            }
            else if (currentPhase == TurnPhase.ReadyToRoll)
            {
                RollDice();
            }
            else if (currentPhase == TurnPhase.DiceRolled)
            {
                EndTurn();
            }
            else
            {
                Debug.LogWarning("Nieobsługiwany stan tury.");
            }
        }

        private void RollDice()
        {
            Player player = GetCurrentPlayer();
            AnimalType result1 = dice1.Roll();
            AnimalType result2 = dice2.Roll();

            Debug.Log($"Gracz {player.Name} wyrzucił: {result1} i {result2}");
            
            PredatorLogic.HandlePredators(player, result1, result2);
            
            BreedingLogic.ApplyDiceResults(player, result1, result2);

            UIManager.Instance.ShowDiceResults(result1, result2);
            UIManager.Instance.UpdateAnimalCounts(player.Herd.GetAnimalCounts());

            currentPhase = TurnPhase.DiceRolled;
            UIManager.Instance.ShowEndTurnButton();
        }

        private void EndTurn()
        {
            Player currentPlayer = GetCurrentPlayer();
            Debug.Log("Koniec tury gracza: " + currentPlayer.Name);

            var animals = currentPlayer.Herd.GetAnimalCounts(); // Zakładam, że to Dictionary<AnimalType, int>

            // Lista wymaganych zwierząt
            AnimalType[] requiredAnimals = new AnimalType[] 
            {
                AnimalType.Rabbit, 
                AnimalType.Horse, 
                AnimalType.Sheep, 
                AnimalType.Pig, 
                AnimalType.Cow
            };

            bool hasAllAnimals = true;

            foreach (var animal in requiredAnimals)
            {
                if (!animals.ContainsKey(animal) || animals[animal] < 1)
                {
                    hasAllAnimals = false;
                    break;
                }
            }

            if (hasAllAnimals)
            {
                Debug.Log($"Koniec gry, wygrywa {currentPlayer.Name}!");
                UIManager.Instance.ShowEndGameMessage($"Koniec gry, wygrywa {currentPlayer.Name}!");
    
                currentPhase = TurnPhase.GameEnded;
                
                return;
            }

            // Jeśli gracz nie wygrał, przejdź do następnego
            currentPlayerIndex = (currentPlayerIndex + 1) % PlayerManager.Instance.NumberOfPlayers;
            StartTurn();
        }

    }
}
