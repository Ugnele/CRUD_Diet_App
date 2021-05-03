namespace CrudDietApp.Models.Binding
{
    public class AddRecipeBindingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
        public string Ingredients { get; set; }
        public string PictureUrl { get; set; }
        public DietType Type { get; set; }
        public int CreatedById { get; set; }
    }
}
