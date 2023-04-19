Noah Rieth - 
Plague Events

To call a plague event from any scene, first make sure that the event manager is loaded and instantiated.
If using this in a different build, instantiate the EventManager first with

        EventManager em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
        Instantiate(em);

In this build of the game, it should be instantiated and ready to go, because it is a DontDestroyOnLoad singleton structure that has already been placed in the first scene. To access it, use

    EventManagerSingleton eventManager = EventManagerSingleton.Instance;

then you can start an event with

        eventManager.startEvent(1, 7, 10);

where the first parameter is an integer corresponding to the type of event
        1 - hail event
        2 - frog event
        3 - dark event
where the second parameter represents the difficulty of the event
 This parameter can take integer values 1-10, with 10 being most difficult


and where the third parameter is an integer that will dictate how many seconds the event will go on for. The frog event is a special case where the time will instead dictate how many seconds are between the spawns of the frog enemies.
