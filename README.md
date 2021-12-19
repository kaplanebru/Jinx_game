# Jinx_game
 
+ A pixelart game where the enemy spreads bad luck as it grows bigger.

Currently working on/

- Enhancing the enemy growth mechanics using circle algorithm.

Completed/

Bresenham's circle algorithm:
- adaptation to C# & Unity

Door:
- slowly opening automatic door
- if the gap between the door gets bigger than the enemy size, enemy leaves the room

Enemy:
- constantly moving on a random path, changing direction depending on screen bounds
- grows periodically in certain amount
- shrinks after accurate attacks coming from the player

Player:
- moves following the mouse pointer
- collects shurikens spawned periodically at random places
- shoots shurikens
