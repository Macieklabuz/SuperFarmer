using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance { get; private set; }

        // Lista imion graczy wprowadzona przez UI lub Inspector
        [SerializeField]
        [Tooltip("Lista imion graczy (2-4)")]
        private List<string> playerNamesInput = new List<string>();

        public List<Player> Players { get; private set; } = new List<Player>();
        public int NumberOfPlayers => Players.Count;

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

        /// <summary>
        /// Inicjalizuje graczy na podstawie imion podanych przez użytkownika.
        /// </summary>
        public void InitializePlayersFromInput()
        {
            if (playerNamesInput.Count < 2 || playerNamesInput.Count > 4)
            {
                Debug.LogError("Liczba graczy musi wynosić od 2 do 4.");
                return;
            }

            Players = new List<Player>();

            foreach (string name in playerNamesInput)
            {
                Players.Add(new Player(name));
            }

            Debug.Log($"Zainicjalizowano {Players.Count} graczy.");
        }

        /// <summary>
        /// Pozwala ustawić listę imion dynamicznie (np. z UI).
        /// </summary>
        public void SetPlayerNames(List<string> names)
        {
            playerNamesInput = names;
        }
    }
}