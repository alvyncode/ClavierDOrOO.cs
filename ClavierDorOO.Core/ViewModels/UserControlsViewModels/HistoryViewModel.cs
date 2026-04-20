using Command;
using Data.Repositories;
using Data.Service;
using Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Diagnostics;
using System.IO;

namespace ViewModels.UserControls;
public class HistoryViewModel:BasicViewModel
{
    public string PseudoDernierJoueur { get; set; }
    public List<PartieDto> ListeDesParties { get; set; }
    public RelayCommand GenererPdfCommand { get; }
    public HistoryViewModel(Joueur j)
    {
        ListeDesParties  = new PartieRepository().ListeDesParties(j);
        PseudoDernierJoueur = j.Pseudo;
        GenererPdfCommand = new RelayCommand(GenererPdf);
        QuestPDF.Settings.License = LicenseType.Community;
    }
    public void GenererPdf()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Historique_{PseudoDernierJoueur}.pdf");

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12).FontFamily(Fonts.Arial));

                page.Header().Column(col =>
                {
                    col.Item().Text("CLAVIER D'OR").SemiBold().FontSize(28).FontColor(Colors.Blue.Darken2);
                    col.Item().Text($"Historique des parties de : {PseudoDernierJoueur}").FontSize(16).Italic();
                    col.Item().PaddingBottom(1, Unit.Centimetre);
                });
                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(50);  // ID
                        columns.RelativeColumn();    // Nom de la partie
                        columns.RelativeColumn();    // Progression
                        columns.RelativeColumn();    // Score
                    });
                    table.Header(header =>
                    {
                        header.Cell().BorderBottom(1).PaddingBottom(5).Text("#").SemiBold();
                        header.Cell().BorderBottom(1).PaddingBottom(5).Text("Nom de la partie").SemiBold();
                        header.Cell().BorderBottom(1).PaddingBottom(5).AlignCenter().Text("Progression").SemiBold();
                        header.Cell().BorderBottom(1).PaddingBottom(5).AlignRight().Text("Score").SemiBold();
                    });
                    foreach (var partie in ListeDesParties)
                    {
                        table.Cell().PaddingVertical(5).Text(partie.Id.ToString());
                        table.Cell().PaddingVertical(5).Text(partie.NomDeLaPartie);
                        table.Cell().PaddingVertical(5).AlignCenter().Text($"{partie.Progression}%");
                        table.Cell().PaddingVertical(5).AlignRight().Text(partie.Score.ToString("N0"));
                    }
                });
                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                        x.Span(" sur ");
                        x.TotalPages();
                    });
            });
        })
        .GeneratePdf(filePath);
        Process.Start(new ProcessStartInfo
        {
            FileName = filePath,
            UseShellExecute = true
        });
    }
}
