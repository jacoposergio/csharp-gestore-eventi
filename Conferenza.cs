
public class Conferenza : Evento
{
    public string Relatore
    {
        get
        {
            return Relatore;
        }
        set
        {
            if (value == null || value == "")
            {
                throw new ProgrammaEventiException("Il titolo è mancante");
            }
            Relatore = value;
        }
    }
    public double Prezzo
    {
        get
        {
            return Prezzo;
        }
        set
        {
            if (value < 0)
            {
                throw new ProgrammaEventiException("Il prezzo non pùo essere un valore negativo");
            }
            Prezzo = value;
        }
    }
    public Conferenza(string titolo, DateTime data, int capienzaMassima) : base(titolo, data, capienzaMassima)
    {

    }

    public override string ToString()
    {
        return Data.ToString("dd/MM/yyyy") + " - " + Titolo + " - " + Relatore + " - " + Prezzo.ToString("0.00") + ".";
    }
}