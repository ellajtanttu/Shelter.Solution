namespace Shelter.Models
{
  public class Pet
  {
    public int PetId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Color { get; set; }
    public bool Intact { get; set; }
  }
}