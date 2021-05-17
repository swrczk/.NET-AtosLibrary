using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Infrastructure.SQLDataBase;

namespace AtosLibrary.Domain.Book
{
    public class BookRepositoryDB : IBookRepository
    {
        private readonly AtosLibraryContext _context;
        
        public BookRepositoryDB(AtosLibraryContext context)
        {
            _context = context;
        }
        public void Save(BookEntity bookEntity)
        {
            this._context.Book.Add(bookEntity);
            this._context.SaveChanges();
        }

        public BookEntity Get(Guid bookId)
        {
            return this._context.Book.FirstOrDefault(x => x.Id == bookId);
        }

        public IEnumerable<BookEntity> GetList()
        {
            return this._context.Book.ToList();
        }

        public void Edit(BookEntity bookEntity)
        {
            var localBookEntity = Get(bookEntity.Id);

            localBookEntity.Id = bookEntity.Id;
            localBookEntity.Name = bookEntity.Name;
            localBookEntity.Description = bookEntity.Description;
            localBookEntity.Number = bookEntity.Number;
            this._context.SaveChanges();
        }


        /*Nie mozna usuwać ksiazek wypożyconych*/
        public void Delete(Guid id)
        {
            this._context.Book.Remove(Get(id));
            this._context.SaveChanges();
        }

