namespace API.Core
{
    public static class PlantsExtensions
    {
        public static Dictionary<string, List<string>> CompanionPlants = new Dictionary<string, List<string>>
        {

            {"Brokolice",new List<string> {"Fazol keříčkový", "Celer", "Rajče" } },
            {"Celer", new List<string>{"Rajče","Fazol keříčkový","Pór","Kedluben","Okurka","Paprika","Květák","Mrkev" }},
            {"Cibule", new List<string>{"Mrkev","Červená řepa","Ředkvička","Salát","Petržel kořenová","Okurka","Rajče" }},
            {"Dýně", new List<string>{"Kukuřice","Fazol keříčkový","Hrách","Cibule","Špenát"}},
            {"Cuketa", new List<string>{"Kukuřice","Fazol keříčkový","Hrách","Cibule","Špenát"}},
            {"Česnek", new List<string>{"Rajče","Salát", "Červená řepa", "Cibule" } },
            {"Fazol keříčkový", new List<string>{"Ředkvička","Okurka","Kapusta", "Kedluben", "Salát","Květák","Celer","Rajče","Špenát","Červená řepa"} },
            {"Hrách", new List<string>{"Kedluben","Mrkev","Okurka","Ředkvička","Salát"} },
            {"Kapusta", new List<string>{"Celer","Červená řepa" } },
            {"Kedluben", new List<string>{"Celer","Pór","Cibule","Červená řepa","Salát","Špenát","Mrkev","Okurka","Paprika","Rajče","Hrách","Fazol keříčkový","Ředkvička"} },
            {"Mrkev", new List<string>{"Cibule","Rajče","Hrách","Pór","Ředkvička","Česnek","Salát","Pak Choi","Mangold"} },
            {"Okurka", new List<string>{"Hrách","Fazol keříčkový","Celer","Salát","Cibule","Červená řepa","Pór","Brokolice","Květák","Kedluben","Kapusta"} },
            {"Paprika", new List<string>{"Mrkev","Kedluben","Okurka","Rajče"} },
            {"Rajče", new List<string>{"Mrkev","Ředkvička","Červená řepa","Salát","Cibule","Česnek", "Petržel kořenová" } },
            {"Ředkvička", new List<string>{"Salát","Rajče","Kedluben","Mrkev","Hrách","Špenát","Fazol keříčkový"} },
            {"Salát", new List<string>{"Okurka","Rajče","Mrkev","Červená řepa","Hrách","Fazol keříčkový","Brokolice",
                                        "Květák","Kedluben","Kapusta","Ředkvička","Pór"} },
            {"Špenát", new List<string>{"Rajče","Fazol keříčkový","Brokolice","Květák","Kedluben","Ředkvička"} },
            {"Petržel kořenová",new List<string> { "Rajče", "Ředkvička"} },
            {"Pór",new List<string> { "Celer", "Kedluben", "Rajče", "Mrkev"} },
            {"Kukuřice",new List<string> { "Fazol keříčkový", "Hrách", "Okurka", "Dýně", "Špenát"} },
            {"Pak Choi",new List<string> {"Mrkev"} },
            {"Květák",new List<string> {"Fazol keříčkový", "Celer", "Rajče" } },
            {"Mangold",new List<string> {"Fazol keříčkový", "Ředkvička", "Brokolice", "Květák", "Kedluben", "Mrkev" } },
            {"Červená řepa",new List<string> {"Fazol keříčkový", "Cibule", "Okurka", "Česnek"} }

        };

        public static Dictionary<string, List<string>> AvoidPlants = new Dictionary<string, List<string>>
        {
            {"Celer", new List<string>{"Kukuřice" } },
            {"Cibule", new List<string>{"Fazol keříčkový","Hrách","Kapusta"}},
            {"Dýně", new List<string>{"Rajče"}},
            {"Cuketa", new List<string>{"Rajče"}},
            {"Česnek", new List<string>{ "Hrách", "Fazol keříčkový"} },
            {"Fazol keříčkový", new List<string>{"Hrách","Cibule","Pór","Česnek"} },
            {"Hrách", new List<string>{"Fazol keříčkový","Cibule","Pór","Česnek","Rajče"} },
            {"Kapusta", new List<string>{"Ředkvička","Rajče","Fazol keříčkový","Cibule"} },
            {"Kedluben", new List<string>{""} },
            {"Mrkev", new List<string>{"Fazol keříčkový","Kapusta","Fazol keříčkový","Cibule"} },
            {"Okurka", new List<string>{"Rajče","Ředkvička","Česnek"} },
            {"Paprika", new List<string>{ "Fazol keříčkový" } },
            {"Rajče", new List<string>{ "Hrách" } },
            {"Ředkvička", new List<string>{"Okurka","Kapusta","Fazol keříčkový","Dýně"} },
            {"Salát", new List<string>{"Celer", "Petržel kořenová" } },
            {"Špenát", new List<string>{"Cibule","Česnek","Červená řepa","Okurka"} },
            {"Petržel kořenová",new List<string> { "Salát"} },
            {"Pór",new List<string> { "Fazol keříčkový", "Hrách", "Červená řepa"} },
            {"Kukuřice",new List<string> {"Celer", "Červená řepa"} },
            {"Brokolice",new List<string> {"Cibule", "Květák", "Kedluben" } },
            {"Květák",new List<string> {"Cibule", "Brokolice", "Kedluben" } },
            {"Mangold",new List<string> { "Špenát", "Červená řepa" } },
            {"Červená řepa",new List<string> {"Mangold", "Špenát"} }
        };
    }
}
