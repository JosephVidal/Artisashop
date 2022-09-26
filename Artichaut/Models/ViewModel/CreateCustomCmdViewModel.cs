namespace Artichaut.Models.ViewModel
{
    public class CreateCustomCmdViewModel
    {
        public CreateCustomCmdViewModel(string craftsmanID, string name, string desc, int quantity)
        {
            CraftsmanID = craftsmanID;
            Name = name;
            Desc = desc;
            Quantity = quantity;
        }

        public string CraftsmanID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Quantity { get; set; }

    }
}
