class Inventory {
    private List<Document> documents = new List<Document>();

    public void AddDocument(Document document){
        this.documents.Add(document);
    }

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
}