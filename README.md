# Book Reviews

[![Build status](https://ci.appveyor.com/api/projects/status/xoudmkvb46n3ccd5?svg=true)](https://ci.appveyor.com/project/matteoUniUrb/bookreviews)

Una web API per ricercare libri e aggiungere una recensione. 

## Nome

Matteo C 
 
## Matricola
270018


## Relazione

BookReviews é un set di web API che permette di effettuare una ricerca libri tramite la piattaforma OpenLibrary e l'aggiunta di recensioni a libri di testo.

## Architettura e scelte implementative

L'applicazione é stata sviluppata su framework multi-platform .NET Core 2.2.

E' una applicazione di tipo WebApi che espone endpoint tramite la classe Controller (`BookController` in questo progetto).

L'applicazione utilizza OpenLibrary e LiteDB come risorse "esterne".

OpenLibrary espone delle API pubbliche e viene invocata tramite richiesta HTTP (Implementata nelle classi in cartella HTTP).

LiteDB é un semplice database per la piattaforma .NET che permette di salvare i dati su un file locale.

L'applicazione é sviluppata su 3 layer:

* Controller    => é l'entry point per ciascun endpoint. Questo strato applicativo invoca lo strato sottostante "Service"
* Service   => é lo strato dove é implementata la business logic. Nel nostro caso abbiamo l'invocazione HTTP delle API di OpenLibrary e l'invocazione dello strato sottostante di Repository per l'accesso al database LiteDB.
* Repository    => é lo strato di accesso al database dove vengono implementati i metodi di lettura/scrittura.


## Riferimento a servizi esterni utilizzati

Si fa riferimento alle API di www.openlibrary.com (per integrazione API vedere il Development Center: https://openlibrary.org/developers)

## Documentazione API

Sono state implementati 3 endpoint:

* GET   /v1/books/search  => effettua la ricerca di libri con chiave di testo libera. Utilizza Open Library API
* GET   /v1/books/{key}    => richiede i dettagli di un libro data la sua chiave (Open Library ID). Utilizza Open Library API
* POST  /v1//reviews/{key}  => aggiunge una recensione al libro specificato (utilizza un database locale LiteDB).

## Messa online dell'API

Per la messa online é stato utilizzata la piattaforma Amazon Web Services - BeanStalk, un servizio che permette un deploy veloce su piattaforma cloud (EC2).

Il servizio é ospitato su una istanza Windows/IIS.

Il servizio é accessibile all'url : http://bookreviewsapi-env.k373fqgsam.us-east-1.elasticbeanstalk.com/swagger/index.html (swagger).

## Esempio di utilizzo del servizio web

TBD
• Breve relazione:
o Descrizione di architettura e scelte implementative (componenti
software, comunicazione tra componenti, tecnologie adottate,
librerie, scelte implementative di rilievo, etc.),
o Riferimento a eventuali dati o servizi esterni sfruttati,
o Documentazione dell’API implementata (URL, dettagli delle
richieste HTTP supportate, formato e codifica dei dati in input
ed output, etc.),
o Descrizione delle modalità della messa online del servizio,
o Esempio descrittivo di utilizzo del servizio Web (sequenza di
richieste/risposte HTTP di esempio, descrizione dei dati
attesi/ottenuti), se il progetto è composto anche da un client,
eventuali screenshot che ne dimostrano l’utilizzo.