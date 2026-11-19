/* World class for modeling the entire in-game world
ACTUALLY CREATING THE LOCATIONS AND EXITS BASED OFF 
THE BLUEPRINT THAT COMES FROM NODE.CS
*/

class World {
  Space cityHall;
  private List<Decision> decisions = new List<Decision>();
    
  public World () {
      Space cityHall = new Space("Rådhus",
          "Din sekretær møder dig i døren. \"Velkommen, borgmester! Byen vokser, og vi skal bruge mere strøm.\n" +
          "Du skal træffe beslutninger rundt i byen. Hold øje med tre ting: økonomi, tilfredshed og CO2.\n" +
          "CO2 er en gas, der kommer ud, når man brænder kul. Den gør Jorden varmere.\n" +
          "Skriv hjælp, hvis du er i tvivl.\"");
      Space square = new Space("Torv",
          "Torvet ligger midt i byen. Herfra kan du gå til alle byens steder.\n" +
          "Der er mange biler, og det dytter og larmer.\n" +
          "På en tavle står der: \"Vedvarende energi er energi, der ikke slipper op, fx vind og sol.\"");
      Space residentialArea = new Space("Boligkvarter",
          "To naboer står og snakker over hækken.\n" +
          "Den ene siger: \"Røgen fra kraftværket gør, at mine børn hoster. Kan vi ikke få ren luft?\"\n" +
          "Den anden ryster på hovedet: \"Bare strømmen ikke bliver dyrere. Vi har ikke råd til mere.\"");
      Space coalPlant = new Space("Kraftværk",
          "Du står foran byens gamle kulkraftværk. Røgen fra skorstenen er grå og lugter.\n" +
          "Kraftværket laver det meste af byens strøm. Kul er billigt, men når det brænder, kommer der meget CO2 ud.");
      Space port = new Space("Havn",
          "Måger skriger over havnen, og det blæser altid herude.\n" +
          "En mand fra et vindmøllefirma viser dig en tegning: \"Vindmøller laver strøm af vinden.\n" +
          "De udleder ikke CO2, men de koster mange penge at bygge.\"");
      Space solarSystem = new Space("Solcelleanlæg",
          "Du står på en stor, grøn mark uden for byen. Solen skinner.\n" +
          "Solceller laver strøm af sollys uden at udlede CO2.\n" +
          "Nogle borgere går tur her hver dag, og de vil nødig miste marken.");
    
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
    decisions.Add(coalPlantDecision);

    // Havn: 1. Byg en stor vindmøllepark. 2. Byg en lille vindmøllepark.
    Option bigWindFarm   = new Option("Byg en stor vindmøllepark", -20, 0, -20);    
    Option smallWindFarm = new Option("Byg en lille vindmøllepark", -5, 0, -5);

    Decision portDecision = new Decision("Et firma vil bygge havvindmøller ud for kysten. Hvor stor skal vindmølleparken være?");
    portDecision.AddOption(bigWindFarm);
    portDecision.AddOption(smallWindFarm);
    port.SetDecision(portDecision);
    decisions.Add(portDecision);
    
    // Solcelleanlæg: 1. Byg solceller på markerne. 2. Byg solceller på husenes tage
    Option solarSystemField = new Option("Byg et solcelleanlæg på markerne i landet", -5, -5, -10);
    Option solarSystemHouses = new Option("Byg solcelleanlæg på husene", -15, 0, -10);

    Decision solarDecision = new Decision("Byen skal helst få mere elektricitet. Hvad skal borgmesteren gøre?");
    solarDecision.AddOption(solarSystemField);
    solarDecision.AddOption(solarSystemHouses);
    solarSystem.SetDecision(solarDecision);
    decisions.Add(solarDecision);

    // Torv: 1. Byg en cykelsti. 2. Byg et storcenter
    Option SquareBikeLane = new Option("Byg en cykelsti i torvet", -5, 10, -10);
    Option squareMall = new Option("Byg et storcenter i byen.", -15, 0, 5);


    Decision squareDecision = new Decision("Nogle borgere vil kunne cycle noget mere rundt og andre vil have et storcenter. Hvad skal borgmesteren gøre?");
    squareDecision.AddOption(SquareBikeLane);
    squareDecision.AddOption(squareMall);
    square.SetDecision(squareDecision); 
    decisions.Add(squareDecision);

    
    // Solcelleanlæg
    Document solarDocument = new Document("\x1b[1mDokument:\x1b[0m \"Solcelleanlæg\"", "Solceller laver strøm, når de bliver udsat for sollys.\n" +
        "De udleder ikke CO2, når de laver strøm.\n" +
        "Men solceller koster mange penge at bygge, og de fungerer ikke på en mørk dag. \n");
    solarSystem.SetDocument(solarDocument);
    // Boligkvarter
    Document coalDocument = new Document("\x1b[1mDokument:\x1b[0m \"Kulkraftværk\"", "Kulkraftværket brænder kul for at lave strøm.\n" +
        "Det er billigt, men det udleder meget CO2, som gør Jorden varmere.\n" +
        "Hvis kulkraftværket lukker, skal byen finde en anden måde at lave strøm på.\n");
    coalPlant.SetDocument(coalDocument);
    // Torv
    Document squareDocument = new Document("\x1b[1mDokument:\x1b[0m \"Torv\"", "Torvet er byens centrum. Herfra kan man gå til alle byens steder.\n" +
        "Der er mange biler, og det dytter og larmer.\n" +
        "På en tavle står der: \"Vedvarende energi er energi, der ikke slipper op, fx vind og sol.\"\n");
    square.SetDocument(squareDocument);
    // Rådhus
    Document residentialDocument = new Document("\x1b[1mDokument:\x1b[0m \"Elregningen\"", "Alle familier i byen betaler for den strøm, de bruger.\n" +
        "Bliver strømmen dyrere, har familierne færre penge til andet.\n" +
        "Derfor bliver borgerne utilfredse, hvis strømmen stiger meget i pris.\n");
    residentialArea.SetDocument(residentialDocument);
    // Havn
    Document portDocument = new Document("\x1b[1mDokument:\x1b[0m \"Vindmøller\"", "En vindmølle laver strøm, når vinden drejer vingerne.\n" +
        "Den udleder ikke CO2, når den laver strøm.\n" +
        "Men vindmøller koster mange penge at bygge, og når det er vindstille, laver de ingen strøm.\n");
    port.SetDocument(portDocument);
  }

    
  public Space GetEntry () {
    return cityHall;
  }
  
  public bool AllDecisionsMade (){
      foreach(Decision decision in decisions){
          if (decision.IsMade()==false){
              return false;
          }
      }
      return true;
  }
}

