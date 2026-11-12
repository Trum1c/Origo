class Inventory {
    private List<Document> documents = new List<Document>();

    public void AddDocument(Document document){
        this.documents.Add(document);
    }
    
    // remove if not used.
    public void RemoveDocument(Document document){
        this.documents.Remove(document);
    }

    public Document? GetDocument(string name){
        for(int i = 0; i<documents.Count; i++){
            if(documents[i].GetName()==name){
                return documents[i];
            }
        }
        return null;
    }

    public override string ToString(){
        string inventory = "";

        if(documents.Count != 0){
            foreach(Document document in documents){
                inventory += document.GetName();
                inventory += "\n"+document.GetContent()+"\n";
            }
        } else{
            inventory += "tom mappe";
        }
        return inventory;
    }
}