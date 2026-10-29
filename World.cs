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
  }
  
  public Space GetEntry () {
    return cityHall;
  }
}

