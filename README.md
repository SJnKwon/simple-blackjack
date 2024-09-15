# simple-blackjack

This is a terminal-based Blackjack game implemented in C# using Visual Studio Code. The game simulates a standard Blackjack game where the player competes against the dealer.

## How to Play

1. **Initial Deal**: The player and dealer each receive two cards.
2. **Player's Turn**: The player can choose to either:
    - **Hit**: Draw another card.
    - **Stand**: Keep the current hand and end their turn.
3. **Dealer's Turn**: The dealer will draw cards until their hand totals at least 17.
4. **Win Conditions**:
    - If the player's hand exceeds 21, the player **busts**, and the dealer wins.
    - If the dealer's hand exceeds 21, the dealer **busts**, and the player wins.
    - If neither busts, the hand with the higher total wins. A tie results in a draw.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## How to Run

1. Clone this repository.
2. Navigate to the project directory.
3. Build the project:
    ```bash
    dotnet build
    ```
4. Run the project:
    ```bash
    dotnet run
    ```
Or if you want to play locally
1. Clone this repository.
2. Navigate to the project directory.
3. Run Program.cs


## Example

```bash
Your hand: 9 of Hearts, 5 of Spades (Total: 14)
'hit' or 'stand'?
hit
Your hand: 9 of Hearts, 5 of Spades, 3 of Diamonds (Total: 17)
'hit' or 'stand'?
stand
Dealer hand: 10 of Clubs, 6 of Diamonds (Total: 16)
Dealer hits...
Dealer hand: 10 of Clubs, 6 of Diamonds, 4 of Hearts (Total: 20)
Dealer wins.
