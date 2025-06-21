# 🐰 Superfarmer – Turn-based Animal Breeding and Trading Game 🎲

A digital version of the classic Polish board game **Superfarmer**, developed in Unity. Players collect, breed, and trade animals to build the most complete farm while protecting it from predators.

---

## 🎮 Game Features

- ✅ Turn-based gameplay for 2–4 players  
- 🎲 Two dice with various animals  
- 🐑 Breeding only for animals **rolled on the dice** and **owned by the player**  
- 🦊 Predator mechanics (fox and wolf) according to game rules  
- ♻️ Trading system based on rabbit exchange rates  
- 🐕 Guard dogs (small and big) protect your animals  
- 🔁 Only one trade allowed per turn  
- 🏆 Victory condition: owning one of each basic animal

---

## 🖥️ Technologies

- Unity 2024+  
- C#

---

## 🔄 Turn Flow

1. **Start of the turn**  
   - The player chooses whether to make a trade.

2. **If the player chooses to trade**  
   - A trading interface (`WymianaGUI`) appears where the player:  
     - Selects the animal to give  
     - Selects the animal to receive  
     - Confirms the trade with one button  
   - Dice roll automatically after confirming

3. **If the player skips trading**  
   - The player manually rolls the dice with a button

4. **Processing dice results**  
   - Fox or wolf may attack based on the result  
   - Only animals **rolled** and **owned** can breed  
   - New animals are added to the player’s herd  
   - UI updates animal counts and dice visuals

5. **End of the turn**  
   - Victory condition is checked  
   - If not met, the turn passes to the next player

---

## 🔁 Exchange Table

| Animal         | Value             |
|----------------|------------------|
| 1 Sheep        | 6 rabbits         |
| 1 Pig          | 2 sheep           |
| 1 Cow          | 3 pigs            |
| 1 Horse        | 2 cows            |
| 1 Small dog    | 1 sheep           |
| 1 Big dog      | 1 cow             |

---

## 🧱 Project Structure

- `GameMaster.cs` – Controls turn flow  
- `Player.cs` – Represents the player and their herd  
- `Herd.cs` – Stores and manages animal quantities  
- `BreedingLogic.cs` – Handles animal reproduction  
- `PredatorLogic.cs` – Handles fox and wolf logic  
- `AnimalLimitManager.cs` – Limits animal quantities  
- `SmartTradeManager.cs` – Manages the trading logic  
- `ExchangeButtonHandler.cs` – UI handling for trades  
- `UIManager.cs` – Updates the interface

---

## 🏆 Victory Condition

A player wins when they own at least **one of each** of the following animals:

- 🐰 Rabbit  
- 🐑 Sheep  
- 🐖 Pig  
- 🐄 Cow  
- 🐎 Horse

---

## ▶️ How to Launch the Game

1. Clone the repository  
2. Open the project in Unity  
3. Load the main game scene  
4. Enter player names and start playing!

---

## 📸 Screenshots

### Start of Player's Turn

Player can choose to trade or skip:

<img width="1440" alt="Turn Start" src="https://github.com/user-attachments/assets/0df6f4f5-0925-4481-9cd8-041e70a32ddc" />

---

### Dice Roll After Skipping Trade

After skipping, the dice can be rolled:

<img width="1440" alt="Dice Roll" src="https://github.com/user-attachments/assets/3f06b383-a294-4597-9831-b90708c31e0b" />

---

### Breeding After Dice Roll

New animals are added based on herd and dice result:

<img width="1440" alt="Breeding Result" src="https://github.com/user-attachments/assets/cef3ca7d-bc47-42d8-9fc2-530fa4ededae" />

---

### Trading Mechanism

Panel for trading one animal for another. Only **one trade per turn**:

<img width="1440" alt="Trade Panel" src="https://github.com/user-attachments/assets/598514f1-a89e-4e30-9e91-92e421dcbf16" />

---

### Victory Screen 🏆

A player wins by owning: 🐇 rabbit, 🐑 sheep, 🐖 pig, 🐄 cow, 🐎 horse:

<img width="1440" alt="Victory Screen" src="https://github.com/user-attachments/assets/6b15014a-15b2-46fe-8985-e24f58eb23e3" />
