# Bullet_Hell
***
A infinite vertical scrolling bullet hell game made in Unity using C#, Scriptable objects to store data and a Pathing system built using Unity's waypoint system.

# Project Structure
***
This repository consists of four folders:-

1. [Assets](Assets)
2. [Final_Game_Builds](Final_Game_Builds)
3. [Packages](Packages)
4. [Project Settings](ProjectSettings)

Out which the [Assets](Assets) and [Final_Game_Builds](Final_Game_Builds) are the only files to be concerned with if a user wants to understand the inner workings of the game or play the final build, respectively.

## Assets
This consists of the all the entities used to make the game. These entities (assets) can be categorized as:-
1. [Animations](Assets/Animations)
2. [Audio](Assets/Audio)
3. [Backgrounds](Assets/Backgrounds)
4. [Fonts](Assets/Fonts)
5. [Materials](Assets/Material)
6. [Paths](Assets/Paths)
7. [Prefabs](Assets/Prefabs)
8. [Scenes](Assets/Scenes)
9. [Scripts](Assets/Scripts)
10. [Sprites](Assets/Sprites) 
11. [VFX](Assets/VFX)
12. [Waves](Assets/Waves)

## Builds
The [Final_Game_Builds](Final_Game_Builds) folder consists of two final builds of the game. These builds are:-

1. A standalone PC build ---->[PC](Final_Game_Builds/Bullet_Hell_PC)
2. A WebGL build         ---->[WebGL](Final_Game_Builds/Bullet_Hell_Web)

# Running the Game
***
To run the game using the PC build :-

- Download the Repository.
- Open the [Final_Game_Builds](Final_Game_Builds) folder.
- Open the [Bullet_Hell_PC](Final_Game_Builds/Bullet_Hell_PC) folder.
- Double click the `Bullet_Hell.exe` executable to run the game.

To run the game using the WebGL build :-

- Download the Repository.
- Open the [Final_Game_Builds](Final_Game_Builds) folder.
- Open the [Bullet_Hell_Web](Final_Game_Builds/Bullet_Hell_Web) folder.
- Right Click the `index.html` and chose `open with` **Microsoft Edge** or **Mozilla Firefox** (*Only these two browsers can run WEBGL builds without further configurations*)

# Instructions and Controls
***
Destroy waves of enemies while trying to maneuver the demon slayer to avoid incoming projectiles of the enemies.

Controls:-
- Use the `W\A\S\D ` keys or `UP\LEFT\DOWN\RIGHT` arrow keys to move the player within the game.
- Use `Left Mouse Click` to select UI options (*Start Menu, Game Over Screen and Pause Menu*)
- Use `Space` to shoot.
- Use `Escape` to toggle the pause Menu
- Use `M` to toggle the volume level (*100%, 75%, 50%, 25%*)

# Further Information
For detailed design specifications please refer to the [Wiki](https://github.com/HishamJaffar98/Block-Breaker/wiki/Bullet-Hell-Design) of this respository

