# Jinx_game
 
A pixelart game where the enemy spreads bad luck as it grows bigger.

Completed so far:

Procedural generation of a circle made of pixels:

- Every second there is an increase in the pixel amount composing the circle, which would make the circle grow bigger without resolution loss.

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
