<h1 align="center">Maze</h1>
<p align="center">
Maze is made out of 100 rooms that are later used to procedurally create a maze for player and minotaur to move around.
</p>

<br>
<h2 align="center">Rooms</h2>
<p align="center">
Each room is a prefab with 4walls, roof and a controller.<br>
Before maze is generated 100 rooms are spawned to fill out the given space, and everyone of them is assigned to its slot in MazeGenerator.<br>
Room controller has methods for removing walls and being visited, which sets it as visited and removes roof.
</p>


<br>
<h2 align="center">GeneratingMaze</h2>
<p align="center">
After all 100 rooms are ready, script starts to look for non visited room nerby, visits one of those rooms, sets it as visited and removes correct walls.<br>
This process goes on intill no visited rooms are nerby, when this happens script goes back and looks for more unvisited rooms and visits them.
Generation will stop when all rooms were visited, creating random and unique maze.
</p>




<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
