Team ABC
Participants: Alexander Peterson, Benjamin L., Cody Rhee

Goals: Produce a game that interfaces with a cloud database that stores and retrieves scores and input scores with a
name to go with it. The scores will be put in order, and the maximum number of scores stored is 10.

Desired User Experience: We hope to provide a game that provides a sort of competitiveness where a player can try 
and get a higher score on the scoreboard. 

Implementation: The project uses Unity Webgl with a RESTFUL API to interface with a Firebase Realtime Database. The Game sends 
and recieves a score board data object to insert a new score and to display current scores.

Issues: 1. None of us had any cloud development experience so the project was hard to make work right.
2. The cloud we used has no protection currently so techincally anyone can edit the contents.
3. The game might crash if the database is disabled. (Which will be disable by next weekend)

