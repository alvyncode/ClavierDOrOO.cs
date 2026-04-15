using Data.Repositories;
using Data.Service;
using Models;

namespace ViewModels.UserControls;
public class HistoryViewModel:BasicViewModel
{
    public string PseudoDernierJoueur { get; set; }
    public List<PartieDto> ListeDesParties { get; set; }
    public HistoryViewModel(Joueur j)
    {
        ListeDesParties  = new PartieRepository().ListeDesParties(j);
        PseudoDernierJoueur = j.Pseudo;
    }
}
