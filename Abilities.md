<h1 align="center">Abilities</h1>
<p align="center">
In order to help player escape the maze, game provides 4 abilities, all with cooldown and unique use.
</p>

<br>
<h2 align="center">Types</h2>
<p align="center">
1| PullToTheLight - makes players flashlight cast light in all direction, allowing player to see all around.<br>
2| MinotaurStun - minotaur gets stunned for 6s, allowing player to escape.<br>
3| Ghost - player turns into ghost that can go through walls for a short period of time.<br>
4| PortalTracker - player creates small green trail that goes to portal, helping player find the exit.
</p>


<br>
<h2 align="center">Usage</h2>
<p align="center">
Each ability has its own input (1-4keys), which calls main Use method in PlayerAbilityController, that calls Use of choosen ability.<br> 
This methods job is to check if cooldown is 0 and if true, call actuall ability functionality and cooldown reset.
</p>

<br>
<h2 align="center">UI</h2>
<p align="center">
All abilities have an icon represeting them, icons show what each ability does, what keyboard key it uses and displays cooldown.<br>
When cooldown is more than 0 icon is dark and cooldown is visible, if cooldown is 0, icon is not dark and cooldown is hidden.
</p>


<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
