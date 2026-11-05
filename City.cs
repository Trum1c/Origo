public class City {
    private int economy;
    private int satisfaction;
    private int co2;
    private List<Option> choices = new List<Option>();    

    public City (int economy, int satisfaction, int co2) {
    this.economy = economy;
    this.satisfaction = satisfaction;
    this.co2 = co2;
    }
    
    public void ApplyOption(Option option) {
        this.economy += option.GetEconomyChange();
        this.satisfaction += option.GetSatisfactionChange();
        this.co2 += option.GetCo2Change();

        choices.Add(option);
    } 
    public string GetStatus (){
        return "\nØkonomi: "+economy+ "\nTilfredshed: " +satisfaction+ "\nCO2: " +co2+ "\n";
    }

    public string GetSummary(){
        string summary = "\nDine Valg:\n";
        int choiceNumber = 1;

        foreach(Option option in choices){
            summary += "\n"+choiceNumber+". "+option.GetName()+"\n";
            summary += "Økonomi: "+option.GetEconomyChange()+"\n";
            summary += "Tilfredshed: "+option.GetSatisfactionChange() +"\n";
            summary += "CO2: "+option.GetCo2Change()+"\n";

            choiceNumber++;
        }
        return summary;

    
    }
    public int GetEconomy(){
        return economy;
    }
}
