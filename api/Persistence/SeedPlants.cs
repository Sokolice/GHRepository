using api.Model;
using System.Linq;

namespace api.Persistence
{
    public class SeedPlants
    {
        public static async Task SeedData(DataContext context)
        {
            var monthWeekMap = context.MonthWeeks.ToDictionary(x => (x.Month, x.Week));
            var plants = new List<Plant>
            {
                /*new Plant
                {
                    Name = "Rajče keříčkové balkónové",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    ImageSrc = "kerickove.jpg",
                    Description = "Plody rajčete keříčkového jsou malé, červené, kulaté, o hmotnosti 15 g - 20 g. Vhodné pro pěstování v kontejnerech a truhlících na balkonech, kde působí velmi dekorativně. Na jedné rostlině dozraje 150 a více plodů."
                },
                new Plant
                {
                    Name = "Rajče keříčkové Marmande",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    ImageSrc = "marmande.jpg",
                    Description = "Rajče Marmande je velmi stará odrůda keříčkového rajčete, pocházejícího z jižní Francie. Rostlina dorůstá výšky do 60 cm a plodí velké, lehce zploštělé plody o hmotnosti do 200 g, které dozrávají do tmavě červené barvy." +
                    "\r\n\r\nOdrůda se hodí jak pro venkovní pěstování, tak pro pěstování ve sklenících či fóliovnících.\r\n\r\nOblíbená je pro svůj velký výnos a vynikající nasládlou chuť. Kromě toho je rajče Marmande typické masitou dužinou a malým množstvím semínek, takže se snadno krájí a hodí se k přípravě nejrůznějších pokrmů. Kromě přímé konzumace se hojně využívá ke konzervaci či přípravě omáček." +
                    "\r\n\r\nDoba zrání je přibližně 80 dní."
                },
                new Plant
                {
                    Name = "Rajče tyčkové Moneymaker",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    ImageSrc = "moneymaker.jpg",
                    Description = "Jedná se o ranou až poloranou tyčkovou odrůdu rajčete. Je určena pro pěstování ve skleníku nebo na zahradě.\r\n\r\n" +
                    "Odrůda Moneymaker je vysoká, mohutného vzrůstu a také velmi výnosná. Má větší plody o hmotnosti okolo 100 g s bohatou, plnou chutí. Plody jsou zároveň velice odolné vůči popraskání.\r\n\r\n" +
                    "Rajčata jsou určena k přímé konzumaci, případně je můžeme využít k doplnění pokrmů studené kuchyně."
                },
                new Plant
                {
                    Name = "Rajče tyčkové Supersweet",
                    IsHybrid = true,
                    DirectSewing = false,
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
                    ImageSrc = "supersweet.jpg",
                    Description = "Rajče Supersweet F1 je raná tyčková odrůda rajčete, kterou lze pěstovat ve skleníku, fóliovníku či na zahradě.\r\n\r\n" +
                    "Plodí chutná cherry rajčátka kulatého tvaru a sytě červené barvy. Na každém vijanu postupně dozrává až 30 plodů. Jedná se tedy o odrůdu velmi výnosnou.\r\n\r\n" +
                    "Plody mají plnou sladkou chuť a hmotnost do 20–30 g.\r\n\r\n" +
                    "Další výhodou je také vysoká rezistence rostliny vůči chorobám.\r\n\r\n" +
                    "Výborně se hodí k přípravě zeleninových pokrmů, obložených mís nebo na výrobu sušených rajčat."
                },
                new Plant
                {
                    Name = "Lilek český raný",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    Description = "Lilek český raný je teplomilná rostlina, která si u nás získává stále větší oblibu. Její původ byste našli v oblasti Číny.\r\n\r\n" +
                    "Jedná se o často pěstovanou odrůdu lilku, známou svým pevným lesklým povrchem, tmavě fialové barvy, a bílou dužinou. Květenství má bílou barvu a objevuje se od června do září. \r\n\r\n" +
                    "Tato odrůda je velice pevná a kompaktní, a je poměrně dobře přizpůsobena i na naše chladnější podnebí."
                }
               new Plant
                {
                    Name = "Rajče červené cherry",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {
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
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "cherry.jpg",
                    Description = "Jedná se o keříčkovou odrůdu rajčat, vyznačující se malými plody červené barvy, které mají vynikající šťavnatou chuť.\r\n\r\n" +
                    "Rajčátka je možné pěstovat na zahradě, ale i v truhlíku či květináči. Tato rajčátka se těší velké oblibě pro svou výbornou chuť a snadné pěstování.\r\n\r\n" +
                    "Výborně se hodí k přímé konzumaci, ale i k přípravě pokrmů, salátů či jen jako ozdoba obložených mís. Jsou velmi atraktivní na pohled a oblíbí se je především děti. U dospělých se těší rajčata oblibě hlavně kvůli svému blahodárnému vlivu na zdraví, neboť slouží jako prevence mnoha chorob."
                },
               new Plant
                {
                    Name = "Rajče Cerise koktejlové",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {
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
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "cerise.jpg",
                    Description = "Koktejlové rajče Cerise je středně raná tyčková odrůda rajčete. Jedná se o velmi sladkou odrůdu, s menšími kulatými plody červené barvy.\r\n\r\n" +
                    "Rostlina bývá obsypána velkým množstvím plodů a hodí se i pro pěstování v truhlících na balkónech či terasách.\r\n\r\n" +
                    "Plody jsou vhodné k přímé konzumaci nebo do salátů."
                },
               new Plant
                {
                    Name = "Hrách dřeňový pozdní Radim",
                    IsHybrid = false,
                    DirectSewing = true,
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
                    Description = "RADIM - pozdní odrůda s velkým zrnem zvlášť vhodná pro rozložení sklizní pro samozásobení. Dorůstá 60 - 70 cm, listy i palisty jsou větší, sytě zelené. " +
                    "Lusk je dlouhý, rovný, ostře zakončený s 8 - 9 středně velkými, tmavými zrny, HTS je 140g."
                },
               new Plant
                {
                    Name = "Rozmarýn",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 16,
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
                        monthWeekMap[(Month.June, 4)]
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
                    ImageSrc = "rozmaryn.jpg",
                    Description = "Stálezelená trvalka, keřovitého vzrůstu. Stonky se rozrůstají, zespoda dřevnatí, dosahuje výšky až 2 m. Listy jsou úzké a kvete drobnými, bílými či nachovými kvítky. " +
                    "Celá rostlina je výrazně aromatická. Jako koření se užívají listy jehličkovitého vzhledu, sušené i čerstvé, celé i drcené či jemně mleté. "
                },
               new Plant
                {
                    Name = "Hrách setý Kelvedon Wonder",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 4,
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
                        monthWeekMap[(Month.June, 4)]
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
                    ImageSrc = "kelvedon.jpg",
                    Description = "Hrách Zázrak z Kelvedonu je raná velkozrnná odrůda, vhodná pro postupnou sklizeň. Rostlina je nižšího vzrůstu, max. 30–60 cm, a je odolná vůči suchu.\r\n\r\n" +
                    "Plodí 8–9 cm dlouhé lusky s obsahem 6–8 zelených hrášků, které mají velice sladkou chuť.\r\n\r\n" +
                    "Vegetační doba je přibližně 67 dní."
                },
               new Plant
                {
                    Name = "Ředkvička Lidka",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 12,
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
                    ImageSrc = "lidka.jpg",
                    Description = "Odrůda, určená pro jarní a letní polní pěstování. Bulvička je karmínově červená, kulatá. Je značně odolná proti vybíhání do květu. Výsev od března. Vegetační doba od výsevu je 33 - 37 dní.",
                    RepeatedPlanting = 14
                },
               new Plant
                {
                    Name = "Dýně Hokkaido",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 4,
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
                    "Dýně Hokkaido má v kuchyni široké využití. Její dužina je velmi chutná, sladká a před zpracováním není nutné dýni loupat. Slupka, stejně jako samotná dužina, obsahuje velké množství vitamínů a minerálů a během tepelné úpravy rychle měkne."
                },
               new Plant
                {
                    Name = "Rajče divoké tyčkové Murmel BIO",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {
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
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "murmel.jpg",
                    Description = "Odrůda tyčkového divokého rajčete Rote Murmel v BIO kvalitě je oblíbenou odrůdou zejména pro lahodnou a sladkou chuť drobných rajčátek.\r\n\r\n" +
                    "Jedná se o ranou odrůdu původem z jihu Ameriky. Při včasném výsevu se tedy můžeme těšit na první úrodu již od července. \r\n\r\n" +
                    "Plody jsou drobné, s průměrem okolo 1 cm a hmotností pár gramů. Rostou v hroznech po 10 a více kusech.\r\n\r\n" +
                    "Odrůda má velmi kompaktní růst a je vhodná také k pěstování v balkonových nádobách.\r\n\r\n" +
                    "Stonky je možné zaštipovat pro zajištění vyšší úrody. Divoká rajčata vynikají svou odolností proti plísním a běžným chorobám rajčat.\r\n\r\n" +
                    "Doba zrání je přibližně 50–60 dní."
                },
                new Plant
                {
                    Name = "Bazalka",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {
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
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "bazalka.jpg",
                    Description = "Bazalky jsou stálezelené rostliny nebo keře s aromatickou vůní. Listy jsou obvykle jednoduché, vejčité nebo kopinaté. Květy oboupohlavné, s trubkovitým osově souměrným kalichem a výrazně dvoupyskatou korunou obvykle bílé nebo růžové barvy.[1]"
                },
                new Plant
                {
                    Name = "Fazol keříčkový",
                    IsHybrid = false,
                    DirectSewing = true,
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
                    Description = "Bazalky jsou stálezelené rostliny nebo keře s aromatickou vůní. Listy jsou obvykle jednoduché, vejčité nebo kopinaté. Květy oboupohlavné, s trubkovitým osově souměrným kalichem a výrazně dvoupyskatou korunou obvykle bílé nebo růžové barvy.[1]"
                }
                ,
                new Plant
                {
                    Name = "Petržel kadeřavá naťová",
                    IsHybrid = false,
                    DirectSewing = true,
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
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)]
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
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "petrzel_kad.jpg",
                    Description = "Petržel zahradní (latinsky Petroselinum crispum) je krytosemenná rostlina z čeledi miříkovitých.\r\n\r\n" +
                    "Pochází ze střední a východní oblasti Středomoří (Libanon, Izrael, Kypr, Turecko, jižní Itálie, Řecko, Portugalsko, Španělsko, Malta, Maroko, " +
                    "Alžírsko a Tunisko), ale naturalizována je různě v Evropě a je široce pěstována jako bylina a (kořenová) zelenina.\r\n\r\n" +
                    "Vyznačuje se pronikavou vůní a charakteristickou nasládlou chutí. Nať a kořen obsahují aromatický éterický olej, který poskytuje typickou vůni a chuť. " +
                    "Obsahuje větší množství vápníku, hořčíku, draslíku, vitamín C a provitamin A. Na vitamín C je mimořádně bohatá nať. Může se pěstovat po celý rok. Na trh se dodává nať, " +
                    "petržel s natí a petržel bez natě. Podle ČSN 46 4365 se petrželka a petržel s natí nabízejí pouze v jedné jakosti."
                },
                new Plant
                {
                    Name = "Mangold",
                    IsHybrid = false,
                    DirectSewing = true,
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
                new Plant
                {
                    Name = "Pak Choi Shanghai",
                    IsHybrid = false,
                    DirectSewing = true,
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
                new Plant
                {
                    Name = "Mrkev Jeanette",
                    IsHybrid = true,
                    DirectSewing = true,
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

                        monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],
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
                    Description = "Mrkev Jeanette F1 je produktivní odrůda, která Vás potěší velkou úrodou a vynikající chutí plodů. " +
                    "Při správné péči převýší uvedené odrůdové vlastnosti a doslova zasype úrodou. Vyžaduje péči: potřebujete zalévání, hnojení, o" +
                    "dstraňování plevele a kypření půdy. \r\n\r\n" +
                    "Zdroj: https://gradinamax.cz/product/mrkev-jeanette-f1"
                },
                new Plant
                {
                    Name = "Petržel hladkolistá naťová",
                    IsHybrid = false,
                    DirectSewing = true,
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
                        monthWeekMap[(Month.July, 4)],


                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)]
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
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "petrzel_hladkolista.jpg",
                    Description = "Petržel zahradní (latinsky Petroselinum crispum) je krytosemenná rostlina z čeledi miříkovitých.\r\n\r\n" +
                    "Pochází ze střední a východní oblasti Středomoří (Libanon, Izrael, Kypr, Turecko, jižní Itálie, Řecko, Portugalsko, Španělsko, Malta, Maroko, " +
                    "Alžírsko a Tunisko), ale naturalizována je různě v Evropě a je široce pěstována jako bylina a (kořenová) zelenina.\r\n\r\n" +
                    "Vyznačuje se pronikavou vůní a charakteristickou nasládlou chutí. Nať a kořen obsahují aromatický éterický olej, který poskytuje typickou vůni a chuť. " +
                    "Obsahuje větší množství vápníku, hořčíku, draslíku, vitamín C a provitamin A. Na vitamín C je mimořádně bohatá nať. Může se pěstovat po celý rok. Na trh se dodává nať, " +
                    "petržel s natí a petržel bez natě. Podle ČSN 46 4365 se petrželka a petržel s natí nabízejí pouze v jedné jakosti."
                },
                new Plant
                {
                    Name = "Koriandr",
                    IsHybrid = false,
                    DirectSewing = true,
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


                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]
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
                        monthWeekMap[(Month.September, 4)]},
                    CropRotation = 1,
                    ImageSrc = "koriandr.jpg",
                    Description = "Koriandr setý (Coriandrum sativum) je jednoletá rostlina z čeledi miříkovitých (Apiaceae), planě rostoucí ve Středomoří, odedávna pěstovaná v Indii a v Egyptě. " +
                    "Využívá se v gastronomii jako koření a dále i v léčitelství.\r\n\r\n" +
                    "Jedná se o jednoletou mrkvovitou bylinu, jejíž lodyha dosahuje výšky až jednoho metru a nahoře se větví. Spodní listy jsou jednoduše zpeřené a řapíkaté, " +
                    "horní listy přisedlé pochvou a zpeřené dvakrát až třikrát. Listy mají dělené, čárkovité úkrojky. Květy mají bílou či růžovou barvu, přičemž tvoří okolíky. " +
                    "Plod je kulatý a hnědožlutý. Koriandr kvete v období června a července." +
                    " Účinnými látkami jsou především silice a některé vitamíny skupiny B.[1]",
                    RepeatedPlanting = 14
                },
                new Plant
                {
                    Name = "Kapusta růžičková Casiopea",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)],

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)],

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
                    Description = "Růžičková kapusta je druh košťálové zeleniny vhodné ke konzumaci, kultivar brukve. Její listy jsou bohaté na základní živiny včetně vitaminu C.\r\n\r\n" +
                    "Tento druh zeleniny je odolný proti menším mrazům a proto vydrží na záhonu i přes zimu. Není náročný na pěstování. Obsahuje mnoho draslíku, manganu, vitaminu B1 " +
                    "a hlavně vlákniny, ale také síru, proto je třeba množství omezit. Má velice pozitivní vliv na zdraví a kondici."
                },
                new Plant
                {
                    Name = "Kedluben raný Purple Vienna",
                    IsHybrid = false,
                    DirectSewing = false,
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
                new Plant
                {
                    Name = "Salát listový k česání",
                    IsHybrid = false,
                    DirectSewing = true,
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
                    ImageSrc = "dubacek.jpg",
                    Description = "Salát Dubáček je odrůdou listového salátu, která tvarem svých listů připomíná dubové lístky.\r\n\r\n" +
                    "Odrůda je náchylná k vyšším teplotám, proto se doporučuje pěstování v jarních nebo podzimních měsících. " +
                    "Rostlina vytváří růžice světle zelených laločnatých listů, které mají lahodnou chuť a hodí se k přímé konzumaci."
                },
                new Plant
                {
                    Name = "Salát polní",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 5,
                    SewingMonths = new List<MonthWeek> {
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
                        monthWeekMap[(Month.February, 4)],

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)]

                    },
                    CropRotation = 3,
                    ImageSrc = "polnicek.jpg",
                    Description = "Kozlíček polní (Valerianella locusta) čili kozlíček polníček (lidově polníček) je drobná jednoletá bylina s vidlicovitě dělenou, " +
                    "10–30 cm vysokou lodyhou, jednoduchými listy a nenápadnými bělavými nebo modrými květy. Pěstuje se zemědělsky a listy prodávané pod lidovým názvem " +
                    "polníček se využívají jako listová zelenina např. pro přípravu salátu nebo jarních polévek."
                },
                new Plant
                {
                    Name = "Salát listový Lollo bionda",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 5,
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
                    CropRotation = 3,
                    ImageSrc = "salat_kaderavy.jpg",
                    Description = "Salát, odbornĕ locika setá nebo locika salátová (Lactuca sativa L.) je listová zelenina původem snad z Asie. " +
                    "Do střední Evropy se dostala ve středověku ze Středozemí.[1] Vyskytuje se pouze v kultuře a je známo mnoho variet, " +
                    "či kultivarů různých tvarů a barev listů. Locika se obvykle pěstuje jako salátová, tedy listová zelenina a jako taková je rozšířena po celém světě."
                }
                ,
                new Plant
                {
                    Name = "Salát hlávkový letní",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 5,
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
                    CropRotation = 3,
                    ImageSrc = "salat_hlavkovy.jpg",
                    Description = "Odrůda Dětenická atrakce je raná odrůda salátu určená pro letní pěstování z přímých výsevů. " +
                    "Plodí velké světle zelené hlávky, které jsou kulovité, pevné a velmi dobře uzavřené. Odrůda je středně odolná " +
                    "proti vybíhání do květu a chorobám, je tedy velmi vhodná pro postupnou sklizeň. Tento salát má skvělou chuť, " +
                    "vysokou biologickou hodnotu a j vhodný i v rámci dietního stravování. Má načervenalé listy, díky čemuž obsahuje i " +
                    "betakaroten a působí tak preventivně proti rakovině kůže. V listech se dále ukrývá velké množství chlorofylu, hořčíku a " +
                    "jeho pravidelná konzumace skvěle posiluje imunitní systém. Rostlina obsahuje vodu, bílkoviny, tuky a vlákniny, dále cenné minerální látky jako K, P, Ca, Mg, Fe, vitamín C, A, B1 a B2."
                },
                new Plant
                {
                    Name = "Špenát",
                    IsHybrid = false,
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
                new Plant
                {
                    Name = "Pór",
                    IsHybrid = false,
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
                new Plant
                {
                    Name = "Rukola",
                    IsHybrid = false,
                    DirectSewing = true,
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
                        monthWeekMap[(Month.July, 4)]

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
                    ImageSrc = "rukola.jpg",
                    Description = "Rukola při pěstování nevyžaduje žádnou speciální péči, bude jí vyhovovat slunné či polostinné stanoviště, " +
                    "ale pozor na přímé slunce. Vlivem přímého slunce ztrácí listy a rychleji vykvétá. Listy, které na ní v tomto prostředí zůstávají, " +
                    "mají intenzívní hořkou až pikantní chuť."
                },
                new Plant
                {
                    Name = "Máta",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {

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
                    ImageSrc = "mata.jpg",
                    Description = "Čerstvé listy můžeme trhat celé léto. Nať se stříhá těsně před květem, " +
                    "nejlépe v poledních hodinách, protože tehdy obsahuje nejvíc silic. Za vhodného letního počasí tato rostlina dorůstá a může se " +
                    "sklízet podruhé. Při umělém sušení nesmí teplota přesáhnout 35 stupňů Celsia, protože poté se silice ztrácí.[3] " +
                    "Sušenou mátu je potřeba skladovat ve vzduchotěsné nádobě, aby nezvlhla a neztratila své aroma."
                },
                new Plant
                {
                    Name = "Pažitka",
                    IsHybrid = false,
                    DirectSewing = true,
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
                        monthWeekMap[(Month.July, 4)],

                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)]
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
                    ImageSrc = "pazitka.jpg",
                    Description = "Pažitka pobřežní (Allium schoenoprasum, srov. maďarsky pázsit neboli pažit/trávník) " +
                    "neboli šnytlík (moravsky šnytlich, slezsky szńitloch – z německého Schnittlauch) je druh jednoděložné rostliny " +
                    "používané i jako zelenina z čeledi amarylkovitých. Z botanického hlediska patří do rodu česnek (Allium)."
                },
                new Plant
                {
                    Name = "Rajče tyčkové Gardeners Delight",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    ImageSrc = "delights.jpg",
                    Description = "Gardeners Delight je jedna z původních odrůd tyčkového cherry rajčete.\r\n\r\n" +
                    "Plodí počátkem července krásná šťavnatá rajčata o velikosti 2,5–4 cm.\r\n\r\n" +
                    "Odrůda Gardeners Delight je velmi stará a stále ceněná pro vynikající chuť svých plodů.\r\n\r\n" +
                    "Pěstujte na slunečném závětrném místě s oporou."
                },
                new Plant
                {
                    Name = "Divoké rajče Sweet Pea",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    ImageSrc = "sweet_pea.jpg",
                    Description = "Hráškové rajče (někdy také nazývané divoké či rybízové) je tyčková odrůda rajčat, která plodí drobné červené plody. " +
                    "Odrůda byla vypěstována za účelem vytvoření rostliny, ve které se bude snoubit malá velikost plodů s bohatou sladkou chutí. Vzhledem k této skutečnosti, je tato odrůda velice oblíbená.\r\n\r\n" +
                    "Plody jsou opravdu maličké – obvykle mají velikost 0,5–0,8 cm, s váhou přibližně do 5 gramů. Plody rostou v trsech po 10–12 kusech, může to být ale i více.\r\n\r\n" +
                    "Doba zrání je přibližně 65 dní."
                },
                new Plant
                {
                    Name = "Bio kukuřice cukrová Golden Bantam",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    Description = "Cukrová kukuřice Golden Bantam v BIO kvalitě je středně ranou odrůdou, kterou lze sklízet již začátkem srpna.\r\n\r\n" +
                    "Kukuřičné klasy jsou velké, žluté a velmi chutné, s typickou kukuřičnou texturou. Díky velkému množství vlákniny je kukuřice také nedílnou součástí zdravého stravování.\r\n\r\n" +
                    "Cukrová kukuřice Golden Bantam patří mezi tradiční odrůdy a byla oceněna nadací ProSpecieRara, která se zaměřuje na zachování tradičních a vzácných odrůd rostlin."
                },
                new Plant
                {
                    Name = "Rajče keříčkové Roma",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)],

                        monthWeekMap[(Month.April, 1)],
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)] },
                    HarvestMonths = new List < MonthWeek > {
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
                    ImageSrc = "roma.jpg",
                    Description = "Rajče Roma je středně raná odrůda keříčkových rajčat, která může dorůstat výšky až 70 cm. " +
                    "Plody jsou středně velké (váha do 40 g) a mají červenou barvu. Díky jejich oválnému tvaru jsou nazývány italskými švestkami.\r\n\r\n" +
                    "Plody jsou velmi chutné a aromatické. Hodí se jako příloha k jídlům či do salátů. Kromě toho se pro svou masitou dužinu využívají na omáčky, salsu či k sušení.\r\n\r\n" +
                    "Doba zrání je přibližně 75 dní."
                },
                new Plant
                {
                    Name = "Bio meloun Arava F1 Galia",
                    IsHybrid = true,
                    DirectSewing = false,
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
                    Description = "Melouny typu Galia jsou výnosné cukrové odrůdy sladké a aromatické chuti. Jedná se o hybrid žlutého melounu a melounu cantaloupe, který byl poprvé vypěstován v Izraeli.\r\n\r\n" +
                    "Meloun Arava F1 v BIO kvalitě má bílou až jemně nazelenalou dužinu a je výsledkem mnohaletého šlechtění v nejrůznějších pěstebních podmínkách. Odrůda je též odolná proti padlí.\r\n\r\n" +
                    "Zralé plody jsou žluté, intenzivně voní a postupně samy opadávají z rostliny. Arava F1 je ranou odrůdou, sklizeň za vhodných teplotních podmínek začíná již od poloviny července.\r\n\r\n" +
                    "Meloun Galia se využívá s oblibou do ovocných salátů, kde se kombinuje s kyselejšími druhy ovoce, neboť samotná jeho chuť je velmi specifická a hodně sladká. " +
                    "Dále je možné ho využít i do zeleninových salátů či v kombinaci s rybami nebo masem. Oblíbený je také jako přísada do koktejlů, smoothie a čerstvých džusů."

                },
                new Plant
                {
                    Name = "Cuketa Paladin F1",
                    IsHybrid = true,
                    DirectSewing = false,
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
                    Description = "Cuketa Paladin F1 je výnosná hybridní tykev. Vytváří pravidelné plody válcovitého tvaru, žluté barvy. \r\n\r\n" +
                    "Jedná se o ranou odrůdu, na jejíž úrodu se můžete těšit již od začátku července.\r\n\r\nPoužívá se k přímé konzumaci nebo i ke konzervaci. \r\n\r\n" +
                    "Plody váží kolem 1,5 kg. Rostlina je keříčkovitého, kompaktního vzrůstu. \r\n\r\n" +
                    "Doba zrání je cca 70 dní. ",
                    ImageSrc = "paladin.jpg"
                },
                new Plant
                {
                    Name = "Tykev muškátová F1",
                    IsHybrid = true,
                    DirectSewing = false,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {
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
                    ImageSrc = "muskatova.jpg",
                    Description = "Tykev Butterscotch je ranou a plazivou odrůdou muškátové tykve. " +
                    "Rostlina se vyznačuje mohutnými výhony, velkými listy a plody hruškovitého tvaru, které dozrávají do krémové až oranžové barvy.\r\n\r\n" +
                    "Váha plodů je 600–900 g a velikost může být 30–50 cm.\r\n\r\nDužina plodů je v době zralosti světle žlutá. V této fázi je tykev vhodná k přímé konzumaci. " +
                    "Později se mění na sytě oranžovou a je vhodná k tepelnému zpracování či konzervaci.\r\n\r\nJedná se o velmi chutnou odrůdu, která vyniká odolností proti padlí (PMT).\r\n\r\n" +
                    "Doba zrání je přibližně 95 dní."
                },
                new Plant
                {
                    Name = "BIO Paprika Korosko",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    Description = "BIO Paprika Korosko je oblíbená odrůda se špičatými, červenými plody o velikosti cca 5 x 16 cm a hmotnosti cca 60 g. \r\n\r\n" +
                    "Je to velice výnosná odrůda, vhodná k přímé konzumaci, plnění i grilování. Chuť je čerstvá, sladká. \r\n\r\n" +
                    "Jedná se o ranou odrůdu, vhodnou k pěstování ve skleníku, v květináči na balkóně či volně venku. \r\n\r\n" +
                    "Celkově rostlina dosahuje výšky kolem 100 cm. "
                },
                new Plant
                {
                    Name = "Meloun žlutý Bimbo F1",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 18,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.April, 2)],
                        monthWeekMap[(Month.April, 3)],
                        monthWeekMap[(Month.April, 4)] ,

                        monthWeekMap[(Month.May, 1)],
                        monthWeekMap[(Month.May, 2)],
                        monthWeekMap[(Month.May, 3)],
                        monthWeekMap[(Month.May, 4)]
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
                    ImageSrc = "bimbo.jpg",
                    Description = " Meloun Bimbo F1 je raná hybridní medová odrůda, která je velice odolná vůči padlí a virům. " +
                    "Vytváří až 2,5 kg velké plody žluté barvy s dobrou skladovatelností. \r\n\r\nMelouny se s oblibou pěstují pro svou výbornou chuť. " +
                    "Konzumují se v syrovém stavu a slouží jako zdravá pochutina, neboť jsou velice nízkokalorické a mají vysoký obsah vitamínů a vody.\r\n\r\n" +
                    "Ideální je tuto odrůdu si předpěstovat ve skleníku. "
                },
                new Plant
                {
                    Name = "Řepa salátová kulatá",
                    IsHybrid = false,
                    DirectSewing = true,
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
                    Description = "epa salátová je polopozdní, výnosná odrůda, která je odolná vůči chorobám. " +
                    "Je vhodná pro přímou konzumaci, konzervaci i tepelné zpracování.\r\n\r\n" +
                    "Řepa je velice zdravá zelenina. Obsahuje velké množství vitamínů B, C a provitamínu A, dále pak minerálů, antioxidantů a stopových prvků."
                },
                new Plant
                {
                    Name = "Rajče Aztek",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    Description = "Rajče Aztek je velmi výnosná odrůda keříčkových rajčat. " +
                    "Je ideální pro pěstování v truhlících či květináčích na balkónech. " +
                    "Rostliny jsou malého vzrůstu, přibližně do 35 cm, a působí v exteriéru velmi dekorativně.\r\n\r\n" +
                    "Tato odrůda plodí drobné žluté plody o váze 15–20 g. Rajčátka jsou kulatá s vynikající sladkou chutí, takže se oblibě těší především u dětí.\r\n\r\n" +
                    "Rajče Aztek je vhodné k přímé konzumaci a do studené kuchyně.\r\n\r\nDoba zrání je asi 70 dní.",
                    ImageSrc  = "aztek.jpg"
                },
                new Plant
                {
                    Name = "Ačokča",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 22,
                    SewingMonths = new List<MonthWeek> {
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
                    Description = "Jedná se o jednoletou rostlinu, známou také pod názvem divoká okurka, jejíž stonek dorůstá délky až 5 m.\r\n" +
                    "Rostlina je vhodná pro polní pěstování, neboť se bohatě větví. Důležité je poskytnout ji dostatečnou vertikální oporu. V našich klimatických podmínkách se jí daří poměrně dobře.\r\n\r\n" +
                    "Charakteristické jsou pro ni zvláštní plody, které jsou vzhledem podobné paprice a chutí naopak připomínají okurku. " +
                    "Plody jsou světle zelené barvy a dosahují délky 5–10 cm. Dužina plodu je bílá nebo lehce nazelenalá.\r\n\r\n" +
                    "Rostlina je oblíbená pro své blahodárné účinky na lidské zdraví – pomáhá bojovat proti cukrovce, snižuje cholesterol a vysoký krevní tlak. To vše ovšem pouze v syrovém stavu.\r\n\r\n" +
                    "Ačokču lze konzumovat syrovou, stejně jako jiné druhy zeleniny, nebo ji lze tepelně upravovat. " +
                    "Příprava je stejná jako u paprik. Kromě toho lze plody nakládat buď samostatně nebo v kombinaci s okurkami, cibulkami apod.",
                    ImageSrc  = "acokca.jpg"
                },
                new Plant
                {
                    Name = "Tykev špagetová",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 22,
                    SewingMonths = new List<MonthWeek> {
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
                    Description = "Tato tykev pochází z Japonska a svůj název získala díky své specifické dužině, která se po uvaření či s přibývající zralostí rozpadá na jednotlivá vlákna, připomínající špagety. " +
                    "Tato vlákna lze oddělit a ve vařeném stavu je podávat na způsob těstovin jako jejich nízkokalorickou variantu.\r\n\r\n" +
                    "Rostlina je plazivá, plodí oválné plody žluté barvy. Tykve dorůstají hmotnosti přibližně 2 kg.\r\n\r\n" +
                    "Doba zrání je okolo 90 dní.",
                    ImageSrc  = "spagetova.jpg"
                },
                new Plant
                {
                    Name = "Cuketa Costata Romanesco",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 20,
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
                    Description = "Costata Romanesco je středně raná italská keříčková odrůda s atraktivními plody. " +
                    "Ty jsou poměrně velké, jejich délka je okolo 40 cm. Ovšem ideální délka ke sklizni je okolo 20 cm. V té době mají cukety nejlepší chuť. \r\n\r\n" +
                    "Barva je světle zelená či žlutá s tmavě zelenými pruhy.\r\n\r\nChuť cukety Costata Romanesco je výtečná a právě tato odrůda je hojně využívána do mnoha italských receptů. " +
                    "Konzumovat lze plody i květy. Plody jsou vhodné k vaření, sušení nebo konzervování.\r\n\r\n" +
                    "Doba zrání je přibližně 50 dní. ",
                    ImageSrc  = "romanesco.jpg"
                },
                new Plant
                {
                    Name = "Okurka salátová Superstar F1",
                    IsHybrid = true,
                    DirectSewing = false,
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
                    Description = "Jedná se o odrůdu salátové okurky typu multifruit. Odrůda je vhodná k rychlení ve sklenících či fóliových krytech.\r\n\r\n" +
                    "Rostlina je středního vzrůstu, plodí 25–30 cm dlouhé tmavě zelené plody.\r\n\r\nOkurky mají jemnou chuť, jsou šťavnaté a geneticky nehořké. Jsou vhodné k přímé konzumaci.\r\n\r\n" +
                    "Doba zrání je přibližně 70 dní.\r\n\r\n" +
                    "Semena jsou mořená.",
                    ImageSrc  = "superstar.jpg"
                },
                new Plant
                {
                    Name = "Mrkev Táborská žlutá",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 7,
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
                        monthWeekMap[(Month.July, 4)],},
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
                        monthWeekMap[(Month.October, 4)]},
                    CropRotation = 2,
                    Description = "Mrkev Táborská žlutá je typická středně dlouhými, válcovitými kořeny. \r\n\r\n" +
                    "Dorůstají délky 12–26 cm, dužina je sytě žlutá, někdy žlutooranžová a zakončení pološpičaté.\r\n\r\n" +
                    "Odrůda je vysoce výnosná, a to 70–100 t/ha. Je často používána jako krmná mrkev.\r\n\r\n" +
                    "Vyznačuje se nízkým obsahem beta karotenu a středním obsahem cukru, proto je vhodná také při dietních opatřeních. \r\n\r\n" +
                    "Mrkev Táborská je odolná proti chorobám, také proti krátkodobému zamokření nebo suchu a vybíhání do květu.\r\n\r\n" +
                    "Semena jsou mořená.",
                    ImageSrc  = "taborska.jpg"
                },
                new Plant
                {
                    Name = "Sadbový česnek Topaz",
                    IsHybrid = false,
                    DirectSewing = true,
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
                    Description = "Sadbový česnek Topaz je poloraná odrůda ozimého paličáku.\r\n\r\n" +
                    "Topaz je odrůda pro podzimní výsadby s cibulkami kulovitého a pravidelného tvaru. Vnější suknice je bílá s fialovými pruhy, barva suknice stroužku je fialová.\r\n\r\n" +
                    "Jedna cibulka obsahuje obvykle kolem 8–11 stroužků. \r\n\r\n" +
                    "Odrůda je vysoce odolná proti virózám a vhodná k dlouhodobému skladování.",
                    ImageSrc  = "topaz.jpg"
                },
                new Plant
                {
                    Name = "Sadbový česnek Vekan",
                    IsHybrid = false,
                    DirectSewing = true,
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
                    Description = "Sadbový česnek odrůdy Vekan je oblíbená odrůda ozimého úzkolistého paličáku. \r\n\r\n" +
                    "Cibule dosahují středně velké velikosti, uspořádání stroužků v cibulovině je nepravidelné, průměrně obsahuje 8–12 stroužků. ",
                    ImageSrc  = "vekan.jpg"
                },
                new Plant
                {
                    Name = "Okurka salátová Jogger F1",
                    IsHybrid = true,
                    DirectSewing = false,
                    GerminationTemp = 22,
                    SewingMonths = new List<MonthWeek> {
                        monthWeekMap[(Month.April, 1)],
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
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]},
                    CropRotation = 1,
                    Description = "Jedná se o ranou hybridní odrůdu salátové okurky, která je vhodná jak pro polní pěstování, tak i pro pěstování ve sklenících či fóliových krytech. Rostliny jsou středně velkého vzrůstu a plodí dlouhé tmavě zelené plody, které dorůstají délky 20–22 cm. Povrch plodů je lehce bradavičnatý.\r\n\r\n" +
                    "Okurky jsou určeny k přímé konzumaci, hodí se k jakémukoliv běžnému zpracování.",
                    ImageSrc  = "jogger.jpg"
                },
                new Plant
                {
                    Name = "Kopr",
                    IsHybrid = false,
                    DirectSewing = true,
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
                        monthWeekMap[(Month.July, 4)]},
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
                        monthWeekMap[(Month.October, 4)]},
                    CropRotation = 23,
                    Description = "Kopr vonný je jednoletá, aromatická bylina, původem z východní části Středozemí, Indie, Ruska a západní Asie. " +
                    "Dorůstá výšky 60–150 cm. Kopr má tenký kořen a přímou, jemně rýhovanou dutou lodyhu modrozelené barvy. Střídavé listy jsou několikrát dělené do nitkovitých úkrojů. " +
                    "Už v biblických dobách se kopr používal jako platidlo. Židé z jeho pěstování odváděli naturální daně Římanům a ti si z kopru dělali věnečky. Kdysi nevěsty věřily, že když si do boty dají kopr, " +
                    "budou mít v tchynině domě moc nad vším.",
                    ImageSrc  = "kopr.jpg",
                    RepeatedPlanting = 14
                },
                new Plant
                {
                    Name = "Tymián obecný",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 20,
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
                        monthWeekMap[(Month.September, 4)],

                        monthWeekMap[(Month.October, 1)],
                        monthWeekMap[(Month.October, 2)],
                        monthWeekMap[(Month.October, 3)],
                        monthWeekMap[(Month.October, 4)]},
                    CropRotation = 23,
                    Description = "Tymián obecný je populární trvalka vysoká 40 cm. Sklízí se nať, která se seřezává 2–3x ročně vždy před plným rozkvětem.\r\n\r\n" +
                    "Tymián se používá čerstvý i sušený jako samostatné koření i do kořeninových směsí. Koření je skvělé pro dochucování nádivek, polévek a omáček. " +
                    "Výborné je s drůbežím masem a rybami.",
                    ImageSrc  = "tymian.jpg"
                }
                new Plant
                {
                    Name = "Petržel kořenová",
                    IsHybrid = false,
                    DirectSewing = true,
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
                new Plant
                {
                    Name = "Mangold Ampera F1",
                    IsHybrid = true,
                    DirectSewing = true,
                    GerminationTemp = 10,
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
                        monthWeekMap[(Month.July, 4)]


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
                    ImageSrc = "mangold_ampera.jpg",
                    Description = "Mangold čili řepa cvikla (Beta vulgaris var. cicla) je kultivar řepy obecné používaný jako zelenina a pocházející původně ze Středomoří.\r\n\r\n" +
                    "Tato rostlina obsahuje dostatek vitaminu C, který může klesnout neopatrným zpracováváním. Dále obsahuje vitamín A, B, E a minerální látky, jako je například vápník – až 2 %, " +
                    "železo, fosfor, draslík a hořčík. Jinak obsahuje asi 2,5 % bílkovin, 87–92 % vody a dále cukry, které mu dávají lehce nasládlou chuť."
                },
                new Plant
                {
                    Name = "Celer řapíkatý",
                    IsHybrid = false,
                    DirectSewing = false,
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
                    Description = "Řapíkatý celer je o něco méně aromatický než jeho bulvový příbuzný, o to je však křupavější. " +
                    "Tuto zeleninu si řada lidí oblíbila jako zdravou alternativu ke křupkám, chipsům apod. Řapíkatý celer lze jíst syrový i vařený. " +
                    "Můžete jej použít i jako příměs k zeleninovým a ovocným šťávám, kterým dodává zajímavou chuť. Z řapíkatého celeru lze konzumovat i listy – " +
                    "využít je můžete třeba jako bylinky. Tato zelenina od místních pěstitelů je k dostání od června do října."
                },
                new Plant
                {
                    Name = "Kadeřávek Scarlet",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {

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
                        monthWeekMap[(Month.August, 4)],

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
                        monthWeekMap[(Month.December, 4)]
                    },
                    CropRotation = 2,
                    ImageSrc = "kaderavek_scarlet.jpg",
                    Description = "Kapusta kadeřavá je odrůda druhu brukev zelná (Brassica oleracea). Jde o dvouletou bylinu pěstovanou jako jednoletka, " +
                    "u které se sklízejí mladé listy a stonky. Nazývá se také kadeřávek neboli jarmuz. Je to listová zelenina s vysokými výnosy zkadeřených nebo i " +
                    "hladkých listů, které mají obdobné využití jako kapusta. Kapusta kadeřavá je nejvíce podobná původnímu planému druhu. " +
                    "Používá se i jako rostlina dekorativní, může mít košťál vysoký až 3 metry."
                }
                ,
                new Plant
                {
                    Name = "Kadeřávek Kapitan F1",
                    IsHybrid = true,
                    DirectSewing = true,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {

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
                        monthWeekMap[(Month.August, 4)],

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
                        monthWeekMap[(Month.December, 4)]
                    },
                    CropRotation = 2,
                    ImageSrc = "kaderavek.jpg",
                    Description = "Kapusta kadeřavá je odrůda druhu brukev zelná (Brassica oleracea). Jde o dvouletou bylinu pěstovanou jako jednoletka, " +
                    "u které se sklízejí mladé listy a stonky. Nazývá se také kadeřávek neboli jarmuz. Je to listová zelenina s vysokými výnosy zkadeřených nebo i " +
                    "hladkých listů, které mají obdobné využití jako kapusta. Kapusta kadeřavá je nejvíce podobná původnímu planému druhu. " +
                    "Používá se i jako rostlina dekorativní, může mít košťál vysoký až 3 metry."
                }
                ,
                new Plant
                {
                    Name = "Cibule jarní Všetana",
                    IsHybrid = false,
                    DirectSewing = true,
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
                    Description = "Jedná se o dvouletou až vytrvalou (spíše jen teoreticky[zdroj?!]) rostlinu, na bázi s velkou cibulí. " +
                    "Stonek je dosti robustní, dole až 3 cm v průměru, je dutý. Listy jsou jednoduché, přisedlé, s listovými pochvami. " +
                    "Čepele jsou celokrajné, polooblé se souběžnou žilnatinou. Květy jsou oboupohlavní, ve vrcholovém květenství, jedná se o " +
                    "hlávkovitě stažený zdánlivý okolík, ve skutečnosti to je stažené vrcholičnaté květenství zvané šroubel. " +
                    "Květenství je podepřeno toulcem. Pacibulky jsou v květenství přítomny jen někdy. Okvětí se skládá ze 6 okvětních lístků bílé až " +
                    "narůžovělé barvy, se středním zeleným pruhem. Tyčinek je 6. Gyneceum je složeno ze 3 plodolistů, je synkarpní, semeník je svrchní." +
                    " Plodem je tobolka."
                },
                new Plant
                {
                    Name = "Cibule jarní Grenada",
                    IsHybrid = false,
                    DirectSewing = true,
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
                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]
                    },
                    CropRotation = 2,
                    ImageSrc = "cibule_cervena.jpg",
                    Description = "Jedná se o dvouletou až vytrvalou (spíše jen teoreticky[zdroj?!]) rostlinu, na bázi s velkou cibulí. " +
                    "Stonek je dosti robustní, dole až 3 cm v průměru, je dutý. Listy jsou jednoduché, přisedlé, s listovými pochvami. " +
                    "Čepele jsou celokrajné, polooblé se souběžnou žilnatinou. Květy jsou oboupohlavní, ve vrcholovém květenství, jedná se o " +
                    "hlávkovitě stažený zdánlivý okolík, ve skutečnosti to je stažené vrcholičnaté květenství zvané šroubel. " +
                    "Květenství je podepřeno toulcem. Pacibulky jsou v květenství přítomny jen někdy. Okvětí se skládá ze 6 okvětních lístků bílé až " +
                    "narůžovělé barvy, se středním zeleným pruhem. Tyčinek je 6. Gyneceum je složeno ze 3 plodolistů, je synkarpní, semeník je svrchní." +
                    " Plodem je tobolka."
                },
                new Plant
                {
                    Name = "Cibule šalotka",
                    IsHybrid = false,
                    DirectSewing = true,
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
                        monthWeekMap[(Month.August, 1)],
                        monthWeekMap[(Month.August, 2)],
                        monthWeekMap[(Month.August, 3)],
                        monthWeekMap[(Month.August, 4)],

                        monthWeekMap[(Month.September, 1)],
                        monthWeekMap[(Month.September, 2)],
                        monthWeekMap[(Month.September, 3)],
                        monthWeekMap[(Month.September, 4)]
                    },
                    CropRotation = 2,
                    ImageSrc = "salotka.jpg",
                    Description = "Jedná se o dvouletou až vytrvalou (spíše jen teoreticky[zdroj?!]) rostlinu, na bázi s velkou cibulí. " +
                    "Stonek je dosti robustní, dole až 3 cm v průměru, je dutý. Listy jsou jednoduché, přisedlé, s listovými pochvami. " +
                    "Čepele jsou celokrajné, polooblé se souběžnou žilnatinou. Květy jsou oboupohlavní, ve vrcholovém květenství, jedná se o " +
                    "hlávkovitě stažený zdánlivý okolík, ve skutečnosti to je stažené vrcholičnaté květenství zvané šroubel. " +
                    "Květenství je podepřeno toulcem. Pacibulky jsou v květenství přítomny jen někdy. Okvětí se skládá ze 6 okvětních lístků bílé až " +
                    "narůžovělé barvy, se středním zeleným pruhem. Tyčinek je 6. Gyneceum je složeno ze 3 plodolistů, je synkarpní, semeník je svrchní." +
                    " Plodem je tobolka."
                }
                ,
                new Plant
                {
                    Name = "Pór letní Golem",
                    IsHybrid = false,
                    DirectSewing = true,
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
                    ImageSrc = "por_letni.jpg",
                    Description = "Pór zahradní (Allium porrum) je druh zeleniny z čeledi amarylkovitých. " +
                    "Z botanického hlediska patří do rodu česnek (Allium). Někteří autoři ho uvádí pod jménem jeho " +
                    "divokého předka Allium ampeloprasum var. porrum, jiní ho považují za samostatný kulturní druh Allium porrum."
                }
                ,
                new Plant
                {
                    Name = "Pór podzimní Terminal",
                    IsHybrid = false,
                    DirectSewing = true,
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
                        monthWeekMap[(Month.August, 4)],

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
                        monthWeekMap[(Month.November, 4)]
                    },
                    CropRotation = 1,
                    ImageSrc = "por_podzimni.jpg",
                    Description = "Pór zahradní (Allium porrum) je druh zeleniny z čeledi amarylkovitých. " +
                    "Z botanického hlediska patří do rodu česnek (Allium). Někteří autoři ho uvádí pod jménem jeho " +
                    "divokého předka Allium ampeloprasum var. porrum, jiní ho považují za samostatný kulturní druh Allium porrum."
                },
                new Plant
                {
                    Name = "Pór zimní Winner",
                    IsHybrid = false,
                    DirectSewing = true,
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
                        monthWeekMap[(Month.August, 4)],

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
                        monthWeekMap[(Month.November, 4)]
                    },
                    CropRotation = 1,
                    ImageSrc = "por_zimni.jpg",
                    Description = "Pór zahradní (Allium porrum) je druh zeleniny z čeledi amarylkovitých. " +
                    "Z botanického hlediska patří do rodu česnek (Allium). Někteří autoři ho uvádí pod jménem jeho " +
                    "divokého předka Allium ampeloprasum var. porrum, jiní ho považují za samostatný kulturní druh Allium porrum."
                },
                new Plant
                {
                    Name = "Brokolice Limba",
                    IsHybrid = false,
                    DirectSewing = true,
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
                new Plant
                {
                    Name = "Květák pozdní Octavian",
                    IsHybrid = false,
                    DirectSewing = false,
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
                new Plant
                {
                    Name = "Květák raný Beta",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)],

                        monthWeekMap[(Month.March, 1)],
                        monthWeekMap[(Month.March, 2)],
                        monthWeekMap[(Month.March, 3)],
                        monthWeekMap[(Month.March, 4)]

                        },
                    HarvestMonths = new List<MonthWeek> {

                       monthWeekMap[(Month.June, 1)],
                        monthWeekMap[(Month.June, 2)],
                        monthWeekMap[(Month.June, 3)],
                        monthWeekMap[(Month.June, 4)],

                        monthWeekMap[(Month.July, 1)],
                        monthWeekMap[(Month.July, 2)],
                        monthWeekMap[(Month.July, 3)],
                        monthWeekMap[(Month.July, 4)]

                    },
                    CropRotation = 1,
                    ImageSrc = "kvetak_rany.jpg",
                    Description = "Květák neboli lidově karfiol (Brassica oleracea convar. botrytis) je oblíbenou košťálovou zeleninou, " +
                    "kterou člověk získal vyšlechtěním divoké brukve zelné (stejně jako např. kedluben, zelí či kapustu). " +
                    "V případě květáku využíváme jako zeleninu zdužnatělé květenství. Patří mezi jednoleté rostliny."
                },
                new Plant
                {
                    Name = "Řepa Cylindra",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 10,
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
                        monthWeekMap[(Month.July, 4)]

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
                    ImageSrc = "repa_cylindra.jpg",
                    Description = "Syrová řepa se dobře uplatní v salátech. Chutná s česnekem, křenem, zelím, jablky, pomeranči a ořechy. " +
                    "Z vařené řepy se připravují saláty se smetanou, majonézou, marinádou apod. Oba druhy salátů jsou dobrým doplňkem pečeného masa a minutek. " +
                    "Uvařenou mladou červenou řepu stačí jen osolit, pokapat citronem a máslem – je to dobrá příloha pro ty, kdo nemají rádi kyselé saláty."
                }
                 new Plant
                {
                    Name = "Celer bulvový Albin",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {

                        monthWeekMap[(Month.January, 1)],
                        monthWeekMap[(Month.January, 2)],
                        monthWeekMap[(Month.January, 3)],
                        monthWeekMap[(Month.January, 4)],

                        monthWeekMap[(Month.February, 1)],
                        monthWeekMap[(Month.February, 2)],
                        monthWeekMap[(Month.February, 3)],
                        monthWeekMap[(Month.February, 4)],

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
                    ImageSrc = "celer.jpg",
                    Description = "List celeru působí protizánětlivě a močopudně, působí příznivě na činnost ledvin, povzbuzuje chuť k jídlu, " +
                    "je vhodný pro revmatiky a diabetiky, uklidňuje a podporuje trávení, zpevňuje cévy. Doporučuje se při obezitě, neboť urychluje " +
                    "látkovou výměnu, a působí i jako zdraví neškodné afrodiziakum.[zdroj?]"
                }*/
            };


            /*var cD = context.Plants.Where(a=> a.Name.Contains("Dýně") || a.Name.Contains("Cuketa")).ToList();

            foreach (var plant in cD) 
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Kukuřice") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Hrách") ||
                                            b.Name.Contains("Cibule") ||
                                            b.Name.Contains("Špenát")).ToList();
            };
            foreach (var plant in cD)
            {
                plant.AvoidPlants = context.Plants.Where(b => b.Name.Contains("Rajče")).ToList();
            };

            var celery = context.Plants.Where(a => a.Name.Contains("Celer")).ToList();


            foreach (var plant in celery)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Pór") ||
                                            b.Name.Contains("Kedluben") ||
                                            b.Name.Contains("Kadeřávek") ||
                                            b.Name.Contains("Okurka") ||
                                            b.Name.Contains("Paprika") ||
                                            b.Name.Contains("Květák") ||
                                            b.Name.Contains("Mrkev")).ToList();
            };
            foreach (var plant in celery)
            {
                plant.AvoidPlants = context.Plants.Where(b => b.Name.Contains("Kukuřice")).ToList();
            };


            var onions = context.Plants.Where(a => a.Name.Contains("Cibule")).ToList();


            foreach (var plant in onions)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Mrkev") ||
                                            b.Name.Contains("Řepa") ||
                                            b.Name.Contains("Ředkvička") ||
                                            b.Name.Contains("Salát") ||
                                            b.Name.Contains("Petžel") ||
                                            b.Name.Contains("Okurka") ||
                                            b.Name.Contains("Rajče")).ToList();
            };
            foreach (var plant in onions)
            {
                plant.AvoidPlants = context.Plants.Where(b => b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Hrách") ||
                                            b.Name.Contains("Kadeřávek") ||
                                            b.Name.Contains("Kapusta")).ToList();
            };

            var garlics = context.Plants.Where(a => a.Name.Contains("Česnek")).ToList();


            foreach (var plant in garlics)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Salát") ||
                                            b.Name.Contains("Řepa") ).ToList();
            };
            foreach (var plant in garlics)
            {
                plant.AvoidPlants = context.Plants.Where(b => b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Hrách")).ToList();
            };

            var beans = context.Plants.Where(a => a.Name.Contains("Fazol")).ToList();


            foreach (var plant in beans)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Ředkvička") ||
                                            b.Name.Contains("Okurka") ||
                                            b.Name.Contains("Kapusta") ||
                                            b.Name.Contains("Kedlubna") ||
                                            b.Name.Contains("Salát") ||
                                            b.Name.Contains("Květák") ||
                                            b.Name.Contains("Celer") ||
                                            b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Špenát") ||
                                            b.Name.Contains("Řepa")).ToList();
            }
            
            foreach (var plant in beans)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Hrách") ||
                                            b.Name.Contains("Cibule") ||
                                            b.Name.Contains("Pór") ||
                                            b.Name.Contains("Česnek")).ToList();
            }

            var peas = context.Plants.Where(a => a.Name.Contains("Hrách")).ToList();


            foreach (var plant in peas)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Kedluben") ||
                                            b.Name.Contains("Mrkev") ||
                                            b.Name.Contains("Okurka") ||
                                            b.Name.Contains("Ředkvička") ||
                                            b.Name.Contains("Salát")).ToList();
            }

            foreach (var plant in peas)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Cibule") ||
                                            b.Name.Contains("Pór") ||
                                            b.Name.Contains("Česnek") ||
                                            b.Name.Contains("Rajče")).ToList();
            }

            var kales = context.Plants.Where(a => a.Name.Contains("Kapusta") || a.Name.Contains("Kadeřávek")).ToList();


            foreach (var plant in kales)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Celer") ||
                                            b.Name.Contains("Řepa") ||
                                            b.Name.Contains("Kopr") ||
                                            b.Name.Contains("Rozmarýn")).ToList();
            }

            foreach (var plant in kales)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Ředkvička") ||
                                            b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Cibule")).ToList();
            }

            var kohlerabi = context.Plants.Where(a => a.Name.Contains("Kedluben")).ToList();


            foreach (var plant in kohlerabi)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Celer") ||
                                            b.Name.Contains("Pór") ||
                                            b.Name.Contains("Cibule") ||
                                            b.Name.Contains("Řepa") ||
                                            b.Name.Contains("Salát") ||
                                            b.Name.Contains("Špenát") ||
                                            b.Name.Contains("Mrkev") ||
                                            b.Name.Contains("Okurka") ||
                                            b.Name.Contains("Paprika") ||
                                            b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Hrách") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Ředkvička")).ToList();
            }

            var carrot = context.Plants.Where(a => a.Name.Contains("Mrkev")).ToList();


            foreach (var plant in carrot)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Cibule") ||
                                            b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Hrách") ||
                                            b.Name.Contains("Pažitka") ||
                                            b.Name.Contains("Pór") ||
                                            b.Name.Contains("Ředkvička") ||
                                            b.Name.Contains("Česnek") ||
                                            b.Name.Contains("Kopr") ||
                                            b.Name.Contains("Salát") ||
                                            b.Name.Contains("Pak choi") ||
                                            b.Name.Contains("Mangold")).ToList();
            }

            foreach (var plant in carrot)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Kapusta") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Cibule")).ToList();
            }

            var cucumber = context.Plants.Where(a => a.Name.Contains("Okurka")).ToList();


            foreach (var plant in cucumber)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Hrách") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Kopr") ||
                                            b.Name.Contains("Celer") ||
                                            b.Name.Contains("Salát") ||
                                            b.Name.Contains("Cibule") ||
                                            b.Name.Contains("Řepa") ||
                                            b.Name.Contains("Bazalka") ||
                                            b.Name.Contains("Pór") ||
                                            b.Name.Contains("Brokolice") ||
                                            b.Name.Contains("Květák") ||
                                            b.Name.Contains("Kedluben") ||
                                            b.Name.Contains("Kadeřávek") ||
                                            b.Name.Contains("Kapusta")).ToList();
            }

            foreach (var plant in cucumber)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Ředkvička") ||
                                            b.Name.Contains("Česnek")).ToList();
            }

            var pepper = context.Plants.Where(a => a.Name.Contains("Paprika")).ToList();


            foreach (var plant in pepper)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Mrkev") ||
                                            b.Name.Contains("Kedluben") ||
                                            b.Name.Contains("Okurka") ||
                                            b.Name.Contains("Rajče")).ToList();
            }

            foreach (var plant in pepper)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Fazol")).ToList();
            }

            var tomato = context.Plants.Where(a => a.Name.Contains("Rajče")).ToList();


            foreach (var plant in tomato)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Bazalka") ||
                                            b.Name.Contains("Mrkev") ||
                                            b.Name.Contains("Ředkvička") ||
                                            b.Name.Contains("Řepa") ||
                                            b.Name.Contains("Salát") ||
                                            b.Name.Contains("Cibule") ||
                                            b.Name.Contains("Česnek") ||
                                            b.Name.Contains("Petržel") ||
                                            b.Name.Contains("Pažitka")).ToList();
            }

            foreach (var plant in tomato)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Hrách")).ToList();
            }

            var radish = context.Plants.Where(a => a.Name.Contains("Ředkvička")).ToList();


            foreach (var plant in radish)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Salát") ||
                                            b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Kedluben") ||
                                            b.Name.Contains("Mrkev") ||
                                            b.Name.Contains("Hrách") ||
                                            b.Name.Contains("Špenát") ||
                                            b.Name.Contains("Fazol")).ToList();
            }

            foreach (var plant in radish)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Okurka") ||
                                            b.Name.Contains("Kapusta") ||
                                            b.Name.Contains("Kadeřávek") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Tykev") ||
                                            b.Name.Contains("Dýně")).ToList();
            }

            var squash = context.Plants.Where(a => a.Name.Contains("Tykev")).ToList();

            foreach (var plant in squash)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Kukuřice") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Hrách") ||
                                            b.Name.Contains("Cibule") ||
                                            b.Name.Contains("Špenát")).ToList();
            };
            foreach (var plant in squash)
            {
                plant.AvoidPlants = context.Plants.Where(b => b.Name.Contains("Rajče")).ToList();
            };

            var lettuce = context.Plants.Where(a => a.Name.Contains("Salát")).ToList();


            foreach (var plant in lettuce)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Okurka") ||
                                            b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Mrkev") ||
                                            b.Name.Contains("Řepa") ||
                                            b.Name.Contains("Kopr") ||
                                            b.Name.Contains("Hrách") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Brokolice") ||
                                            b.Name.Contains("Květák") ||
                                            b.Name.Contains("Kedluben") ||
                                            b.Name.Contains("Kadeřávek") ||
                                            b.Name.Contains("Kapusta") ||
                                            b.Name.Contains("Ředkvička") ||
                                            b.Name.Contains("Pór")).ToList();
            }

            foreach (var plant in lettuce)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Celer") ||
                                            b.Name.Contains("Petržel")).ToList();
            }

            var spinach = context.Plants.Where(a => a.Name.Contains("Špenát")).ToList();


            foreach (var plant in spinach)
            {
                plant.CompanionPlants = context.Plants.Where(b => b.Name.Contains("Okurka") ||
                                            b.Name.Contains("Rajče") ||
                                            b.Name.Contains("Fazol") ||
                                            b.Name.Contains("Brokolice") ||
                                            b.Name.Contains("Květák") ||
                                            b.Name.Contains("Kedluben") ||
                                            b.Name.Contains("Kadeřávek") ||
                                            b.Name.Contains("Kapusta") ||
                                            b.Name.Contains("Ředkvička")).ToList();
            }

            foreach (var plant in spinach)
            {
                plant.AvoidPlants = context.Plants.Where(b =>
                                            b.Name.Contains("Cibule") ||
                                            b.Name.Contains("Česnek") ||
                                            b.Name.Contains("Řepa") ||
                                            b.Name.Contains("Okurka")).ToList();
            }*/

            await context.Plants.AddRangeAsync(plants);
            await context.SaveChangesAsync();


        }
    }
}
