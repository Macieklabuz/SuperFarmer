# 🐰 Superfarmer – Gra Turowa w Unity 🎲

Cyfrowa wersja gry planszowej **Superfarmer**, stworzona w Unity z zachowaniem oryginalnych zasad: rozmnażanie, wymiana zwierząt, zagrożenia od drapieżników, oraz rozgrywka turowa dla dwóch graczy lub większej ilości graczy.

## 🎮 Funkcje

- ✅ Turowa rozgrywka dla 2-4 graczy
- 🎲 Rzucanie dwoma kostkami – specjalne ikony zwierząt
- 🐑 Rozmnażanie tylko wylosowanych zwierząt, które gracz już posiada
- 🦊 Wilk i lis – drapieżniki atakujące gracza zgodnie z zasadami
- ♻️ Wymiana zwierząt według tabeli kursów (każdy typ przeliczany na króliki)
- 🐕 Psy stróżujące – mały i duży pies chronią stado
- 🧠 Tylko jedna wymiana możliwa na turę
- ✅ Zakończenie gry – wygrana gracza, który zbierze: królik, owca, świnia, krowa, koń

 ## 🖥️ Technologie

- Unity
- C#


## 🔁 Tabela Wymian (kursy przeliczeniowe)

- 1 owca = 6 królików
- 1 świnia = 2 owce
- 1 krowa = 3 świnie
- 1 koń = 2 krowy
- 1 mały pies = 1 owca
- 1 duży pies = 1 krowa

## 🧱 Struktura projektu

- `GameMaster.cs` – kontroluje przebieg tury i aktualnego gracza
- `Player.cs` – reprezentuje gracza i jego stado
- `Herd.cs` – operacje na zwierzętach (dodawanie, usuwanie, sprawdzanie liczby)
- `BreedingLogic.cs` – obsługuje rozmnażanie po rzucie kostkami
- `PredatorLogic.cs` – logika ataku lisa i wilka
- `AnimalLimitManager.cs` – zarządza globalnym limitem zwierząt
- `SmartTradeManager.cs` – zarządza wymianą zwierząt i ich przeliczeniem
- `ExchangeButtonHandler.cs` – pozwala przypisać wymianę do przycisku w UI
- `UIManager.cs` – aktualizuje interfejs użytkownika

## 📋 Zasady zwycięstwa

Gracz wygrywa grę, jeśli jego stado zawiera **co najmniej po jednym** z następujących zwierząt:

- 🐰 Królik
- 🐑 Owca
- 🐖 Świnia
- 🐄 Krowa
- 🐎 Koń

## 📜 Prezentacja

