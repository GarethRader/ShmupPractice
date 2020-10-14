#Process


Initial Entry with brainstorming:
    - initial idea was a bit more broad and a little infeasible to do in a short amount of time (after realizing how much work each system would need)
    - later goal was to just have a basic shoot'em up that felt good with controls and was randomly generated
        - I wanted to model the feeling of Enter the Gungeon when playing (could shoot all directions and aim while dodging bullet hell)
        - Though more complicated mechanics don't exist quite yet, I feel like the fundamental of the games are solid which I would prefer having first before trying to implement more complex systems (different types of damage or shooting mechanics)

Lessons from playtesting:
    - Even when fundamentals are somewhat in place, there is still something that can always be better
    - Balancing player/enemy interaction can always be better (making it feel challenging but not overwhelming)
    - 80-20 rule, most of the game can be implemented very quickly, but fine-tuning takes up most of the time...


Incorporate Single player versus game
Capture Objective: reclaim digestive tract from harmful organisms while using remains from conquered enemies to gain new tools?
    - somewhat also construction objective
    - attempting to create an outwit dynamic with enemy evolution/adaptation to player 
Exploration: explore (potentially randomly generated) areas and maybe use certain puzzles to fix parts of the digestive system



Puzzles/Challenges for the player:
    - resource management with size
    - evolving consequences with enemies and player (enemy can adapt stat-wise to player)
    - dealing with attack patterns from enemies

Basic rules for the Game:
    - Shootem-up, conquer and don't be conquered
    - Bigger as you survive longer, but can be prone to new enemies/evolutions if not exposed
        - rock-paper-scissors dynamic between randomly generated enemies and player
        -Resources may or may not include:
            -lives, health, currency, actions (take from health?)


10.5.2020 - Enemy Spawning and targeting

    NEXT: still having problems with simulating physics with player object rigid body component and collision/movement
        - Dungeon generation bugs
        - fine tuning enemy spawning
        - add Enemy pathfinding

09.29.2020 - Dungeon Generation and Camera Movement
    
    NEXT: fine tuning Dungeon Generation and adding zoom to Camera then adding collision with dungeon walls and other actors

09.26.20 - Initial movement and firing mechanics have been made

    NEXT: dashing, dodging, and other movement mechanics and fine tuning. Firing/combat mechanics will be developed at a later time.



Long term plans (not finalized and subject to change):

    - Tech Tree system for player (class system)
        - involves evolution tracks to evolve as a bacteria
        - researched in a lab of white blood cells? (similar to npcs in Enter the Gungeon?)
            - maybe collecting items from enemies will allow for certain "tech" to be researched
        - potentially different types of player-controlled bacteria

    - Combat system:
        - might be a form of complicated rock-paper-scissors 
        - certain strands of bacteria may be better than others at fighting specific enemies
        - grow as you survive longer and kill more enemies
            - sacrifice small parts of player character to use powerful abilities?

    - Simple Physics system:
        - collision detection
        - momentum

    - Different enemy types:
        - three main types:
            - Parasites
            - viruses
            - bacteria
        enemy list consisting of but not limited to: E. coli (and different strands), listeria, salmonella, camplyobactor, shigella, rotavirus, giardia, cryptosporidium, staphylococcus
            - pathing and targetting for enemies?
            - PLAN: heuristic behaviors for certain enemies?

    - Randomly generated enemies
        - size depends on health, which varies per enemy
        - same with damage
        - slower if bigger
        AMBITIOUS goals: 
            - nemesis system or some form of it
            - Randomly generated environments/maps?
            - enemies will evolve too!?!?!

