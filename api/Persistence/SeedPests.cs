using api.Model;

namespace api.Persistence
{
    public class SeedPests
    {
        public static async Task SeedData(DataContext context)
        {                                      
            var idsMsice = new List<string>
            {
                "25C2EAC3-50F5-4E96-8F53-42B2C52EF017",
                "89443749-1F3E-45A9-9474-E14665297615",
                "975E0757-7EA9-4FE8-8593-2A77A513FE50",
                "4D310F40-E2E0-4E69-A2D1-530AD8FDBB97",
                "14B245A1-71A0-49DF-ABA1-6E8FB0028A83",
                "77CF3D7F-D9CD-4EB4-8E14-87D99498A144",
                "930CFEB4-BC7B-4C05-9189-09273B995D52",
                "9A40FBBE-0302-4150-8D37-8E1BBF924AC3",
                "769ACF86-01CF-49FD-A694-85492C1CF6C5",
                "999A6D7C-5F05-4593-A793-E097E7FE4926",
                "BD81002B-E63F-4908-A1DB-F39E8601549E",
                "C433ABD0-7D58-42F5-9FD9-A06361A0F5B9",
                "D643A20F-03E7-4630-94CD-1C128AF221D1"
            };
            var plantsMsice = context.Plants.Where(p => idsMsice.Contains(p.Id.ToString())).ToList();

            var idsDrepcik = new List<string>
            {
                "9F9A1F91-93E3-4E90-9A06-7B55C1AF72EC",
                "91D656F9-E0ED-410D-9067-571CA02A775F",
                "8AD871CC-AE38-4189-8994-B38CED71F3B5"

            };

            var plantsDrepcik = context.Plants.Where(p => idsDrepcik.Contains(p.Id.ToString())).ToList();

            var pests = new List<Pest>
            {
                /*new Pest
                {
                    Name = "Mšice",
                    Advice = "Mšice vysávají šťávu z rostlin. Listy žloputnou a ovadají. V boji proti mšicím lze použít postřiky buď chemické, nebo přírodní. Doma lze vyrobit postřik z česneku, kopřiv nebo mýdlové vody. Přiroyeným predátorem mšic jsou slunéčka sedmitečná",
                    Plants = plantsMsice,
                    ImageSrc = "msice.jpg"
                },*/
                new Pest
                {
                    Name = "Dřepčík",
                    Advice = "Dřepčící napadají rostliny ve velkých koloniích a vykusují do listů rostlin díry. Lze se jich zbavit pomocí žlutých lepových desek, postřikem z octu a mýdla. Učinné je taká překrýt rostliny bílou netkanou textílií.",
                    ImageSrc= "drepcik.jpg",
                    Plants= plantsDrepcik

                }
            };
            await context.AddRangeAsync(pests);
            await context.SaveChangesAsync();
        }
    }
}
