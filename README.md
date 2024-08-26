# Doofus Adventure Game
## Drive Link of the folder (Github does not have all the files)
- **will place link here before deadline

## Overview

Doofus Adventure Game made for HitWicket selection process for the Game Developer Role.
I had some trouble after building so the game only works when we are inside the Unity Game viewer/player
I have not developed countdown timer on the pulpits as i faced some issues there.
I have developed this project during my exams so the commits are not hourly.

## Features

- **Level 1: Dynamic Pulpit Spawning**: Platforms spawn and disappear at random intervals.
- **Level 2: Score Management**: Score increases with each pulpit Doofus reaches.
- **Level 3: Game Over Screen and Restart Functionality**: Displays game-over text and a restart button when Doofus falls below a certain threshold.

## Project Structure

- **Assets/**
  - Contains all assets including scripts, prefabs, and scenes.
- **Scripts/**
  - **PlayerMovement.cs**: Controls Doofus's movement and checks for pulpit transitions.
  - **PulpitManager.cs**: Manages pulpit spawning and lifecycle.
  - **ScoreManager.cs**: Handles score updates and display.
  - **GameOverManager.cs**: Manages the game-over screen and restart functionality.
  - **StartScreenManager.cs**: Manages the start screen functionality.
- **Scenes/**
  - **StartScene.unity**: The starting scene with the game start button.
  - **GameScene.unity**: The main gameplay scene where Doofus navigates the pulpit platforms.

## Debug Logging

I have Debug logging employed throughout the game to track the behavior of key game elements. This includes logging for:

- **Doofus Position and Velocity**:
  - Added to monitor Doofus's movement and ensure it's behaving as expected during gameplay.
  - Helps diagnose issues like unintended movements or physics problems that could cause Doofus to fly away.

- **Score Updates**:
  - Logs score updates to verify correct functionality and detect any discrepancies in the scoring system.

- **Game State Changes**:
  - Logs transitions between game states to ensure smooth gameplay and correct handling of game-over conditions.

## Contact

For any queries, please contact [Vinayak Sivaprasad](mailto:vinayaksivaprasad.si@gmail.com).
