

using System.Runtime.CompilerServices;

public class ProgrammaEventi
{
    private string _titolo;
    public string Titolo
    {
        get
        {
            return _titolo;
        }
        set
        {
            if (value == "")
            {
                throw new ProgrammaEventiException("Il titolo è mancante");
            }
            _titolo = value;
        }
    }
    public List<Evento> Eventi { get; set; }

    public ProgrammaEventi(string titolo)
    {
        Titolo = titolo;
        Eventi = new List<Evento>();
    }

    //public void AvviaProgrammaEventi()
    //{
    //    AggiungiEvento("Concerto di Gigione", "22/10/2024", 300);
    //    AggiungiEvento("Festivalbar", "10/02/2022", 30000);
    //    AggiungiEvento("Bello figo live on stage", "02/01/2023", 3000);
    //}
    //    public void AggiungiEvento(string titolo, string data, int capienzaMassima)
    //{
    //    DateTime dataConvertita = DateTime.Parse(data);
    //    Evento evento = new Evento(titolo, dataConvertita, capienzaMassima);
    //    Eventi.Add(evento);
    //}

    public void AggiungiEvento(Evento evento)
    {
        Eventi.Add(evento);
    }

    public List<Evento> EventiPerData(string data)
    {
        DateTime dataConvertita = DateTime.Parse(data);
        List<Evento> eventiPerData = new List<Evento>();
 
        foreach (Evento item in Eventi)
        {
            if (item.Data == dataConvertita)
            {
                eventiPerData.Add(item);
            }
        }
        return eventiPerData;
    }

    public int ContaEventi()
    {
        return Eventi.Count;
    }

    public void SvuotaEventi()
    {
        Eventi.Clear();
    }

    public static string StampaListaEventi(List<Evento> Eventi)
    {
        string output = "Tutti gli eventi: \r\n";

        foreach (Evento item in Eventi)
        {
            output += item + "\r\n";
        }
        return output;
    }

    public string StampaEventi()
    {
        string output = "Eventi di " + this.Titolo + ": \r\n";

        foreach (Evento item in Eventi)
        {
            output += item + "\r\n";
        }
        return output;
    }
    //public void StampaEventi()
    //{
    //    foreach (Evento item in Eventi)
    //    {
    //        Console.WriteLine("Titolo : " + item.Titolo);
    //        Console.WriteLine("Capienza massima : " + item.CapienzaMassima);
    //        Console.WriteLine("Data concerto : " + item.Data);
    //        Console.WriteLine();
    //    }

    //}

}