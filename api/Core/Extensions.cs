namespace api.Core
{
    public static class Extensions
    {
        public static Dictionary<string, List<string>> CompanionPlants = new Dictionary<string, List<string>>
        {
            {"Celer", new List<string>{"Rajče","Fazol","Pór","Kedluben","Kadeřávek","Okurka","Paprika","Květák","Mrkev" }},
            {"Cibule", new List<string>{"Mrkev","Řepa","Ředkvička","Salát","Petžel","Okurka","Rajče" }},
            {"Tykev", new List<string>{"Kukuřice","Fazol","Hrách","Cibule","Špenát"}},
            {"Dýně", new List<string>{"Kukuřice","Fazol","Hrách","Cibule","Špenát"}},
            {"Cuketa", new List<string>{"Kukuřice","Fazol","Hrách","Cibule","Špenát"}},
            {"Česnek", new List<string>{"Rajče","Salát", "Řepa", "Cibule" } },
            {"Fazol", new List<string>{"Ředkvička","Okurka","Kapusta","Kedlubna","Salát","Květák","Celer","Rajče","Špenát","Řepa"} },
            {"Hrách", new List<string>{"Kedluben","Mrkev","Okurka","Ředkvička","Salát"} },
            {"Kapusta", new List<string>{"Celer","Řepa","Kopr","Rozmarýn", "Máta" } },
            {"Kadeřávek", new List<string>{"Celer","Řepa","Kopr","Rozmarýn", "Máta" } },
            {"Kedluben", new List<string>{"Celer","Pór","Cibule","Řepa","Salát","Špenát","Mrkev","Okurka","Paprika","Rajče","Hrách","Fazol","Ředkvička"} },
            {"Mrkev", new List<string>{"Cibule","Rajče","Hrách","Pažitka","Pór","Ředkvička","Česnek","Kopr","Salát","Pak choi","Mangold"} },
            {"Okurka", new List<string>{"Hrách","Fazol","Kopr","Celer","Salát","Cibule","Řepa","Bazalka","Pór","Brokolice","Květák","Kedluben","Kadeřávek","Kapusta"} },
            {"Paprika", new List<string>{"Mrkev","Kedluben","Okurka","Rajče"} },
            {"Rajče", new List<string>{"Bazalka","Mrkev","Ředkvička","Řepa","Salát","Cibule","Česnek","Petržel","Pažitka"} },
            {"Ředkvička", new List<string>{"Salát","Rajče","Kedluben","Mrkev","Hrách","Špenát","Fazol"} },
            {"Salát", new List<string>{"Okurka","Rajče","Mrkev","Řepa","Kopr","Hrách","Fazol","Brokolice",
                                        "Květák","Kedluben","Kadeřávek","Kapusta","Ředkvička","Pór"} },
            {"Špenát", new List<string>{"Rajče","Fazol","Brokolice","Květák","Kedluben","Ředkvička", "Brambory"} }

        };

        public static Dictionary<string, List<string>> AvoidPlants = new Dictionary<string, List<string>>
        {
            {"Celer", new List<string>{"Kukuřice", "Brambory" } },
            {"Cibule", new List<string>{"Fazol","Hrách","Kadeřávek","Kapusta"}},
            {"Tykev", new List<string>{ "Rajče"}},
            {"Dýně", new List<string>{"Rajče"}},
            {"Cuketa", new List<string>{"Rajče"}},
            {"Česnek", new List<string>{ "Hrách", "Fazol"} },
            {"Fazol", new List<string>{"Hrách","Cibule","Pór","Česnek"} },
            {"Hrách", new List<string>{"Fazol","Cibule","Pór","Česnek","Rajče"} },
            {"Kapusta", new List<string>{"Ředkvička","Rajče","Fazol","Cibule"} },
            {"Kedluben", new List<string>{""} },
            {"Mrkev", new List<string>{"Fazol","Kapusta","Fazol","Cibule"} },
            {"Okurka", new List<string>{"Rajče","Ředkvička","Česnek"} },
            {"Paprika", new List<string>{ "Fazol" } },
            {"Rajče", new List<string>{ "Hrách" } },
            {"Ředkvička", new List<string>{"Okurka","Kapusta","Kadeřávek","Fazol","Tykev","Dýně"} },
            {"Salát", new List<string>{"Celer", "Petržel"} },
            {"Špenát", new List<string>{"Cibule","Česnek","Řepa","Okurka"} }

        };
    }
}
