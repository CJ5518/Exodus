FEATURES
The Event Manager singleton prefab is a game object that oversees timed events that happen in game. 
It has the EventManager script attached to it, which waits for calls to it's public method startEvent.
This function acts as a facade over all of the events, so that other code does not need to worry about any of the pecuiliarities of the different types of events
In addition to being a facade, it acts like a semaphore, only allowing 1 event to be active at a time to keep gameplay smooth and straighforward
EventManager is used to manage the three types of plague events in this game.
Note that it does not get destroyed between scenes so it needs only to be instantiated once.


This structure could be used to manage events in any other game project. The number of events can be augmented by adding more cases to the start event function, to give it a broader range.


USE
To use the event manager, first make sure that the event manager is loaded and instantiated. It already is in the Exodus build 
If using event manager in a different project, instantiate the EventManager first by loading it from its path in the resources folder like such:

    EventManager em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
    Instantiate(em);

In this build of the game, it should be instantiated and ready to go, because it is a DontDestroyOnLoad singleton structure that has already been placed in the first scene. To access it, use

    EventManagerSingleton eventManager = EventManagerSingleton.Instance;

then you can start an event with

    eventManager.startEvent(1, 7, 10);

where the first parameter is an integer corresponding to the type of event 1 - hail event 2 - frog event 3 - dark event where the second parameter represents the difficulty of the event.
This parameter can take integer values 1-10, with 10 being most difficult and where the third parameter is an integer that will dictate how many seconds the event will go on for. 
The frog event is a special case where the time will instead dictate how many seconds are between the spawns of the frog enemies.
