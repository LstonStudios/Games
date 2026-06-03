import os
import random
import sys
import time

# Game Configuration
WIDTH = 15
HEIGHT = 10
EMPTY = "   "
ROBOT = " 🤖 "
BATTERY = " 🔋 "
GLITCH = " 👾 "
WALL = " 🧱 "

class RobotGame:
    def __init__(self):
        self.bot_x = 1
        self.bot_y = 1
        self.score = 0
        self.batteries_collected = 0
        self.goal_batteries = 5
        self.game_over = False
        
        # Generate items
        self.battery_pos = self.get_random_empty_pos()
        self.glitches = [self.get_random_empty_pos() for _ in range(4)]

    def get_random_empty_pos(self):
        while True:
            x = random.randint(1, WIDTH - 2)
            y = random.randint(1, HEIGHT - 2)
            if (x, y) != (self.bot_x, self.bot_y):
                return (x, y)

    def draw_board(self):
        # Clear terminal screen cleanly
        os.system('cls' if os.name == 'nt' else 'clear')
        
        print("=" * 45)
        print(f" 🤖 CODESPACE CYBER-BOT | Batteries: {self.batteries_collected}/{self.goal_batteries}")
        print("=" * 45)

        for y in range(HEIGHT):
            row_str = ""
            for x in range(WIDTH):
                if x == 0 or x == WIDTH - 1 or y == 0 or y == HEIGHT - 1:
                    row_str += WALL
                elif x == self.bot_x and y == self.bot_y:
                    row_str += ROBOT
                elif (x, y) == self.battery_pos:
                    row_str += BATTERY
                elif (x, y) in self.glitches:
                    row_str += GLITCH
                else:
                    row_str += EMPTY
            print(row_str)
            
        print("\n Controls: W (Up) | A (Left) | S (Down) | D (Right)")
        print(" Type command and press ENTER. Press Q to quit.")

    def move_bot(self, move):
        dx, dy = 0, 0
        if move == 'w': dy = -1
        elif move == 's': dy = 1
        elif move == 'a': dx = -1
        elif move == 'd': dx = 1
        elif move == 'q':
            print("\nShutting down robot... Goodbye!")
            sys.exit()
        else:
            return # Ignore invalid inputs

        # Wall collision check
        new_x = self.bot_x + dx
        new_y = self.bot_y + dy
        if 0 < new_x < WIDTH - 1 and 0 < new_y < HEIGHT - 1:
            self.bot_x = new_x
            self.bot_y = new_y

        # Battery check
        if (self.bot_x, self.bot_y) == self.battery_pos:
            self.batteries_collected += 1
            if self.batteries_collected >= self.goal_batteries:
                self.draw_board()
                print("\n🎉 SYSTEM RESTORED! The robot successfully saved the server grid!")
                self.game_over = True
            else:
                self.battery_pos = self.get_random_empty_pos()

        # Glitch check
        if (self.bot_x, self.bot_y) in self.glitches:
            self.draw_board()
            print("\n💥 CRITICAL ERROR! Your robot stepped on a rogue glitch.")
            self.game_over = True

    def run(self):
        while not self.game_over:
            self.draw_board()
            # Compatible with standard cloud terminals
            user_input = input("\nMove Command >> ").lower().strip()
            if user_input:
                self.move_bot(user_input[0])

if __name__ == "__main__":
    game = RobotGame()
    game.run()