        private void AddBookData()
        {
            
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Katedra", "Niebezpiecznie jest za bardzo się zapatrzyć… Planetoidy w układzie gwiazdy Lévie. Wypadek zmusza holownik „Sagittarius” do schronienia się na jednej z nich. Zapasów tlenu nie starczy jednak dla wszystkich. Izmir Predú poświęca się, by reszta załogi......", 1));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Starość aksolotla", "Pierwsze książkowe wydanie słynnej powieści Jacka Dukaja, na podstawie której Netflix produkuje serial Into the Night. Kiedy tajemnicze promieniowanie sterylizuje Ziemię z wszelkiego życia, nielicznym ludziom udaje się przekopiować swoje scyfryzowane......", 1));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Po piśmie", "Koniec pisma i człowiek tracący podmiotowość w nowym dziele Jacka Dukaja. Intelektualna podróż wokół najbardziej fascynujących zagadnień współczesnej cywilizacji – aż do jej kresu i do kresu człowieka. Przez ostatnich kilka tysięcy lat pismo,......", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Problem trzech ciał", "Oszałamiający rozmachem chiński bestseller, który stał się wydawniczym fenomenem w USA. NAGRODA HUGO DLA NAJLEPSZEJ POWIEŚCI 2015 R. „Imponująca rozmachem ucieczka od rzeczywistości. Dała mi odpowiednią perspektywę w zmaganiach z Kongresem –......", 4));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Robinson Crusoe", "Robinson Crusoe to bezdyskusyjny klasyk literatury młodzieżowej, a jednocześnie tekst literacki, który doczekał się niezliczonej liczby adaptacji, skrótów i parafraz. Niniejsza edycja jest jedną z najbardziej oryginalnych wersji tej opowieści. Dzieje......", 1));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "C# od podszewki", "C# liczy sobie około dwudziestu lat. Jest niestrudzenie rozwijany i doskonalony przez Microsoft, a dzięki swojej wszechstronności znajduje zastosowanie w wielu dziedzinach: pisaniu gier komputerowych, tworzeniu skalowalnych i niezawodnych aplikacji internetowych oraz aplikacji mobilnych, a nawet niskopoziomowym programowaniu komponentów większych systemów. Twórcy C# postawili na obiektowość, ścisłą kontrolę typów, a przede wszystkim na prostotę w stosowaniu. W tym celu wykorzystano wyniki badań akademickich i połączono je z praktycznymi technikami rozwiązywania problemów. W efekcie C# stał się ulubionym językiem profesjonalistów.", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Wzorce projektowe w .NET.", "Wzorce projektowe są bardzo przydatnym narzędziem w przyborniku programisty. Pozwalają na szybkie opracowanie złożonych zagadnień, ale można je również potraktować jako wstęp do ciekawego i inspirującego dochodzenia, jak rozwiązać konkretny problem na wiele różnych sposobów, na różnych poziomach zaawansowania technicznego i z zastosowaniem różnego rodzaju kompromisów. Takie próby jednak często prowadzą do nadinżynierii lub powstawania zbyt skomplikowanych struktur i mechanizmów. Chociaż bywa to zabawne i pomaga w doskonaleniu umiejętności programistycznych, nie jest pożądanym sposobem tworzenia systemów produkcyjnych.", 3));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Projektowanie gier przy użyciu środowiska Unity i języka C#", "Każdy, kto chce pisać gry, poza odpowiednią wiedzą teoretyczną i znakomitymi pomysłami, powinien posiadać praktyczne umiejętności korzystania z nowoczesnych narzędzi służących do tego celu. W czasach, gdy napisanie i pokazanie światu nowej gry jest poważnym projektem angażującym wielu profesjonalistów z różnych branż, projektant doświadczeń interaktywnych musi podejmować wiele istotnych decyzji na dość wczesnych etapach rozwoju gry. Ważna jest również umiejętność prototypowania i przekazywania pozostałym członkom zespołu swoich koncepcji projektowych. To wszystko sprawia, że prowadzenie projektu, którego celem jest napisanie dobrej gry, jest zadaniem trudnym i pełnym wyzwań.", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "C#. Rusz głową", "C# to odpowiedź firmy Microsoft na odnoszący sukcesy język Java. Za pomocą C# możesz pisać przenośny kod, który Twoi klienci uruchomią w dowolnym systemie. Jest tylko jeden warunek — muszą mieć dostęp do środowiska uruchomieniowego: .NET Framework, Mono lub DotGNU. Innymi słowy, C# spełnił marzenia programistów — raz stworzony kod można uruchomić bez dodatkowych nakładów na różnych platformach.", 4));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Visual Basic .NET w praktyce. Błyskawiczne tworzenie aplikacji", "Visual Basic to język programowania o bardzo długiej tradycji. Kiedy kilka lat temu przeniesiono go na platformę .NET, zyskał nowe możliwości rozwoju. Dziś chętnie używają go osoby, które potrzebują wygodnego narzędzia, pozwalającego szybko stworzyć aplikację do prezentacji i analizy konkretnych danych. Jasna, niezbyt skomplikowana składnia, doskonała biblioteka gotowych kontrolek i bezkolizyjna współpraca z bazą danych to najważniejsze atuty VB.NET.", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Turbo Pascal. Ćwiczenia praktyczne.", "Turbo Pascal, pomimo swojego podeszłego wieku cały czas uważany jest za doskonały język programowania dla celów dydaktycznych. Jego czytelna i prosta składnia, niewielki zestaw słów kluczowych i spore możliwości czynią go idealną platformą dla początkujących. Opanowanie Turbo Pascala nie tylko ułatwi poznawanie innych języków programowania, ale, co znacznie ważniejsze, nauczy myślenia algorytmicznego, które jest niezbędne każdemu programiście. Poza tym -- Turbo Pascal stał się podstawą języka Object Pascal wykorzystywanego w niezwykle popularnym dziś środowisku programistycznym Delphi.", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Black Hat Python. Język Python dla hakerów i pentesterów", "Python to zaawansowany język programowania z ponad 20-letnią historią, który dzięki przemyślanej architekturze, ciągłemu rozwojowi i dużym możliwościom zyskał sporą sympatię programistów. Przełożyła się ona na liczbę dostępnych bibliotek i narzędzi wspierających tworzenie zarówno prostych, jak i skomplikowanych skryptów. Potencjał Pythona docenili również pentesterzy oraz inne osoby, którym nieobce są zagadnienia związane z", 5));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Opus magnum C++. Misja w nadprzestrzeń C++14/17", "C++ to jeden z najpopularniejszych i najpotężniejszych języków programowania. Stanowi punkt wyjścia dla wielu innych języków, które odziedziczyły po nim składnię i liczne możliwości, dzięki czemu można śmiało stwierdzić, że znajomość C++ otwiera drzwi do świata nowoczesnego programowania i jest podstawą na wymagającym rynku pracy w branży informatycznej. Czasy się zmieniają, lecz to C++ jest wciąż wybierany wszędzie tam, gdzie liczą się możliwości, elastyczność, wydajność i stabilność.", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Młodzi giganci programowania. Scratch", "Nudzą Cię już gry komputerowe i zwykłe przeglądanie internetu? Uważasz, że stać Cię na więcej? Masz ochotę zaskoczyć kolegów z klasy? A może po prostu... chcesz nauczyć się programować? Jeśli tak, to dobrze trafiłeś!", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Czysty kod. Podręcznik dobrego programisty", "O tym, ile problemów sprawia niedbale napisany kod, wie każdy programista. Nie wszyscy jednak wiedzą, jak napisać ten świetny, „czysty” kod i czym właściwie powinien się on charakteryzować. Co więcej – jak odróżnić dobry kod od złego? Odpowiedź na te pytania oraz sposoby tworzenia czystego, czytelnego kodu znajdziesz właśnie w tej książce. Podręcznik jest obowiązkową pozycją dla każdego, kto chce poznać techniki rzetelnego i efektywnego programowania.", 1));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "HTML i CSS. Zaprojektuj i zbuduj witrynę WWW. Podręcznik Front-End Developera", "Umiejętność projektowania i budowania stron WWW jest obecnie bardzo ceniona. Firma, organizacja, artysta, a często nawet osoba prywatna chcą mieć własną witrynę. I mimo że liczba stron w sieci jest wprost niewyobrażalna, wciąż jest tam miejsce na nowe! Dlatego odpowiedz sobie na pytanie: czy chcesz zbudować swoją własną witrynę, poszerzyć swoje kwalifikacje i zdobyć lepszą pracę? Tak? To zapraszamy do lektury!", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Angular. Programowanie z użyciem języka TypeScript.", "Angular jest znakomitym frameworkiem wybieranym przez programistów, którym zależy na szybkiej, wydajnej i satysfakcjonującej pracy. Umożliwia sprawne tworzenie zarówno lekkich klientów internetowych, jak i w pełni funkcjonalnych aplikacji. Angular pozwala na wykorzystywanie TypeScriptu, który w porównaniu z JavaScriptem o wiele lepiej spisuje się jako język programowania profesjonalnych aplikacji internetowych. Ten framework zapewnia również możliwość korzystania z wielu nowoczesnych bibliotek, dzięki którym w łatwy sposób można tworzyć i rozwijać zaawansowane, atrakcyjne aplikacje.", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Nie tłumacz się, działaj! Odkryj moc samodyscypliny", "Pomyśl o swoim celu w życiu. Czy chciałbyś zarabiać dwa razy więcej? Spłacić kredyt? A może schudnąć? Zapewne nie tylko tego pragniesz, ale nawet wiesz, co musisz zrobić, żeby to osiągnąć. I planujesz to zrobić… kiedyś. Jednak zanim się do tego faktycznie weźmiesz, dochodzisz do wniosku, że należy Ci się krótki wypad w wyimaginowane miejsce, zwane wyspą Kiedyś.", 7));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Zwinne wytwarzanie oprogramowania. Najlepsze zasady, wzorce i praktyki", "Czasy kaskadowego tworzenia projektów odchodzą w niepamięć. Obecne tempo rozwoju aplikacji i rynku nie pozwala poświęcać miesięcy na analizę, tworzenie dokumentacji, projektowanie, a na końcu wytwarzanie, testowanie i wdrażanie. Produkt musi być dostępny błyskawicznie! Pozwala to na natychmiastowe zebranie opinii na jego temat, dostosowanie go do oczekiwań i szybkie reagowanie na wymagane zmiany. Takie założenia może spełnić tylko i wyłącznie zespół wytwarzający oprogramowanie w zwinny sposób!", 1));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Java. Techniki zaawansowane. Wydanie XI", "Java jest dojrzałym językiem programowania, który pozwala na pisanie kodu dla wielu rodzajów komputerów służących do różnych celów i działających na różnych platformach. Jest świetnym wyborem dla programistów, którym zależy na tworzeniu bezpiecznych aplikacji o wyjątkowej jakości. Wokół Javy skupia się duża społeczność, dzięki której język ten wciąż się rozwija, unowocześnia i wzbogaca o nowe elementy. Osoby, które swoje zawodowe życie wiążą z pisaniem programów w Javie, muszą poznać zaawansowane zagadnienia i mniej oczywiste funkcjonalności Javy, również te niedawno zaimplementowane. To konieczność dla każdego profesjonalnego programisty Javy.", 1));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "WordPress 5 dla początkujących", "Marzysz o własnej stronie internetowej, ale brakuje Ci umiejętności informatycznych? WordPress to popularne narzędzie, które umożliwi Ci zaistnienie w sieci! Przeznaczone pierwotnie do obsługi blogów, aktualnie jest używane przez miliony użytkowników do prowadzenia prostych stron internetowych, a przez korporacje do promocji oraz sprzedaży usług i produktów. WordPress nieustannie ewoluuje, a jego najnowsza wersja, rozbudowana o nowy edytor treści - Gutenberg, pomoże Ci w kilku krokach stworzyć nowoczesną stronę. Niezależnie od tego, czy marzysz o karierze profesjonalnego administratora serwisów internetowych, czy po prostu chcesz zaprezentować swoją firmę, twórczość lub własny projekt w internecie, z pewnością warto bliżej poznać ten CMS.", 1));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Git. Rozproszony system kontroli wersji", "Praca nad niemal każdym projektem informatycznym wymaga współdziałania wielu osób, często pracujących z dala od siebie. W takich warunkach bardzo łatwo popełnić błąd, nadpisać jakiś ważny plik albo przypadkowo zdublować dane. Mały projekt po takiej wpadce da się jeszcze uratować, ale większy… można wyrzucić do kosza. Chyba że od momentu jego inicjalizacji używamy narzędzia odpowiedzialnego za właściwą synchronizację danych, czyli systemu kontroli wersji, co jest standardem we współczesnej informatyce. Jednym z takich programów jest git, napisany na potrzeby zarządzania kodem źródłowym jądra systemu Linux - taka rekomendacja mówi sama za siebie.", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Schematy elektroniczne i elektryczne. Przewodnik dla początkujących.", "Zawsze marzyłeś o zbudowaniu własnego układu elektronicznego, a lutownica nie jest Ci obca? Już czas, byś przystąpił do dzieła! Jeśli jednak setki linii, dziwnych znaczków i opisów przyprawiają Cię o zawrót głowy i masz problem z odczytaniem schematu układu elektronicznego, koniecznie zajrzyj do tej książki!", 2));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "DDD dla architektów oprogramowania", "Sprawne budowanie dużych systemów oprogramowania jest nie lada wyzwaniem, zwłaszcza gdy trzeba spełnić specyficzne wymagania biznesowe. Programowanie dziedzinowe, zwane w skrócie DDD, jest nowatorskim podejściem do projektowania architektury oprogramowania, pozwalającym na szybkie uzyskiwanie pożądanych efektów. Wielu architektów stosuje DDD wyłącznie jako techniczny zbiór narzędzi i nie wykracza poza wykorzystywanie wzorców taktycznych. Tymczasem dopiero pełne wykorzystanie strategicznych wzorców projektowych DDD pozwoli na prawdziwie skuteczne projektowanie skomplikowanych systemów oprogramowania.", 6));
            this._context.Book.Add(new BookEntity(Guid.NewGuid(), "Zespół wygrany czy przegrany? W co grają ludzie w firmach", "Marzysz o przełożonym, który zbuduje u Ciebie autorytet i zapyta ludzkim głosem o życie w pracy, a nie tylko o błędy i kejpiaje? Chcesz być wiarygodnym liderem, za którym zespół pójdzie w ogień? Jesteś zmęczony korpopląsami, manipulacjami, brakiem sensu w pracy, nieautentycznością szefa lub członków zespołu? Nie jesteś sam.", 2));
            
            this._context.SaveChanges();
        }
    }
}
