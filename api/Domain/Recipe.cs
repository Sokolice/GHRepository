namespace API_Recipes
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public string ImageSrc { get; set; }

        public Recipe()
        {
            Name = string.Empty;
            Url = string.Empty;
            ImageSrc = string.Empty;
        }
    }
}
