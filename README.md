# 🐰 Superfarmer – Turowa gra o hodowli i wymianie zwierząt 🎲

To cyfrowa wersja klasycznej polskiej gry planszowej **Superfarmer**, stworzona w Unity. Gracze zbierają, rozmnażają i wymieniają zwierzęta, aby stworzyć najpełniejsze gospodarstwo, chroniąc się przy tym przed drapieżnikami.

---

## 🎮 Funkcje gry

- ✅ Rozgrywka turowa dla 2-4 graczy
- 🎲 Dwie kostki z różnymi zwierzętami
- 🐑 Rozmnażanie tylko dla zwierząt **wyrzuconych na kostkach** i **posiadanych przez gracza**
- 🦊 Obsługa drapieżników (lis i wilk) zgodnie z zasadami
- ♻️ System wymian oparty na przeliczniku królików
- 🐕 Psy stróżujące (mały i duży) chronią zwierzęta
- 🔁 Tylko jedna wymiana możliwa na turę
- 🏆 Warunek zwycięstwa: posiadanie po jednej sztuce każdego podstawowego zwierzęcia

---

## 🖥️ Technologie

- Unity 2024+
- C#

---

## 🔄 Przebieg tury

1. **Początek tury:**
   - Gracz wybiera, czy chce przeprowadzić wymianę.

2. **Jeśli gracz wybiera wymianę:**
   - Pojawia się interfejs wymiany (`WymianaGUI`), w którym gracz:
     - Wybiera zwierzę do wymiany
     - Wybiera zwierzę, na które chce wymienić
     - Potwierdza wymianę jednym przyciskiem
   - Po zatwierdzeniu **kostki rzucają się automatycznie**

3. **Jeśli gracz rezygnuje z wymiany:**
   - Gracz klika przycisk, który **ręcznie wykonuje rzut kostkami**

4. **Obsługa wyników kostek:**
   - Jeżeli wypadnie lis lub wilk, drapieżniki atakują zgodnie z zasadami
   - Tylko zwierzęta **wyrzucone na kostkach** i **posiadane** mogą się rozmnożyć
   - Zwierzęta są dodawane do stada gracza
   - UI aktualizuje liczby zwierząt oraz wyniki kostek

5. **Zakończenie tury:**
   - Sprawdzany jest warunek zwycięstwa
   - Jeśli nie został spełniony, tura przechodzi na kolejnego gracza

---

## 🔁 Tabela wymian

| Zwierzę        | Wartość                |
|----------------|------------------------|
| 1 Owca         | 6 królików             |
| 1 Świnia       | 2 owce                 |
| 1 Krowa        | 3 świnie               |
| 1 Koń          | 2 krowy                |
| 1 Mały pies    | 1 owca                 |
| 1 Duży pies    | 1 krowa                |

---

## 🧱 Struktura projektu

- `GameMaster.cs` – Zarządza przebiegiem tury
- `Player.cs` – Reprezentuje gracza i jego stado
- `Herd.cs` – Przechowuje i modyfikuje ilości zwierząt
- `BreedingLogic.cs` – Logika rozmnażania
- `PredatorLogic.cs` – Obsługa lisa i wilka
- `AnimalLimitManager.cs` – Ograniczenia maksymalnych ilości zwierząt
- `SmartTradeManager.cs` – Obsługuje system wymian
- `ExchangeButtonHandler.cs` – Obsługa przycisków wymiany w UI
- `UIManager.cs` – Aktualizacja elementów interfejsu

---

## 🏆 Warunek zwycięstwa

Gracz wygrywa, gdy posiada co najmniej po **1 sztuce każdego z następujących zwierząt**:

- 🐰 Królik
- 🐑 Owca
- 🐖 Świnia
- 🐄 Krowa
- 🐎 Koń

---

## 📸 Zrzuty ekranu

### Ekran początkowy tury gracza

Na przedstawionym zrzucie ekranu widać początek tury gracza. Gracz ma do wyboru wykonanie wymiany lub rezygnację z niej:
<img width="1440" alt="Zrzut ekranu 2025-05-23 o 00 26 04" src="https://github.com/user-attachments/assets/0df6f4f5-0925-4481-9cd8-041e70a32ddc" />

### Rzut kostką po rezygnacji z wymiany

Na tym zrzucie ekranu pokazane jest, co widzi gracz po wybraniu opcji braku wymiany. Gracz ma teraz możliwość wykonania rzutu kostką:
<img width="1440" alt="Zrzut ekranu 2025-05-23 o 00 32 42" src="https://github.com/user-attachments/assets/3f06b383-a294-4597-9831-b90708c31e0b" />

### Rozmnażanie po rzucie kostką

Po kliknięciu przycisku rzut kostką, gra automatycznie zlicza zwierzęta w stadzie gracza oraz uwzględnia wynik z kostek. Zgodnie z zasadami gry, zwierzęta mogą się rozmnożyć – nowe osobniki zostają dodane do stada gracza:
<img width="1440" alt="Zrzut ekranu 2025-05-23 o 00 27 44" src="https://github.com/user-attachments/assets/cef3ca7d-bc47-42d8-9fc2-530fa4ededae" />

### Mechanizm wymiany

Po wybraniu opcji **Wymiana**, pojawia się specjalny panel. Po lewej stronie znajdują się zwierzęta, które gracz może oddać, a po prawej – zwierzęta dostępne do otrzymania. Można przeprowadzić tylko **jedną wymianę na turę**.  
Jeśli gracz nie może przeprowadzić żadnej wymiany, może kliknąć przycisk **Anuluj**, by zrezygnować i wrócić do tury:
<img width="1440" alt="Zrzut ekranu 2025-05-23 o 00 28 42" src="https://github.com/user-attachments/assets/65869d46-6dee-44bd-af26-798fad758530" />

### Ekran zwycięstwa 🏆

Gra kończy się, gdy któryś z graczy posiada **przynajmniej po jednym** z każdego z następujących zwierząt:  
🐇 królik, 🐑 owca, 🐖 świnia, 🐄 krowa, 🐎 koń.  

Po spełnieniu tego warunku wyświetlany jest **ekran zwycięstwa**, informujący o wygranej gracza:
<img width="1440" alt="Zrzut ekranu 2025-05-23 o 00 56 11" src="https://github.com/user-attachments/assets/6b15014a-15b2-46fe-8985-e24f58eb23e3" />

