/* World class for modeling the entire in-game world
ACTUALLY CREATING THE LOCATIONS AND EXITS BASED OFF 
THE BLUEPRINT THAT COMES FROM NODE.CS
*/

class World {
  Space cityHall;
  
  public World () {
    Space cityHall           = new Space("Rådhus");
    Space square             = new Space("Torv");
    Space residentialArea    = new Space("Boligkvarter");
    Space coalPlant          = new Space("Kraftværk");
    Space port               = new Space("Havn");
    Space solarSystem      = new Space ("Solcelleanlæg");

    // WE "HARDCODE" IT NOW, BUT HAVENT LEARNT HOW TO OPTIMIZE IT.
    // WE WILL INCLUDE IT IN OUR RAPPORT AND EVENTUALLY CHANGE IT
    // WHEN WE LEARN HOW TO. NICE TO HAVE
    
    square.AddEdge("boligkvarter", residentialArea);
    square.AddEdge("rådhus", cityHall);
    square.AddEdge("havn", port);
    square.AddEdge("solcelleanlæg", solarSystem);
    square.AddEdge("kraftværk", coalPlant);    

    
    // Alle forgreninger til square som er centrum
    cityHall.AddEdge("torv", square);
    residentialArea.AddEdge("torv", square);
    coalPlant.AddEdge("torv", square);
    solarSystem.AddEdge("torv", square);
    port.AddEdge("torv", square);
    
    this.cityHall = cityHall;

    // Decisions and options

    //  1. Sæt kulkraftværket i stand. 2. Luk kulkraftværket.
    Option repairCoalPlant = new Option("Sæt kulkraftværket i stand", 15, -10, 20);
    Option shutdownCoalPlant = new Option("Luk kulkraftværket", -15, 10, -20); // change

    Decision coalPlantDecision = new Decision("Det gamle kulkraftværk er slidt, men byen har brug for strøm. Hvad skal borgmesteren gøre?"); 
    coalPlantDecision.AddOption(repairCoalPlant);
    coalPlantDecision.AddOption(shutdownCoalPlant);
    coalPlant.SetDecision(coalPlantDecision);

    // Havn: 1. Byg en stor vindmøllepark. 2. Byg en lille vindmøllepark.
    Option bigWindFarm   = new Option("Byg en stor vindmøllepark", -20, 0, -20);
    Option smallWindFarm = new Option("Byg en lille vindmøllepark", -5, 0, -5);

    Decision portDecision = new Decision("Et firma vil bygge havvindmøller ud for kysten. Hvor stor skal vindmølleparken være?");
    portDecision.AddOption(bigWindFarm);
    portDecision.AddOption(smallWindFarm);
    port.SetDecision(portDecision);

    // Solcelleanlæg: 1. Byg solceller på markerne. 2. Byg solceller på husenes tage
    Option solarSystemField = new Option("Byg et solcelleanlæg på markerne i landet", -5, -5, -10);
    Option solarSystemHouses = new Option("Byg solcelleanlæg på husene", -15, 0, -10);

    Decision solarDecision = new Decision("Byen skal helst få mere elektricitet. Hvad skal borgmesteren gøre?");
    solarDecision.AddOption(solarSystemField);
    solarDecision.AddOption(solarSystemHouses);
    solarSystem.SetDecision(solarDecision);

    // Torv: 1. Byg en cykelsti. 2. Byg et storcenter
    Option SquareBikeLane = new Option("Byg en cykelsti i torvet", -5, 10, -10);
    Option squareMall = new Option("Byg et storcenter i byen.", -15, 0, 5);

    Decision squareDecision = new Decision("Nogle borgere vil kunne cycle noget mere rundt og andre vil have et storcenter. Hvad skal borgmesteren gøre?");
    squareDecision.AddOption(SquareBikeLane);
    squareDecision.AddOption(squareMall);
    square.SetDecision(squareDecision); 
  }

    
  public Space GetEntry () {
    return cityHall;
  }
}

