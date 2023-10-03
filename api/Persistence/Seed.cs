using api.Model;
using Microsoft.AspNetCore.Routing;
using System;
using System.Diagnostics;
using System.Drawing;

namespace api.Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            var plants = new List<Plant>
            {
                new Plant
                {
                    Name = "Rajče tyčkové Gardeners Delight",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {   
                        new MonthWeek { Month = Month.March, Week = 3 },
                        new MonthWeek { Month = Month.April } },
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July }, 
                        new MonthWeek { Month = Month.August }, 
                        new MonthWeek { Month = Month.September } },
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
                        new MonthWeek { Month = Month.March, Week = 3 },
                        new MonthWeek { Month = Month.April } },
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September } },
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
                        new MonthWeek { Month = Month.April }, 
                        new MonthWeek { Month = Month.May } },
                    HarvestMonths = new List<MonthWeek> { 
                        new MonthWeek { Month = Month.August }, 
                        new MonthWeek { Month = Month.September },
                        new MonthWeek { Month = Month.October }},
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
                        new MonthWeek { Month = Month.March, Week = 3 }, 
                        new MonthWeek { Month = Month.April } },
                    HarvestMonths = new List < MonthWeek > { 
                        new MonthWeek { Month = Month.July }, 
                        new MonthWeek { Month = Month.August }, 
                        new MonthWeek { Month = Month.September } },
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
                        new MonthWeek { Month = Month.April, Week = 2 },
                        new MonthWeek { Month = Month.May} },
                    HarvestMonths = new List<MonthWeek> { 
                        new MonthWeek { Month = Month.August }, 
                        new MonthWeek { Month = Month.September }, 
                        new MonthWeek { Month = Month.October }},
                    CropRotation = 1,
                    ImageSrc = "arava.jpg",
                    Description = "Melouny typu Galia jsou výnosné cukrové odrůdy sladké a aromatické chuti. Jedná se o hybrid žlutého melounu a melounu cantaloupe, který byl poprvé vypěstován v Izraeli.\r\n\r\n" +
                    "Meloun Arava F1 v BIO kvalitě má bílou až jemně nazelenalou dužinu a je výsledkem mnohaletého šlechtění v nejrůznějších pěstebních podmínkách. Odrůda je též odolná proti padlí.\r\n\r\n" +
                    "Zralé plody jsou žluté, intenzivně voní a postupně samy opadávají z rostliny. Arava F1 je ranou odrůdou, sklizeň za vhodných teplotních podmínek začíná již od poloviny července.\r\n\r\n" +
                    "Meloun Galia se využívá s oblibou do ovocných salátů, kde se kombinuje s kyselejšími druhy ovoce, neboť samotná jeho chuť je velmi specifická a hodně sladká. " +
                    "Dále je možné ho využít i do zeleninových salátů či v kombinaci s rybami nebo masem. Oblíbený je také jako přísada do koktejlů, smoothie a čerstvých džusů."

                },new Plant
                {
                    Name = "Cuketa Paladin F1",
                    IsHybrid = true,
                    DirectSewing = false,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> { 
                        new MonthWeek { Month = Month.April, Week = 2 },
                        new MonthWeek { Month = Month.May}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September }},
                    CropRotation = 1,
                    Description = "Cuketa Paladin F1 je výnosná hybridní tykev. Vytváří pravidelné plody válcovitého tvaru, žluté barvy. \r\n\r\n" +
                    "Jedná se o ranou odrůdu, na jejíž úrodu se můžete těšit již od začátku července.\r\n\r\nPoužívá se k přímé konzumaci nebo i ke konzervaci. \r\n\r\n" +
                    "Plody váží kolem 1,5 kg. Rostlina je keříčkovitého, kompaktního vzrůstu. \r\n\r\n" +
                    "Doba zrání je cca 70 dní. ",
                    ImageSrc = "paladin.jpg"
                },new Plant
                {
                    Name = "Tykev muškátová F1",
                    IsHybrid = true,
                    DirectSewing = false,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.April, Week = 4 },
                        new MonthWeek { Month = Month.May} },
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September },
                        new MonthWeek { Month = Month.October }},
                    CropRotation = 1,
                    ImageSrc = "muskatova.jpg",
                    Description = "Tykev Butterscotch je ranou a plazivou odrůdou muškátové tykve. " +
                    "Rostlina se vyznačuje mohutnými výhony, velkými listy a plody hruškovitého tvaru, které dozrávají do krémové až oranžové barvy.\r\n\r\n" +
                    "Váha plodů je 600–900 g a velikost může být 30–50 cm.\r\n\r\nDužina plodů je v době zralosti světle žlutá. V této fázi je tykev vhodná k přímé konzumaci. " +
                    "Později se mění na sytě oranžovou a je vhodná k tepelnému zpracování či konzervaci.\r\n\r\nJedná se o velmi chutnou odrůdu, která vyniká odolností proti padlí (PMT).\r\n\r\n" +
                    "Doba zrání je přibližně 95 dní."
                },new Plant
                {
                    Name = "BIO Paprika Korosko",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 28,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.February, Week = 3 },
                        new MonthWeek { Month = Month.March },
                        new MonthWeek { Month = Month.April}, },
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September },
                        new MonthWeek { Month = Month.October }},
                    CropRotation = 1,
                    ImageSrc = "korosko.jpg",
                    Description = "BIO Paprika Korosko je oblíbená odrůda se špičatými, červenými plody o velikosti cca 5 x 16 cm a hmotnosti cca 60 g. \r\n\r\n" +
                    "Je to velice výnosná odrůda, vhodná k přímé konzumaci, plnění i grilování. Chuť je čerstvá, sladká. \r\n\r\n" +
                    "Jedná se o ranou odrůdu, vhodnou k pěstování ve skleníku, v květináči na balkóně či volně venku. \r\n\r\n" +
                    "Celkově rostlina dosahuje výšky kolem 100 cm. "
                },new Plant
                {
                    Name = "Meloun žlutý Bimbo F1",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 18,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.April, Week = 2},
                        new MonthWeek { Month = Month.May}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September },
                        new MonthWeek { Month = Month.October }},
                    CropRotation = 1,
                    ImageSrc = "bimbo.jpg",
                    Description = " Meloun Bimbo F1 je raná hybridní medová odrůda, která je velice odolná vůči padlí a virům. " +
                    "Vytváří až 2,5 kg velké plody žluté barvy s dobrou skladovatelností. \r\n\r\nMelouny se s oblibou pěstují pro svou výbornou chuť. " +
                    "Konzumují se v syrovém stavu a slouží jako zdravá pochutina, neboť jsou velice nízkokalorické a mají vysoký obsah vitamínů a vody.\r\n\r\n" +
                    "Ideální je tuto odrůdu si předpěstovat ve skleníku. "
                },new Plant
                {
                    Name = "Řepa salátová kulatá",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 8,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.March, Week = 4},
                        new MonthWeek { Month = Month.April},
                        new MonthWeek { Month = Month.May },
                        new MonthWeek { Month = Month.June }},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.June },
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September},
                        new MonthWeek { Month = Month.October }},
                    CropRotation = 2,
                    ImageSrc="repa_kulata.jpg",
                    Description = "epa salátová je polopozdní, výnosná odrůda, která je odolná vůči chorobám. " +
                    "Je vhodná pro přímou konzumaci, konzervaci i tepelné zpracování.\r\n\r\n" +
                    "Řepa je velice zdravá zelenina. Obsahuje velké množství vitamínů B, C a provitamínu A, dále pak minerálů, antioxidantů a stopových prvků."
                },new Plant
                {
                    Name = "Rajče Aztek",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 25,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.March, Week = 3 },
                        new MonthWeek { Month = Month.April } },
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September}},
                    CropRotation = 1,
                    Description = "Rajče Aztek je velmi výnosná odrůda keříčkových rajčat. " +
                    "Je ideální pro pěstování v truhlících či květináčích na balkónech. " +
                    "Rostliny jsou malého vzrůstu, přibližně do 35 cm, a působí v exteriéru velmi dekorativně.\r\n\r\n" +
                    "Tato odrůda plodí drobné žluté plody o váze 15–20 g. Rajčátka jsou kulatá s vynikající sladkou chutí, takže se oblibě těší především u dětí.\r\n\r\n" +
                    "Rajče Aztek je vhodné k přímé konzumaci a do studené kuchyně.\r\n\r\nDoba zrání je asi 70 dní.",
                    ImageSrc  = "aztek.jpg"
                },new Plant
                {
                    Name = "Ačokča",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 22,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.April } },
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September}},
                    CropRotation = 1,
                    Description = "Jedná se o jednoletou rostlinu, známou také pod názvem divoká okurka, jejíž stonek dorůstá délky až 5 m.\r\n" +
                    "Rostlina je vhodná pro polní pěstování, neboť se bohatě větví. Důležité je poskytnout ji dostatečnou vertikální oporu. V našich klimatických podmínkách se jí daří poměrně dobře.\r\n\r\n" +
                    "Charakteristické jsou pro ni zvláštní plody, které jsou vzhledem podobné paprice a chutí naopak připomínají okurku. " +
                    "Plody jsou světle zelené barvy a dosahují délky 5–10 cm. Dužina plodu je bílá nebo lehce nazelenalá.\r\n\r\n" +
                    "Rostlina je oblíbená pro své blahodárné účinky na lidské zdraví – pomáhá bojovat proti cukrovce, snižuje cholesterol a vysoký krevní tlak. To vše ovšem pouze v syrovém stavu.\r\n\r\n" +
                    "Ačokču lze konzumovat syrovou, stejně jako jiné druhy zeleniny, nebo ji lze tepelně upravovat. " +
                    "Příprava je stejná jako u paprik. Kromě toho lze plody nakládat buď samostatně nebo v kombinaci s okurkami, cibulkami apod.",
                    ImageSrc  = "acokca.jpg"
                },new Plant
                {
                    Name = "Tykev špagetová",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 22,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.April, Week = 4 } },
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September}},
                    CropRotation = 1,
                    Description = "Tato tykev pochází z Japonska a svůj název získala díky své specifické dužině, která se po uvaření či s přibývající zralostí rozpadá na jednotlivá vlákna, připomínající špagety. " +
                    "Tato vlákna lze oddělit a ve vařeném stavu je podávat na způsob těstovin jako jejich nízkokalorickou variantu.\r\n\r\n" +
                    "Rostlina je plazivá, plodí oválné plody žluté barvy. Tykve dorůstají hmotnosti přibližně 2 kg.\r\n\r\n" +
                    "Doba zrání je okolo 90 dní.",
                    ImageSrc  = "spagetova.jpg"
                },new Plant
                {
                    Name = "Cuketa Costata Romanesco",
                    IsHybrid = false,
                    DirectSewing = false,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.April, Week = 2 },
                        new MonthWeek { Month = Month.May}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September}},
                    CropRotation = 1,
                    Description = "Costata Romanesco je středně raná italská keříčková odrůda s atraktivními plody. " +
                    "Ty jsou poměrně velké, jejich délka je okolo 40 cm. Ovšem ideální délka ke sklizni je okolo 20 cm. V té době mají cukety nejlepší chuť. \r\n\r\n" +
                    "Barva je světle zelená či žlutá s tmavě zelenými pruhy.\r\n\r\nChuť cukety Costata Romanesco je výtečná a právě tato odrůda je hojně využívána do mnoha italských receptů. " +
                    "Konzumovat lze plody i květy. Plody jsou vhodné k vaření, sušení nebo konzervování.\r\n\r\n" +
                    "Doba zrání je přibližně 50 dní. ",
                    ImageSrc  = "romanesco.jpg"
                },new Plant
                {
                    Name = "Okurka salátová Superstar F1",
                    IsHybrid = true,
                    DirectSewing = false,
                    GerminationTemp = 22,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.April, Week = 2 },
                        new MonthWeek { Month = Month.May}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September}},
                    CropRotation = 1,
                    Description = "Jedná se o odrůdu salátové okurky typu multifruit. Odrůda je vhodná k rychlení ve sklenících či fóliových krytech.\r\n\r\n" +
                    "Rostlina je středního vzrůstu, plodí 25–30 cm dlouhé tmavě zelené plody.\r\n\r\nOkurky mají jemnou chuť, jsou šťavnaté a geneticky nehořké. Jsou vhodné k přímé konzumaci.\r\n\r\n" +
                    "Doba zrání je přibližně 70 dní.\r\n\r\n" +
                    "Semena jsou mořená.",
                    ImageSrc  = "superstar.jpg"
                },new Plant
                {
                    Name = "Okurka salátová Superstar F1",
                    IsHybrid = true,
                    DirectSewing = false,
                    GerminationTemp = 22,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.April, Week = 2 },
                        new MonthWeek { Month = Month.May}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September}},
                    CropRotation = 1,
                    Description = "Jedná se o odrůdu salátové okurky typu multifruit. Odrůda je vhodná k rychlení ve sklenících či fóliových krytech.\r\n\r\n" +
                    "Rostlina je středního vzrůstu, plodí 25–30 cm dlouhé tmavě zelené plody.\r\n\r\nOkurky mají jemnou chuť, jsou šťavnaté a geneticky nehořké. Jsou vhodné k přímé konzumaci.\r\n\r\n" +
                    "Doba zrání je přibližně 70 dní.\r\n\r\n" +
                    "Semena jsou mořená.",
                    ImageSrc  = "superstar.jpg"
                },new Plant
                {
                    Name = "Mrkev Táborská žlutá",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 7,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.March},
                        new MonthWeek { Month = Month.April},
                        new MonthWeek { Month = Month.May},
                        new MonthWeek { Month = Month.June},
                        new MonthWeek { Month = Month.July, Week = 2}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September},
                        new MonthWeek { Month = Month.October}},
                    CropRotation = 2,
                    Description = "Mrkev Táborská žlutá je typická středně dlouhými, válcovitými kořeny. \r\n\r\n" +
                    "Dorůstají délky 12–26 cm, dužina je sytě žlutá, někdy žlutooranžová a zakončení pološpičaté.\r\n\r\n" +
                    "Odrůda je vysoce výnosná, a to 70–100 t/ha. Je často používána jako krmná mrkev.\r\n\r\n" +
                    "Vyznačuje se nízkým obsahem beta karotenu a středním obsahem cukru, proto je vhodná také při dietních opatřeních. \r\n\r\n" +
                    "Mrkev Táborská je odolná proti chorobám, také proti krátkodobému zamokření nebo suchu a vybíhání do květu.\r\n\r\n" +
                    "Semena jsou mořená.",
                    ImageSrc  = "taborska.jpg"
                },new Plant
                {
                    Name = "Sadbový česnek Topaz",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 9,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.November},
                        new MonthWeek { Month = Month.December}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September},
                        new MonthWeek { Month = Month.October}},
                    CropRotation = 2,
                    Description = "Sadbový česnek Topaz je poloraná odrůda ozimého paličáku.\r\n\r\n" +
                    "Topaz je odrůda pro podzimní výsadby s cibulkami kulovitého a pravidelného tvaru. Vnější suknice je bílá s fialovými pruhy, barva suknice stroužku je fialová.\r\n\r\n" +
                    "Jedna cibulka obsahuje obvykle kolem 8–11 stroužků. \r\n\r\n" +
                    "Odrůda je vysoce odolná proti virózám a vhodná k dlouhodobému skladování.",
                    ImageSrc  = "topaz.jpg"
                },new Plant
                {
                    Name = "Sadbový česnek Vekan",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 9,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.November},
                        new MonthWeek { Month = Month.December}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September},
                        new MonthWeek { Month = Month.October}},
                    CropRotation = 2,
                    Description = "Sadbový česnek odrůdy Vekan je oblíbená odrůda ozimého úzkolistého paličáku. \r\n\r\n" +
                    "Cibule dosahují středně velké velikosti, uspořádání stroužků v cibulovině je nepravidelné, průměrně obsahuje 8–12 stroužků. ",
                    ImageSrc  = "vekan.jpg"
                },new Plant
                {
                    Name = "Okurka salátová Jogger F1",
                    IsHybrid = true,
                    DirectSewing = false,
                    GerminationTemp = 22,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.April},
                        new MonthWeek { Month = Month.May}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July },
                        new MonthWeek { Month = Month.August },
                        new MonthWeek { Month = Month.September},
                        new MonthWeek { Month = Month.October}},
                    CropRotation = 1,
                    Description = "Jedná se o ranou hybridní odrůdu salátové okurky, která je vhodná jak pro polní pěstování, tak i pro pěstování ve sklenících či fóliových krytech. Rostliny jsou středně velkého vzrůstu a plodí dlouhé tmavě zelené plody, které dorůstají délky 20–22 cm. Povrch plodů je lehce bradavičnatý.\r\n\r\n" +
                    "Okurky jsou určeny k přímé konzumaci, hodí se k jakémukoliv běžnému zpracování.",
                    ImageSrc  = "jogger.jpg"
                },new Plant
                {
                    Name = "Kopr",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 15,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.March},
                        new MonthWeek { Month = Month.April},
                        new MonthWeek { Month = Month.May},
                        new MonthWeek { Month = Month.June},
                        new MonthWeek { Month = Month.July}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.May},
                        new MonthWeek { Month = Month.June},
                        new MonthWeek { Month = Month.July},
                        new MonthWeek { Month = Month.August},
                        new MonthWeek { Month = Month.September},
                        new MonthWeek { Month = Month.October}},
                    CropRotation = 23,
                    Description = "Kopr vonný je jednoletá, aromatická bylina, původem z východní části Středozemí, Indie, Ruska a západní Asie. " +
                    "Dorůstá výšky 60–150 cm. Kopr má tenký kořen a přímou, jemně rýhovanou dutou lodyhu modrozelené barvy. Střídavé listy jsou několikrát dělené do nitkovitých úkrojů. " +
                    "Už v biblických dobách se kopr používal jako platidlo. Židé z jeho pěstování odváděli naturální daně Římanům a ti si z kopru dělali věnečky. Kdysi nevěsty věřily, že když si do boty dají kopr, " +
                    "budou mít v tchynině domě moc nad vším.",
                    ImageSrc  = "kopr.jpg",
                    RepeatedPlanting = 14
                },new Plant
                {
                    Name = "Tymián obecný",
                    IsHybrid = false,
                    DirectSewing = true,
                    GerminationTemp = 20,
                    SewingMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.March},
                        new MonthWeek { Month = Month.April},
                        new MonthWeek { Month = Month.May}},
                    HarvestMonths = new List<MonthWeek> {
                        new MonthWeek { Month = Month.July},
                        new MonthWeek { Month = Month.August},
                        new MonthWeek { Month = Month.September},
                        new MonthWeek { Month = Month.October}},
                    CropRotation = 23,
                    Description = "Tymián obecný je populární trvalka vysoká 40 cm. Sklízí se nať, která se seřezává 2–3x ročně vždy před plným rozkvětem.\r\n\r\n" +
                    "Tymián se používá čerstvý i sušený jako samostatné koření i do kořeninových směsí. Koření je skvělé pro dochucování nádivek, polévek a omáček. " +
                    "Výborné je s drůbežím masem a rybami.",
                    ImageSrc  = "kopr.jpg"
                }
            };

            await context.Plants.AddRangeAsync(plants);
            await context.SaveChangesAsync();
        }
    }
}
