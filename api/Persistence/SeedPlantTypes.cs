using API.Core;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class SeedPlantTypes
    {
        public static async Task SeedData(DataContext context)
        {

            var monthWeekMap = context.MonthWeeks.ToDictionary(x => (x.Month, x.Week));
            var plants = new List<PlantType>
            {
                new PlantType
                {
                    Name = "Rajče",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)] },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "tomato.jpg",
                    Description = "Rajče jedlé, též lilek rajče (Solanum lycopersicum) je trvalka bylinného charakteru pěstovaná jako jednoletka." +
                    " Patří do čeledi lilkovitých. Pochází ze Střední a Jižní Ameriky. Plodem je bobule zvaná rajče, původně rajské jablko, " +
                    "proto se rajče řadí mezi plodovou zeleninu, ale jsou spekulace o tom, že rajče je ovoce.",
                    MinTemperature = 10,
                    PlantHeight = 120,
                    PlantSpace = 45,
                    RowSpace = 90
                }
                ,
                new PlantType
                {
                    Name = "Lilek",
                    DirectSewing = false,
                    PreCultivation =true,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)]
                    },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)]},
                    CropRotation = 1,
                    ImageSrc = "lilek.jpg",
                    Description = "Lilek vejcoplodý (Solanum melongena), jinak také baklažán, " +
                    "je jednoletá rostlina z rodu lilek (příbuzná s bramborem a rajčetem), z čeledi lilkovité. Dorůstá až jednometrové výšky. " +
                    "Květy jsou nachové až světle fialové. Plodem jsou červenofialové bobule používané " +
                    "jako plodová zelenina a označované jako lilek.",
                    MinTemperature = 10,
                    PlantHeight = 100,
                    PlantSpace = 40,
                    RowSpace = 50
                },
                new PlantType
                {
                    Name = "Hrách",
                    DirectSewing = true,
                    PreCultivation =false,
                    GerminationTemp = 4,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)]
                    },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)]},
                    CropRotation = 3,
                    ImageSrc = "radim.jpg",
                    Description = "Hrách setý (Pisum sativum) je hospodářsky významná rostlina z čeledi bobovitých (Fabaceae). " +
                    "Hrách je jednoletá, popínavá rostlina se sbíhavými a prorostlými listy. Kvete od dubna do října. Plody jsou lusky, " +
                    "obsahují dužnatá semena zvaná hrášky. " +
                    "Nezralé hrášky či celé lusky se používají jako zelenina (hrášek), zralá semena (hrách) se používají jako luštěnina. " +
                    "Původem je z východního Středomoří. Jinak se pěstuje na polích, kde jen velmi zřídka zplaňuje.\r\n\r\nHrách je důležitá " +
                    "luštěnina, " +
                    "pěstuje se hlavně kvůli chutným plodům, které obsahují vitamíny (hlavně skupiny B). Ve větším množství obsahuje " +
                    "také minerální látky, zvláště fosfor a draslík, ale i vápník a hořčík.\r\n\r\nHrách je rostlina původem ze Středomoří, " +
                    "která se během neolitické revoluce rozšířila po celé Evropě. " +
                    "V Čechách patří k nejstarším doloženým pěstovaným rostlinám[1].\r\n\r\n" +
                    "Hrách má hypogeické klíčení (dělohy zůstávají pod zemí) a proto musí mít hlubší výsev.",
                    MinTemperature = 4,
                    PlantHeight = 60,
                    PlantSpace = 5,
                    RowSpace = 15
                },
               new PlantType
                {
                    Name = "Ředkvička",
                    DirectSewing = true,
                    PreCultivation = false,
                    GerminationTemp = 12,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)]
                    },
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]} ,
                    CropRotation = 3,
                    ImageSrc = "lidka.jpg",
                    Description = "Ředkvička je kořenová zelenina botanicky klasifikovaná jako varieta ředkev setá letní " +
                    "(Raphanus sativus var. sativus). Kořen je kulovitý nebo válcovitý, různě zbarvený. Barva se pohybuje od bílé " +
                    "až k červeným nebo fialově zabarveným. Existují i odrůdy červenobílé nebo žluté kulaté a bílé protáhlé. Dužnina bílá," +
                    " u červených ředkviček někdy s nádechem do růžova, u starších kusů se skelným nádechem. Chuť ředkvičky je pálivá, někdy" +
                    " vodová – závisí obecně na zálivce a počasí během vegetace. Prodává se na tržištích na jaře a na podzim ve svazečcích," +
                    " někdy též loupaná. Ředkvička pěstovaná volně na venkovním záhonu při dlouhých letních dnech vyhání do květu a bulva " +
                    "je pak malá a pálivá.",
                    RepeatedPlanting = 14,
                    MinTemperature = 4,
                    PlantHeight = 15,
                    PlantSpace = 5,
                    RowSpace = 15
               },
               new PlantType
                {
                    Name = "Dýně",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                    },
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]},
                    CropRotation = 1,
                    ImageSrc = "hokkaido.jpg",
                    Description = "Dýně Hokkaido je původem z Japonska a v současné době se jedná o velice oblíbenou odrůdu tykve.\r\n\r\n" +
                    "Její plody jsou 20–25 cm velké a váží 1–2 kg. Velkou předností je vysoký podíl dužiny oproti semeníku.\r\n\r\n" +
                    "Další její výhodou je dlouhá skladovatelnost. Při dobrých podmínkách vydrží v chladu a temnu i celou zimu.\r\n\r\n" +
                    "Dýně Hokkaido má v kuchyni široké využití. Její dužina je velmi chutná, sladká a před zpracováním není nutné dýni loupat."+ 
                    "Slupka, stejně jako samotná dužina, obsahuje velké množství vitamínů a minerálů a během tepelné úpravy rychle měkne.",
                    RepeatedPlanting = 14,
                    MinTemperature = 10,
                    PlantHeight = 50,
                    PlantSpace = 100,
                    RowSpace = 200
                },
                new PlantType
                {
                    Name = "Fazol keříčkový",
                    DirectSewing = true,
                    PreCultivation = false,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)]
                    },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 3,
                    ImageSrc = "fazol.jpg",
                    Description = ""
                },
                new PlantType
                {
                    Name = "Mangold",
                    DirectSewing = true,
                    PreCultivation = false,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)]
                    },
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "mangold.jpg",
                    Description = "Mangold čili řepa cvikla (Beta vulgaris var. cicla) je kultivar řepy obecné používaný jako zelenina a pocházející původně ze Středomoří.\r\n\r\n" +
                    "Tato rostlina obsahuje dostatek vitaminu C, který může klesnout neopatrným zpracováváním. Dále obsahuje vitamín A, B, E a minerální látky, jako je například vápník – až 2 %, " +
                    "železo, fosfor, draslík a hořčík. Jinak obsahuje asi 2,5 % bílkovin, 87–92 % vody a dále cukry, které mu dávají lehce nasládlou chuť."
                },
                new PlantType
                {
                    Name = "Pak Choi",
                    DirectSewing = true,
                    PreCultivation = false,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {


                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],
                    },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "pak_choi.jpg",
                    Description = "Čínské, bok čoj nebo pak čoj zelí, pchin-jinem též bok choy (Brassica chinensis) pochází z východní Asie, jedná se o významnou zeleninu v jižní a střední Číně a v Japonsku. " +
                    "Existuje značně velké množství různých typů a forem, které se liší nejen vzhledem a velikostí, ale i hospodářskými vlastnostmi a využitím.[1]" +
                    "Je to jednoletá rostlina, jež tvoří nehlávkující listovou růžici z řapíkatých, tmavě zelených lesklých listů. Jejich řapíky jsou dužnaté, bílé a žlábkovité, " +
                    "u některých odrůd velmi široké.[2] Listová čepel je tuhá, lesklá, různě zbarvená, s hladkým nebo zoubkovaným okrajem, bublinatá nebo zkadeřená.[1]\r\n\r\nČínské zelí se na rozdíl od pekingského dá pěstovat celoročně, jelikož se nekonzumují hlávky, ale listy. Listy mladých rostlin lze sklízet už za 3 týdny."
                },
                new PlantType
                {
                    Name = "Mrkev",
                    DirectSewing = true,
                    PreCultivation = false,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {


                        monthWeekMap[(Month.February, 2)],
                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)],

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)]
                    },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 2,
                    ImageSrc = "mrkev_jeanette.jpg",
                    Description = "Mrkev obecná (Daucus carota) je rostlina z čeledi miříkovitých, pěstovaná jako kořenová zelenina. Blízkým příbuzným mrkve je pastinák."
                },
                new PlantType
                {
                    Name = "Kapusta",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                    },
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)],

                        monthWeekMap[(Month.November, 1)],
                        monthWeekMap[(Month.November, 2)],
                        monthWeekMap[(Month.November, 3)],
                        monthWeekMap[(Month.November, 4)],

                        monthWeekMap[(Month.December, 1)],
                        monthWeekMap[(Month.December, 2)],
                        monthWeekMap[(Month.December, 3)],
                        monthWeekMap[(Month.December, 4)],

                        monthWeekMap[(Month.January, 1)],
                        monthWeekMap[(Month.January, 2)],
                        monthWeekMap[(Month.January, 3)],
                        monthWeekMap[(Month.January, 4)]
                    },
                    CropRotation = 1,
                    ImageSrc = "kapusta.jpg",
                    Description = "Kapusta neboli brukev je české označení pro několik druhů dvouleté košťálové zeleniny. " +
                    "Moravské označení je kél či kel. První zmínky z historie kapusty jsou ze středozemní kultury. " +
                    "Kapustu pěstovali již Egypťané, kteří znali jednoduché druhy kapusty. " +
                    "Dále se pak v historii lidstva kapusta objevuje koncem středověku. " +
                    "V 16. a 17. století už se vědělo o kapustě a jejích blahodárných účincích na lidský organismus. " +
                    "V té době už se odrůdy podobaly těm dnešním. V novověku se hojně začala kapusta pěstovat a šlechtit." +
                    " Nejvíce podobná starým odrůdám je dnešní kapusta hlávková. V dnešní době je pěstování rozšířené po celém světě, " +
                    "nejvíce však v Evropě."
                },
                new PlantType
                {
                    Name = "Kedluben",
                    DirectSewing = true,
                    PreCultivation = true,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],

                    },
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                    },
                    CropRotation = 1,
                    ImageSrc = "kedluben_f.jpg",
                    Description = "Kedluben nebo kedlubna (Brassica oleracea var. gongylodes), někdy nesprávně nazývána jen brukev, " +
                    "je vyšlechtěnou varietou druhu brukev zelná a řadí se mezi " +
                    "nejžádanější košťálové zeleniny, její původní forma se ve volné přírodě nevyskytuje."
                },

                new PlantType
                {
                    Name = "Salát",
                    DirectSewing = true,
                    PreCultivation = true,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)]
                    },
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)]

                    },
                    CropRotation = 3,
                    ImageSrc = "lettuce.jpg",
                    Description = "Salát, odbornĕ locika setá nebo locika salátová (Lactuca sativa L.) je listová zelenina původem snad z Asie. " +
                    "Do střední Evropy se dostala ve středověku ze Středozemí. Vyskytuje se pouze v kultuře a je známo mnoho variet, či" +
                    " kultivarů různých tvarů a barev listů. Locika se obvykle pěstuje jako salátová, tedy listová zelenina a jako taková " +
                    "je rozšířena po celém světě."
                },
                new PlantType
                {
                    Name = "Špenát",
                    DirectSewing = true,
                    GerminationTemp = 5,
                    SewingMonths = new List<MonthWeek> {


                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)],

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                         monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]

                    },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],


                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],


                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)],

                        monthWeekMap[(Month.November, 1)],
                        monthWeekMap[(Month.November, 2)],
                        monthWeekMap[(Month.November, 3)],
                        monthWeekMap[(Month.November, 4)]

                    },
                    CropRotation = 3,
                    ImageSrc = "spenat.jpg",
                    Description = "Špenát setý (Spinacia oleracea) je druh jedlé krytosemenné rostliny z čeledi laskavcovitých. Je to jednoletá rostlina. " +
                    "Jedná se o důležitou listovou zeleninu. Kultivována byla v jihozápadní Asii, patrně v Persii. Samotný název je odvozován z perského Esfenadž (اسفناج). " +
                    "Přes Sýrii a Arábii se dostal do severní Afriky, odkud se dostává kolem roku 1100 do Španělska a dále se pak šíří po Evropě. " +
                    "První recepty, ve kterých se používá špenát, jsou dochovány v kuchařské knize z roku 1390."
                },
                new PlantType
                {
                    Name = "Pór",
                    DirectSewing = true,
                    GerminationTemp = 10,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)]


                    },
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)],

                        monthWeekMap[(Month.November, 1)],
                        monthWeekMap[(Month.November, 2)],
                        monthWeekMap[(Month.November, 3)],
                        monthWeekMap[(Month.November, 4)],

                        monthWeekMap[(Month.December, 1)],
                        monthWeekMap[(Month.December, 2)],
                        monthWeekMap[(Month.December, 3)],
                        monthWeekMap[(Month.December, 4)],

                        monthWeekMap[(Month.January, 1)],
                        monthWeekMap[(Month.January, 2)],
                        monthWeekMap[(Month.January, 3)],
                        monthWeekMap[(Month.January, 4)],

                        monthWeekMap[(Month.February, 1)],
                        monthWeekMap[(Month.February, 2)],
                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)]

                    },
                    CropRotation = 1,
                    ImageSrc = "por.jpg",
                    Description = "Pór zahradní (Allium porrum) je druh zeleniny z čeledi amarylkovitých. " +
                    "Z botanického hlediska patří do rodu česnek (Allium). Někteří autoři ho uvádí pod jménem jeho " +
                    "divokého předka Allium ampeloprasum var. porrum, jiní ho považují za samostatný kulturní druh Allium porrum."
                },
                new PlantType
                {
                    Name = "Kukuřice",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)] },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]
                    },
                    CropRotation = 1,
                    ImageSrc = "bantam.jpg",
                    Description = "Kukuřice setá (Zea mays) je druh jednoděložné rostliny z čeledi lipnicovitých (Poaceae). " +
                    "Český název kukuřice patří mezi novotvary vytvořené v 19. století Janem Svatoplukem Preslem."
                },
                new PlantType
                {
                    Name = "Meloun",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 18,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.April , 2)],
                        monthWeekMap[(Month.April , 3)],
                        monthWeekMap[(Month.April , 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)] },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]},
                    CropRotation = 1,
                    ImageSrc = "arava.jpg",
                    Description = "Meloun (slovo pochází z řečtiny a znamená „zralé jablko“) je druh plodové zeleniny patřící do " +
                    "čeledi tykvovitých, běžně ale bývají plody se sladkou dužinou řazeny mezi ovoce. Z botanického hlediska " +
                    "je meloun bobule. Na světě se pěstuje mnoho druhů melounů, jež mají různou barvu i tvar."

                },
                new PlantType
                {
                    Name = "Cuketa",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.April , 2)],
                        monthWeekMap[(Month.April , 3)],
                        monthWeekMap[(Month.April , 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)] },
                    HarvestMonths = new List<MonthWeek> {
                         monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],},
                    CropRotation = 1,
                    Description = "Cuketa (také cukina nebo cukína[1]) je kultivar jednoleté plodové zeleniny řadící se k druhu tykev obecná (Cucurbita pepo)," +
                    " která pochází ze Střední Ameriky. Cuketa je však evropského původu, vznikla šlechtěním v Itálii. " +
                    "Běžnou odrůdou cukety je například Cucurbita pepo ‚Nefertiti‘.",
                    ImageSrc = "paladin.jpg"
                },
                new PlantType
                {
                    Name = "Paprika",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 28,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)],

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)]  },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]},
                    CropRotation = 1,
                    ImageSrc = "korosko.jpg",
                    Description = "Paprika (Capsicum) je rod rostlin z čeledi lilkovité (Solanaceae). Jsou to vytrvalé keře nebo i malé stromy" +
                    " s jednoduchými střídavými listy a pravidelnými pětičetnými květy, které jsou opylované hmyzem. " +
                    "Plodem je dužnatá bobule. Semena v přírodě rozšiřují ptáci. Rod zahrnuje asi 42 druhů a pochází z " +
                    "tropické a subtropické Ameriky, kde je rozšířen od jihu USA po Argentinu. Papriky mají dlouhou kulturní historii," +
                    " sahající tisíce let do minulosti, a byly široce domestikovány dávno před objevením Ameriky. "
                },
                new PlantType
                {
                    Name = "Červená řepa",
                    DirectSewing = true,
                    PreCultivation = false,
                    GerminationTemp = 8,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)]},
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]},
                    CropRotation = 2,
                    ImageSrc="repa_kulata.jpg",
                    Description = "Řepa salátová je polopozdní, výnosná odrůda, která je odolná vůči chorobám. " +
                    "Je vhodná pro přímou konzumaci, konzervaci i tepelné zpracování.\r\n\r\n" +
                    "Řepa je velice zdravá zelenina. Obsahuje velké množství vitamínů B, C a provitamínu A, dále pak minerálů, antioxidantů a stopových prvků."
                },
                new PlantType
                {
                    Name = "Okurka",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 22,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)]},
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    Description = "Okurka (Cucumis), též meloun, je rod rostlin z čeledi tykvovité. Jsou to plazivé nebo popínavé byliny s" +
                    " jednoduchými střídavými listy a žlutými pětičetnými květy. Plodem je dužnatá bobule. Rod zahrnuje asi 60 druhů a je " +
                    "rozšířen v tropech a subtropech Starého světa. Nejvíce druhů roste v Africe. Některé kulturní druhy zdomácněly i v Americe. " +
                    "Květy jsou opylovány zejména včelami. Některé druhy mají zajímavé způsoby šíření semen. Hospodářsky nejvýznamnějším druhem" +
                    " je okurka setá a meloun cukrový, v tropech se jako plodová zelenina pěstuje také kiwano a angurie. Řada divoce rostoucích " +
                    "druhů je jedovatá.",
                    ImageSrc  = "superstar.jpg"
                },
                new PlantType
                {
                    Name = "Česnek",
                    DirectSewing = true,
                    PreCultivation =false,
                    GerminationTemp = 9,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.November, 1)],
                        monthWeekMap[(Month.November, 2)],
                        monthWeekMap[(Month.November, 3)],
                        monthWeekMap[(Month.November, 4)],

                        monthWeekMap[(Month.December, 1)],
                        monthWeekMap[(Month.December, 2)],
                        monthWeekMap[(Month.December, 3)],
                        monthWeekMap[(Month.December, 4)]},
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)]},
                    CropRotation = 2,
                    Description = "Česnek kuchyňský (Allium sativum), též česnek setý, je druh celosvětově známého koření[1] z čeledi amarylkovitých.",
                    ImageSrc  = "topaz.jpg"
                },
                new PlantType
                {
                    Name = "Petržel kořenová",
                    DirectSewing = true,
                    PreCultivation = false,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)]
},
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)],

                        monthWeekMap[(Month.November, 1)],
                        monthWeekMap[(Month.November, 2)],
                        monthWeekMap[(Month.November, 3)],
                        monthWeekMap[(Month.November, 4)]
                    },
                    CropRotation = 2,
                    Description = "Petržel (Petroselinum) je rod dvouletých rostlin z čeledi miříkovitých (Apiaceae), jehož zástupci mají široké využití v potravinářství. " +
                    "Pochází z východního Středozemí a rozšířila se do celého mírného pásma.\r\n\r\n" +
                    "Tak jako většina miříkovitých jsou petržele dvouleté rostliny, které první rok vytvářejí přízemní růžici listů a shromažďují zásoby " +
                    "ve ztlustlém hlavním kořeni, aby druhý rok vyhnaly mohutnou lodyhu s okoličnatým květenstvím, plodem je nažka. Nejznámější druhy jsou petržel " +
                    "zahradní (Petroselinum crispum) a petržel zahradní italská (Petroselinum /crispum/ neapolitanum), u níž není úplně jasné, je-li samostatným druhem, " +
                    "nebo spíše poddruhem (druhá možnost je zmiňována častěji)",
                    ImageSrc  = "korenova_petrzel.jpg"
                },
                new PlantType
                {
                    Name = "Celer",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)],

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)]


                    },
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]
                    },
                    CropRotation = 1,
                    ImageSrc = "rapikaty.jpg",
                    Description = "Miřík celer (Apium graveolens) je dvouletá bylina z čeledi miříkovité (Apiaceae). Je pěstována jako kořenová zelenina pro své bulvy a listy. Listy, zvláště jejich řapíky, se vybělují, aby měly křehčí chuť."
                },
                new PlantType
                {
                    Name = "Cibule",
                    DirectSewing = true,
                    PreCultivation = true,
                    GerminationTemp = 10,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)]


                    },
                    HarvestMonths = new List<MonthWeek> {


                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)]
                    },
                    CropRotation = 2,
                    ImageSrc = "cibule.jpg",
                    Description = "Jedná se o dvouletou až vytrvalou rostlinu, na bázi s velkou cibulí. " +
                    "Stonek je dosti robustní, dole až 3 cm v průměru, je dutý. Listy jsou jednoduché, přisedlé, s listovými pochvami. " +
                    "Čepele jsou celokrajné, polooblé se souběžnou žilnatinou. Květy jsou oboupohlavní, ve vrcholovém květenství, jedná se o " +
                    "hlávkovitě stažený zdánlivý okolík, ve skutečnosti to je stažené vrcholičnaté květenství zvané šroubel. " +
                    "Květenství je podepřeno toulcem. Pacibulky jsou v květenství přítomny jen někdy. Okvětí se skládá ze 6 okvětních lístků bílé až " +
                    "narůžovělé barvy, se středním zeleným pruhem. Tyčinek je 6. Gyneceum je složeno ze 3 plodolistů, je synkarpní, semeník je svrchní." +
                    " Plodem je tobolka."
                },
                new PlantType
                {
                    Name = "Brokolice",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)]
                    },
                    HarvestMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]

                    },
                    CropRotation = 1,
                    ImageSrc = "brokolice.jpg",
                    Description = "Brokolice (Brassica oleracea var. botrytis italica) je jedlá rostlina druhu brukev zelná (Brassica oleracea), " +
                    "která je druhem kapusty a příbuzná květáku. Jde o jednoletou i dvouletou rostlinu.[1] " +
                    "Pochází z oblasti Středomoří. Pěstuje se pro dužnaté stonky s růžicemi. Může se konzumovat syrová nebo dušená."
                },
                new PlantType
                {
                    Name = "Květák",
                    DirectSewing = false,
                    PreCultivation = true,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)]
                        },
                    HarvestMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]

                    },
                    CropRotation = 1,
                    ImageSrc = "kvetak_pozdni.jpg",
                    Description = "Květák neboli lidově karfiol (Brassica oleracea convar. botrytis) je oblíbenou košťálovou zeleninou, " +
                    "kterou člověk získal vyšlechtěním divoké brukve zelné (stejně jako např. kedluben, zelí či kapustu). " +
                    "V případě květáku využíváme jako zeleninu zdužnatělé květenství. Patří mezi jednoleté rostliny."
                },

                new PlantType
                {
                    Name = "Bylinky",
                    DirectSewing = true,
                    PreCultivation = true,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.February, 1)],
                        monthWeekMap[(Month.February, 2)],
                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)],

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)]

                        },
                    HarvestMonths = new List<MonthWeek> {
                         monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]

                    },
                    CropRotation = 1,
                    ImageSrc = "herbs.jpg",
                    Description = ""
                }
                ,
                new PlantType
                {
                    Name = "Ostatní",
                    DirectSewing = true,
                    PreCultivation = true,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.February, 1)],
                        monthWeekMap[(Month.February, 2)],
                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)],

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)]

                        },
                    HarvestMonths = new List<MonthWeek> {
                         monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]

                    },
                    CropRotation = 1,
                    ImageSrc = "others.jpg",
                    Description = ""
                }
            };

            
            await context.PlantTypes.AddRangeAsync(plants);
            await context.SaveChangesAsync();

            plants.OrderBy(a=>a.Name).ToList();

            foreach (var plant in plants)
            {
                var keyCompanion = PlantsExtensions.CompanionPlants.FirstOrDefault(a => a.Key == plant.Name).Value;

                if (keyCompanion != null)
                {
                    var companions = keyCompanion.ToList();

                    foreach (var companion in companions)
                    {
                        if (companion != "")
                        {
                            var p = context.PlantTypes.Where(a => a.Name == companion).FirstOrDefault();
                            plant.CompanionPlantTypes.Add(p);
                            await context.SaveChangesAsync();
                        }
                    }

                }
                var keyAvoids = PlantsExtensions.AvoidPlants.FirstOrDefault(a => a.Key == plant.Name).Value;

                if (keyAvoids != null)
                {

                    var avoids = keyAvoids.ToList();

                    foreach (var avoid in avoids)
                    {
                        if (avoid != "")
                        {
                            var p = context.PlantTypes.Where(a => a.Name == avoid).FirstOrDefault();
                            plant.AvoidPlantTypes.Add(p);
                            await context.SaveChangesAsync();
                        }
                    }
                }
            }
        }
    }
}
