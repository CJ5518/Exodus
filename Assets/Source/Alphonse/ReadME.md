//MummyBoss Prefab
Mummy boss is an aanimated sprite that will chase the main charecter of your choosing, Upon 1 collision the boss wil chase the player, The animations are done through the Finite State machine implemented in unity with added behaviours for each state(Idle, walking, running). to change state with in your code ensure to add when the bool trigger's are changing in the script that will be monitoring the charecters health. example 

if(healthAmt <= 30)
        {
            GetComponent<Animator>().SetBool("isIdle", false);
            GetComponent<Animator>().SetBool("isWalking", false);
            GetComponent<Animator>().SetBool("isRunning", true);
            
        } 
        else if( healthAmt <= 60)
        {
            GetComponent<Animator>().SetBool("isIdle", false);
            GetComponent<Animator>().SetBool("isRunning", false);
            GetComponent<Animator>().SetBool("isWalking", true);
        }

the boss has the abilty to shoot orb objects (and/or) melee.

this is great to use if you are new to unity and want to test out charecter movement and animation!