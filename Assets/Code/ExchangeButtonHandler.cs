using UnityEngine;

namespace Code
{
    public class ExchangeButtonHandler : MonoBehaviour
    {
        public AnimalType fromAnimal;
        public int fromCount = 1;
        public AnimalType toAnimal;
        public int toCount = 1;

        public void OnExchangeClicked()
        {
            Player player = GameMaster.Instance.GetCurrentPlayer();
            bool success = SmartTradeManager.TryExecuteExchange(player, fromAnimal, fromCount, toAnimal, toCount);

            if (!success)
                Debug.LogWarning($"Wymiana nie powiodła się: {fromCount} {fromAnimal} -> {toCount} {toAnimal}");
            else
            {
                Debug.Log($"Wymiana OK: {fromCount} {fromAnimal} -> {toCount} {toAnimal}");
                UIManager.Instance.UpdateAnimalCounts(player.Herd.GetAnimalCounts());
                GameMaster.Instance.ConfirmTradeAndRoll();
            }
        }
    }
}