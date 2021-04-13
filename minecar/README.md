This experiment involves creating a physics friendly, dynamic minecar railcar system.

Objectives:

1) The minecar should interact with physics. Example: Swing on inclines and turns.
2) The minecar should be packaged as a prefab.
3) The minecar should have rails to interact with.
4) The minecar/rail system should be easy to setup and interact with.
5) The minecar should align with the direction of the rail, and not rely on tank controls.


Results:

The rail system uses three components: 2 invisible rails and 1 visible rail.
The rail system is an 'overhead' style rail. The car has a connector at top by which to ride the rails.
The minecar controls work as intended.
There is a bug where the collider of the connector triggers on two different colliders at once. This makes for some flashing images.


Notes:

This was relatively quick to put together and code. A better solution would be, rather than a block as a connector, a cylinder. That would make it easier to control the collider, I think.
A next version should make the connector a seperate component inside of a larger prefab so that it can rotate and me animateable.

Sketching out the idea helped a lot, but I need more experience to forsee bigger problems later on.
What is the performance impact of what I am doing? Does this scale as well as I think it does? How can I prove its scalability?

I also need to create a solid time block to experiment so that I am forced to improve. Without concrete limits, I return to experiments and add on as I see fit.
this does not foster better problem solving.

The idea should be akin to speed modeling: Complete something as quickly as possible and improve your problem solving and experience.

Completion Date:

4/13/21