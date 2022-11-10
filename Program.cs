

using System.Collections.Generic;


//Evento tomorroland = new Evento("Tomorroland", DateTime.Parse("03/07/2022"), 300);
//Console.WriteLine(tomorroland);

ProgrammaEventi vivaticket = new ProgrammaEventi("Vivaticket");
vivaticket.AvviaProgrammaEventi();

//RegistraEvento();
Console.WriteLine(vivaticket.StampaEventi());


//Console.WriteLine(vivaticket.EventiPerData("22/10/2024"));
//Console.WriteLine(ProgrammaEventi.StampaEventi(vivaticket.Eventi));
//StampaEventi(vivaticket);
//Console.WriteLine(ProgrammaEventi.StampaListaEventi(vivaticket.Eventi));



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
    RegistraPrenotazioni(evento);
    Console.WriteLine("Vuoi disdire dei posti? s/n");
    string risposta = Console.ReadLine();
    
    switch (risposta)
    {
        case "s":
            RegistraDisdette(evento);
            break;
        case "n":
            Console.WriteLine("Grazie e arrivederci");
            break;
        default:
            Console.WriteLine("Sei capace di scrivere?");
            break;
    }
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
    Console.WriteLine("Quanti posti vuoi disdire?");
    int disdette = Convert.ToInt32(Console.ReadLine());
    evento.DisdiciPosti(disdette);
    Console.WriteLine("I posti disdetti sono {0}, i posti rimanenti sono {1}", disdette, evento.CapienzaMassima - evento.PostiPrenotati);
}
