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
                }*/
            };

            await context.Plants.AddRangeAsync(plants);
            await context.SaveChangesAsync();
        }
    }
}
