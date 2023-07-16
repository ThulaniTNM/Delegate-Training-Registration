namespace Delegate_Training_Registration.DataAccess.Models
{
  public class Person
  {
	public Guid PersonID { get; set; }
	public string FirstName { get; set; }
	public string CompanyName { get; set; }
	public int PhoneNumber { get; set; }
	public string Email { get; set; }
	public Dietary Dietary { get; set; }

	// navigation props
	public ICollection<PhysicalAddress> PhysicalAddresses { get; set; }
	public ICollection<RegisterDelegateTrainings> RegisteredTrainings { get; set; }
  }

  public enum Dietary
  {
	Vegetarian = 0,
	Halal = 1,
	Vegan = 2,
	Other = 3
  }
}
