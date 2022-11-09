
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
                throw new Exception("Il titolo è mancante");
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
            if (value < 0)
            {
                throw new Exception("La capienza non può essere un numeo negativo");
            }
            _capienzaMassima = value;
        }
    }
    public int postiPrenotati { get; private set; }
    public DateTime Data { get; set; }

    //costruttore

    public Evento(string titolo, DateTime data, int CapienzaMassima)
    {
        Titolo = titolo;
        Data = data;
        CapienzaMassima = 0;
       
    }

    public void PrenotaPosti(int postiDaAggiungere)
    {
        if (Data < DateTime.Now )
        {
            throw new Exception("La data dell'evento è già passata");
        }
        if (CapienzaMassima < 0 || postiDaAggiungere + postiPrenotati > CapienzaMassima)
        {
            throw new Exception("Non ci sono posti disponibili");
        }
        postiPrenotati += postiDaAggiungere;
       
    }

    public void DisdiciPosti(int postiDaRimuovere)
    {
        if (Data < DateTime.Now)
        {
            throw new Exception("La data dell'evento è già passata");
        }
        if (CapienzaMassima < 0 || postiDaRimuovere + postiPrenotati > 0)
        {
            throw new Exception("Non ci sono posti disponibili");
        }
        postiPrenotati -= postiDaRimuovere;
    }

    public override string ToString()
    {
        return Data.ToString("dd/MM/yyyy") + " " + Titolo;
    }



}