using API.Domain;

namespace API.Persistence
{
    public class SeedPests
    {
        public static async Task SeedData(DataContext context)
        {                                      
            
            var plantsMsice = context.PlantTypes.Where(a=> a.Name.Contains("Rajče") || a.Name.Contains("Paprika") || a.Name.Contains("Okurka")).ToList();

            var plantsDrepcik = context.PlantTypes.Where(p => p.Name.Contains("Kedluben") || p.Name.Contains("Brokolice") || p.Name.Contains("Kedluben") || p.Name.Contains("Ředkvička") || p.Name.Contains("Květák") || p.Name.Contains("Kapusta") || p.Name.Contains("Pak Choi")).ToList();

            var plantsSviluska = context.PlantTypes.Where(p => p.Name.Contains("Kedluben")).ToList();

            var plantsBelasek = context.PlantTypes.Where(p => p.Name.Contains("Kedluben") || p.Name.Contains("Brokolice") || p.Name.Contains("Kedluben") || p.Name.Contains("Ředkvička") || p.Name.Contains("Květák") || p.Name.Contains("Kapusta") || p.Name.Contains("Pak Choi")).ToList();

            var pests = new List<Pest>
            {
                new Pest
                {
                    Name = "Mšice",
                    Advice = "Mšice vysávají šťávu z rostlin. Listy žloputnou a ovadají. V boji proti mšicím lze použít postřiky buď chemické, nebo přírodní. Doma lze vyrobit postřik z česneku, kopřiv nebo mýdlové vody. Přiroyeným predátorem mšic jsou slunéčka sedmitečná",
                    Plants = plantsMsice,
                    ImageSrc = "msice.jpg"
                },
                new Pest
                {
                    Name = "Dřepčík",
                    Advice = "Dřepčící napadají rostliny ve velkých koloniích a vykusují do listů rostlin díry. Lze se jich zbavit pomocí žlutých lepových desek, postřikem z octu a mýdla. Učinné je taká překrýt rostliny bílou netkanou textílií.",
                    ImageSrc= "drepcik.jpg",
                    Plants= plantsDrepcik

                },
                new Pest
                {
                    Name = "Sviluška",
                    Advice = "Sviluška (Tetranychus) je rod roztočů, kterým je obecně věnována velká pozornost pro jejich schopnost vážně poškozovat rostliny. ",
                    ImageSrc= "drepcik.jpg",
                    Plants= plantsDrepcik

                },
                new Pest
                {
                    Name = "Bělásek",
                    Advice = "Nenasytné housenky běláska způsobují svým povrchovým žírem značné škody na rostlinách z čeledi Brukvovitých (​Brassicaceae)​, známých také jako košťáloviny. Lze použít ​výluhy z aromatických rostlin​, které bělásky odpuzují. Patří mezi ně například šalvěj, mateřídouška, vratič, kopretina, máta peprná či rajčatové zálistky",
                    ImageSrc = "belasek.jpg",
                    Plants = plantsBelasek
                }
            };
            await context.AddRangeAsync(pests);
            await context.SaveChangesAsync();
        }
    }
}
