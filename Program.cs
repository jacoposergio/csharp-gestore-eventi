// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Evento
{

    //attributi
    public string Titolo {
        get
        {
            return Titolo; 
        }
        set
        {
            if( Titolo != null)
            {
                throw new Exception("Il titolo è mancante");
            }
            Titolo = value;
        }
     }
    public int CapienzaMassima
    {
        get
        {
            return CapienzaMassima;
        }
        set
        {
            if (CapienzaMassima < 0)
            {
                throw new Exception("La capienza non può essere un numeo negativo");
            }
            CapienzaMassima = value;
        }
    }
    public int postiPrenotati { get; }
    public DateTime Data { get; set; }
    public DateTime DataOdierna { get; }

    //costruttore

    public Evento(string titolo, int postiPrenotati, DateTime data, DateTime DataOdierna)
    {
        Titolo = titolo;
        Data = data;
        DataOdierna = DateTime.Now;
    }

    public void PrenotaPosti()
    {
        if(DataOdierna >= DateTime.Now)
        {

        }
    }
  


}