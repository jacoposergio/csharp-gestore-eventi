

using System.Collections.Generic;


//Evento tomorroland = new Evento("Tomorroland", DateTime.Parse("03/07/2022"), 300);
//Console.WriteLine(tomorroland);

//ProgrammaEventi vivaticket = new ProgrammaEventi("Vivaticket");
//vivaticket.AvviaProgrammaEventi();

//RegistraEvento();
//Console.WriteLine(vivaticket.StampaEventi());
//Console.WriteLine(vivaticket.EventiPerData("22/10/2024"));
//Console.WriteLine(ProgrammaEventi.StampaEventi(vivaticket.Eventi));
//StampaEventi(vivaticket);
//Console.WriteLine(ProgrammaEventi.StampaListaEventi(vivaticket.Eventi));
//Console.WriteLine(vivaticket.EventiPerData("22/10/2024"));


Console.WriteLine("Inserisci titolo programma eventi");
string programmaEventiUtente = Console.ReadLine();
ProgrammaEventi programmaEventi = new ProgrammaEventi(programmaEventiUtente);

bool loop = true;
while (loop)
{
    Console.WriteLine("Scegli un opzione");
    Console.WriteLine("1) Registra un evento");
    Console.WriteLine("2) Informazioni eventi");
    Console.WriteLine("3) Cerca un evento tramite data");
    Console.WriteLine("4) Svuota la lista eventi");
    Console.WriteLine("5) Esci");
    int risposta = Convert.ToInt32(Console.ReadLine());

    switch (risposta)
    {
        case 1:
            try
            {
                Console.WriteLine("Quanti eventi vuoi organizzare");
                int numeroEventiUtente = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= numeroEventiUtente; i++)
                {
                    Console.WriteLine("Aggiunta Evento " + i + ":");
                    Console.WriteLine("Premi 0 per aggiungere un evento generico, 1 per aggiungere una conferenza");
                    int inputUtente = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        if (inputUtente == 0)
                            RegistraEvento();
                        if (inputUtente == 1)
                            RegistraConferenza();
                        else
                        {
                            throw new ProgrammaEventiException("Valore inserito non valido");
                        }
                    }
                    catch (ProgrammaEventiException e)
                    {
                        Console.WriteLine("error: {0}", e.Message);
                    }
                }
                Console.WriteLine("Il numero di eventi presente è: " + programmaEventi.ContaEventi());
                Console.WriteLine("Questi sono tutti gli eventi: " + programmaEventi.StampaEventi());
            }
            catch (ProgrammaEventiException e)
            {
                Console.WriteLine("error: {0}", e.Message);
            }
            break;


        case 2:
            try
            {
                Console.WriteLine("Il numero di eventi presente è: " + programmaEventi.ContaEventi());
                Console.WriteLine("Questi sono tutti gli eventi: " + programmaEventi.StampaEventi());
                Console.WriteLine(ProgrammaEventi.StampaListaEventi(programmaEventi.Eventi));

            }
            catch (ProgrammaEventiException e)
            {
                Console.WriteLine("error: {0}", e.Message);
            }
            break;


        case 3:
            try
            {
                Console.WriteLine("Inserisci una data per sapere se ci sono eventi (formato dd/MM/yyyy)");
                string dataInserita = Console.ReadLine();
                List<Evento> ListaEventiPerData = programmaEventi.EventiPerData(dataInserita);
                Console.WriteLine(ProgrammaEventi.StampaListaEventi(ListaEventiPerData));
            }
            catch (ProgrammaEventiException e)
            {
                Console.WriteLine("error: {0}", e.Message);
            }
            break;


        case 4:
            try
            {
                programmaEventi.SvuotaEventi();
                Console.WriteLine("Il numero di eventi presente è: " + programmaEventi.ContaEventi());
            }
            catch (ProgrammaEventiException e)
            {
                Console.WriteLine("error: {0}", e.Message);
            }
            break;


        case 5:
            loop = false;
            break;
        default:
            Console.WriteLine("Sei capace di premere un tasto?");
            break;
    }
}

//Console.WriteLine("Quanti eventi vuoi organizzare");
//int numeroEventiUtente = Convert.ToInt32(Console.ReadLine());
//for(int i = 1; i <= numeroEventiUtente; i++)
//{
//    Console.WriteLine("Aggiunta Evento " + i +":");
//    RegistraEvento();
//}

//Console.WriteLine("Il numero di eventi presente è: " + programmaEventi.ContaEventi());
//Console.WriteLine("Questi sono tutti gli eventi: " + programmaEventi.StampaEventi());
//Console.WriteLine("Inserisci una data per sapere se ci sono eventi (formato dd/MM/yyyy)");
//string dataInserita = Console.ReadLine();
//List<Evento> ListaEventiPerData = programmaEventi.EventiPerData(dataInserita);
//Console.WriteLine(ProgrammaEventi.StampaListaEventi(ListaEventiPerData));
//programmaEventi.SvuotaEventi();
//Console.WriteLine("Il numero di eventi presente è: " + programmaEventi.ContaEventi());





void RegistraEvento()
{
    Console.WriteLine("\r\nRegistra evento\r\n");
    Console.WriteLine("inserisci il titolo dell'evento");
    string titolo = Console.ReadLine();
    Console.WriteLine("inserisci la data dell'evento nel formato 'dd/MM/yyyy'");
    string data = Console.ReadLine();
    Console.WriteLine("inserisci la capienza massima dell'evento");
    int capienzaMassima = Convert.ToInt32(Console.ReadLine());

    Evento evento = new Evento(titolo, DateTime.Parse(data), capienzaMassima);
    programmaEventi.AggiungiEvento(evento);
}

void RegistraPrenotazioni(Evento evento)
{
    Console.WriteLine("Quanti posti vuoi prenotare?");
    int prenotazioni = Convert.ToInt32(Console.ReadLine());
    evento.PrenotaPosti(prenotazioni);
    //Console.WriteLine("Quanti posti vuoi prenotare?");
    //int postiPrenotati = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("I posti prenotati sono {0}, i posti rimanenti sono {1}", prenotazioni, evento.CapienzaMassima - evento.PostiPrenotati);

}

void RegistraDisdette(Evento evento)
{
    Console.WriteLine("Vuoi disdire dei posti? s/n");
    string risposta = Console.ReadLine();

    switch (risposta)
    {
        case "s":
            Console.WriteLine("Quanti posti vuoi disdire?");
            int disdette = Convert.ToInt32(Console.ReadLine());
            evento.DisdiciPosti(disdette);
            Console.WriteLine("I posti disdetti sono {0}, i posti rimanenti sono {1}", disdette, evento.CapienzaMassima - evento.PostiPrenotati);
            break;
        case "n":
            Console.WriteLine("Grazie e arrivederci");
            break;
        default:
            Console.WriteLine("Sei capace di scrivere?");
            break;
    }
   
}

void RegistraConferenza()
{
    Console.WriteLine("\r\nRegistra conferenza\r\n");
    Console.WriteLine("inserisci il titolo della conferenza");
    string titolo = Console.ReadLine();
    Console.WriteLine("inserisci il nome del relatore");
    string relatore = Console.ReadLine();
    Console.WriteLine("inserisci il prezzo");
    double prezzo = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("inserisci la data dell'evento nel formato 'dd/MM/yyyy'");
    string data = Console.ReadLine();
    Console.WriteLine("inserisci la capienza massima dell'evento");
    int capienzaMassima = Convert.ToInt32(Console.ReadLine());

    Evento evento = new Evento(titolo, DateTime.Parse(data), capienzaMassima);
    programmaEventi.AggiungiEvento(evento);
}
