import sys
import random

def play_game():
    print("Welcome to the Number Guessing Game!")
    print("I'm thinking of a number between 1 and 100.")
    print("Type 'quit' at any time to exit the game.")
    
    secret_number = random.randint(1, 100)
    attempts = 0

    while True:
        guess = input("\nEnter your guess: ").strip().lower()

        # Check if the user wants to quit using sys.exit
        if guess == 'quit':
            print("Thanks for playing! Goodbye.")
            sys.exit(0)

        # Ensure the input is an actual number
        try:
            player_guess = int(guess)
        except ValueError:
            print("Please enter a valid number or type 'quit'.")
            continue

        attempts += 1

        # Check the guess
        if player_guess < secret_number:
            print("Too low! Try again.")
        elif player_guess > secret_number:
            print("Too high! Try again.")
        else:
            print(f"Congratulations! You guessed the number in {attempts} attempts.")
            # Ask if the user wants to play again
            play_again = input("Would you like to play again? (yes/no): ").strip().lower()
            if play_again == 'yes':
                play_game()
            else:
                print("Thanks for playing! Goodbye.")
                sys.exit(0)

if __name__ == "__main__":
    play_game()
