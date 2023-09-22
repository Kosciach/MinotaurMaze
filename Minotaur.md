<h1 align="center">Minotaur</h1>
<p align="center">
Minotaur is an enemy in a maze that player has to run away from.<br>
If player gets caught by Minotaur, game ends with player losing.
</p>

<br>
<h2 align="center">StateMachine</h2>
<p align="center">
Minotaur uses StateMachine to controll its behaviour.<br>
This StateMachine has 3 states(Chase, Stun, GameOver), these states have their own logic implementation and transitions.<br>
Each state is represented by enum, which is used to check what state should be current.
</p>


<br>
<h2 align="center">Navigation</h2>
<p align="center">
Minotaur uses 2D navMesh to chase player around the maze.<br>
For NavMesh agent to work correctly, navMesh is build right after maze is generated, this is made because the maze is random.
</p>




<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
