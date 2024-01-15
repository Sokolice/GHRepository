using api.Model;

namespace api.Persistence
{
    public class SeedPlants
    {
        public static async Task SeedData(DataContext context)
        {
            var monthWeekMap = context.MonthWeeks.ToDictionary(x => (x.Month, x.Week));
            var plants = new List<Plant>
            {
               /* new Plant
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
                    Description = "Odrůda, určená pro jarní a letní polní pěstování. Bulvička je karmínově červená, kulatá. Je značně odolná proti vybíhání do květu. Výsev od března. Vegetační doba od výsevu je 33 - 37 dní."
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
                }
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
                    " Účinnými látkami jsou především silice a některé vitamíny skupiny B.[1]"
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
                },*/

                ,
                new Plant
                {
                    Name = "Špenát",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 5,
                    SewingMonths = new List<MonthWeek> {


                        monthWeekMap[(Month.February, 1)],
                        monthWeekMap[(Month.February, 2)],

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
                        monthWeekMap[(Month.May, 4)],


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
                        monthWeekMap[(Month.August, 4)],
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
                }

            };

            await context.Plants.AddRangeAsync(plants);
            await context.SaveChangesAsync();
        }
    }
}
