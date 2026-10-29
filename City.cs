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
        
    } 
    public string GetStatus (){
        return "\nØkonomi: "+economy+ "\nTilfredshed: " +satisfaction+ "\nCO2: " +co2+ "\n";
    }
}
