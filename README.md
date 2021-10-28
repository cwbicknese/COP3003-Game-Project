# COP3003-Game-Project
This is a game I am making in Unity using C#. Source code is found in Assets/Scripts.

With this game, I am going for something similar to the City Trial mode of the Nintendo Gamecube game Kirby Air Ride. It is a game about moving around and collecting items that increase your stats to increase your movement capabilities.

Controls:
In this game, the player accelerates forward automatically, but they can stop by holding 'space'. While the player is stopped, they will charge up their boost and will get an extra burst of speed when 'space' is released. The player can turn left and right with the arrow keys. The player can also jump by pressing the up key.

At the start of the game, stat boosters and enemies are randomly generated via the startScript file. The player can collide with the stat boosters to increase their stats (blue is speed, green is turn, purple is boost). The "enemies" are just boxes that can be broken by colliding with them a few times. When they are broken, they will drop some stat boosters selected at random.

There are 2 different kinds of enemies defined in the classes Enemy1 and Enemy2. They are both subclasses of EnemyScript.
  1. Enemy1 is a box that changes color between blue and red at set intervals. When it is blue, the player can safely collide with the enemy to deal damage. When it is red, the        player takes damage instead.
  2. Enemy2 can always be collided with safely, but it will jump into the air at set intervals. It uses the same jump function that the player uses, except it takes a parameter to      make it jump higher.

Known issues: 
  1. The player doesn't always bounce off enemies like they are supposed to. Sometimes it results in a more jagged collision.
  2. Sometimes enemies drop more stat boosters than they are supposed to.
  3. Sometimes the player will clip through the walls/ground. This seems to happen more at high speeds.

The visuals can be improved by downloading assets from the asset store. I wanted to focus mostly on simply getting the code to work since I am new to C#, so the different objects in the scene are just cubes and capsules for now.

Currently the game feels more like a tech demo than an actual game with an objective. It was helpful to gain a feel for using C# and Unity, but now that I am feeling a little more comfortable I am thinking about starting from scratch and doing a different game project instead.

![COP3003_game_screenshot1](https://user-images.githubusercontent.com/42978071/139347907-3435cd23-3049-4e79-9602-b9d6ed4226e6.PNG)
