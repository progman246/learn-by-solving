# P004 - Simulation

In our multiverse, there are several universes dedicated to tastes. 
In one of them, there's only 4 tastes. Let's call it T4.

T4 is a 2D world with W width and H height.
It has 4 different living creatures. 

- Salty
- Sweet
- Sour
- Spicy

Initially, each creature is positioned in a X, Y coordinate. For movement, Salty can move to right, Sweet moves in up direction,
Sour moves in bottom and Spicy moves in left direction. 
If a creature touches the edge its moving direction will swap (left to right, up to down and vice versa)

When two different creatures collide with each other their moving direction will rotate by 90 degree clockwise. 
Upon collision, the creature with higher level of energy will suck 1/2 of energy from the other (floor of 1/2 energy).

Each creature has a energy level. Each move will consume one unit of energy. Once a creature's energy reaches zero, 
it will die and will be removed from T4.
The order of the movement among creatures is defined by their distance from universe center (W/2, H/2).
The closer the creature to center, the higher priority for movement.

The world will freeze and stopped working when the number of total creatures become less than 1/4 of initial population.

The input contains multiple simulations of the T4 with different initial states.

First line of input is N number of cases, followed by (1 + 4) x N lines. 
First line of each case contains 3 numbers S, W and H of world.
S defines the number of simultaneous movement in the universe at any given time, W is the width and H is the height of the universe.
Then 4 lines follows. For each case there 4 lines of input. Each line starts with type of creature and then a list of (X, Y, E) tuples.
X and Y are creature coordinates and E is its initial energy level. 0,0 represents top left.

For each case print the coordinates and energy level of any remaining creature in the universe.

## Input Conditions:
W,H >= 2 & Even

## Input:
```
1
1, 10, 10
Salty | (2,3,34) (1,5,20) (3,3,30)
Sweet | (5,7,100)
Sour | (6,4,21) (4,7,45) (6,2,12) (7,8,90)
Spicy | (4,2,12) (3,9,30) (5,8,1000)
```

## Ouput (Sample)
```
Salty | (5,3,72) (1,5,34)
Sour | (1,2,45) (7,8,1)
Spicy | (4,2,230) 
```
