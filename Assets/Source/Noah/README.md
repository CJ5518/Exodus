Noah Rieth
Plague Events

to call a plague event from any scene,
first make sure that the event manager is loaded and instantiated
If it is not, use

        EventManager em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
        Instantiate(em);

then you can start an event with

        em.startEvent(1, 1, 20);

where the first parameter is an integer corresponding to the type of event
        1 - hail event
        2 -
        3 - 
where the second parameter represents the difficulty of the event
 This parameter can take integer values 1-10, with 10 being most difficult


and where the third parameter is an integer that will dicate how 
      many seconds the event will go on for.