
public class Evento
{

    //attributi

    private string _titolo;
    public string Titolo {
        get
        {
            return _titolo; 
        }
        set
        {
            if( value == null || value == "")
            {
                throw new ProgrammaEventiException("Il titolo è mancante");
            }
            _titolo = value;
        }
     }
    private int _capienzaMassima;
    public int CapienzaMassima
    {
        get
        {
            return _capienzaMassima;
        }
        set
        {
            if (value <= 0)
            {
                throw new  ProgrammaEventiException("La capienza non può essere un numero negativo");
            }
            _capienzaMassima = value;
        }
    }
    public int PostiPrenotati { get; private set; }
    public DateTime Data { get; set; }

    //costruttore

    public Evento(string titolo, DateTime data, int capienzaMassima)
    {
        Titolo = titolo;
        Data = data;
        CapienzaMassima = capienzaMassima;
        PostiPrenotati = 0;

    }

    public void PrenotaPosti(int postiDaAggiungere)
    {
        if (Data < DateTime.Now )
        {
            throw new ProgrammaEventiException("La data dell'evento è già passata");
        }
        if (CapienzaMassima < 0 || postiDaAggiungere + PostiPrenotati > CapienzaMassima)
        {
            throw new ProgrammaEventiException("Non ci sono posti disponibili");
        }
        PostiPrenotati += postiDaAggiungere;
       
    }

    public void DisdiciPosti(int postiDaRimuovere)
    {
        if (Data < DateTime.Now)
        {
            throw new ProgrammaEventiException("La data dell'evento è già passata");
        }
        if (CapienzaMassima < 0 && postiDaRimuovere + PostiPrenotati > 0)
        {
            throw new ProgrammaEventiException("Non ci sono posti disponibili");
        }
        PostiPrenotati -= postiDaRimuovere;
    }

    public override string ToString()
    {
        return Data.ToString("dd/MM/yyyy") + " " + Titolo;
    }
}
