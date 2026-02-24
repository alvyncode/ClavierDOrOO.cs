using Models.Roles;

namespace Models;

public class Joueur
{   public int Id { get; set; }
    public Joueur()
    {
    }
    
    private string _pseudo;
    public string Pseudo
    {
        get { return _pseudo; }
        set { _pseudo = value; }
    }
    public int MeilleurScore { get; set; } = 0;
    public Role Role {get;set;}
    
    private void Repondre()
    {
        
    }
}
