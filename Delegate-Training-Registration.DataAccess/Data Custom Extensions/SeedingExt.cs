using Delegate_Training_Registration.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Delegate_Training_Registration.DataAccess.Extensions
{
  public static class SeedingExt
  {
	// seed database entities.
	public static void Seed(this ModelBuilder modelBuilder)
	{
	  // replace temp data with json file
	  //e288a507-bb38-477e-b985-c7afd1ee8057 - course
	  //7aaa6300-d539-45de-b0a1-2f4d5750f75b - course

	  //7c45fd03-f621-418d-92b5-541364f13e97 - training
	  //eb0551e1-87ff-4e9e-8806-8be3b2413674 -  training

	  //8ce12c33-3a41-483c-b3ed-5c079c3762f7 - person
	  //d72c6fef-e0b4-4e85-a630-b026118eef13 - person

	  //c6b59163-5a28-42ce-952c-f5b0b390865a - physical address
	  //e78f535c-d26c-4f18-bcaf-3b01d66942d8 - physical address

	  //59417cdd-0875-4385-bf11-c692583912f0 - registered training
	  //33372fd5-4c85-4b76-bbed-58f0365dbc74 - registered training

	  modelBuilder.Entity<Course>().HasData(
		  new Course() { CourseCode = new Guid("e288a507-bb38-477e-b985-c7afd1ee8057"), CourseName = "Computer science", CourseDescription = "Software & hardware" },
		  new Course() { CourseCode = new Guid("7aaa6300-d539-45de-b0a1-2f4d5750f75b"), CourseName = "Mathematics", CourseDescription = "Numbers & operators" }
	  );

	  modelBuilder.Entity<Training>().HasData(
		  new Training() { TrainingID = new Guid("7c45fd03-f621-418d-92b5-541364f13e97"), TrainingName = "CSC101", TrainingVenue = "Lab Center", TrainingCost = 299.33M, TrainingDate = new DateTime(), TrainingRegistrationClosingDate = new DateTime().AddDays(5), AvailableSeats = 10, CourseCode = new Guid("e288a507-bb38-477e-b985-c7afd1ee8057") },
		  new Training() { TrainingID = new Guid("eb0551e1-87ff-4e9e-8806-8be3b2413674"), TrainingName = "MTM101", TrainingVenue = "Accounting Center", TrainingCost = 599.33M, TrainingDate = new DateTime(), TrainingRegistrationClosingDate = new DateTime().AddDays(5), AvailableSeats = 20, CourseCode = new Guid("7aaa6300-d539-45de-b0a1-2f4d5750f75b") }
	  );

	  modelBuilder.Entity<Person>().HasData(
		  new Person() { PersonID = new Guid("8ce12c33-3a41-483c-b3ed-5c079c3762f7"), FirstName = "P1", CompanyName = "Epoch", PhoneNumber = 0625896325, Email = "P1@gmail.com", Dietary = Dietary.Halal },
		  new Person() { PersonID = new Guid("d72c6fef-e0b4-4e85-a630-b026118eef13"), FirstName = "P2", CompanyName = "Namtek", PhoneNumber = 0786525896, Email = "P2@gmail.com", Dietary = Dietary.Vegetarian }
	  );

	  modelBuilder.Entity<PhysicalAddress>().HasData(
		  new PhysicalAddress() { PhysicalAddressesID = new Guid("c6b59163-5a28-42ce-952c-f5b0b390865a"), StreetAddress = "P1Street", PostalCode = 1111, PersonID = new Guid("8ce12c33-3a41-483c-b3ed-5c079c3762f7") },
		  new PhysicalAddress() { PhysicalAddressesID = new Guid("e78f535c-d26c-4f18-bcaf-3b01d66942d8"), StreetAddress = "P2Street", PostalCode = 1100, PersonID = new Guid("d72c6fef-e0b4-4e85-a630-b026118eef13") }
	  );

	  modelBuilder.Entity<RegisterDelegateTrainings>().HasData(
		  new RegisterDelegateTrainings() { RegisteredTrainingsID = new Guid("59417cdd-0875-4385-bf11-c692583912f0"), PersonID = new Guid("8ce12c33-3a41-483c-b3ed-5c079c3762f7"), TrainingID = new Guid("7c45fd03-f621-418d-92b5-541364f13e97") },
		  new RegisterDelegateTrainings() { RegisteredTrainingsID = new Guid("33372fd5-4c85-4b76-bbed-58f0365dbc74"), PersonID = new Guid("d72c6fef-e0b4-4e85-a630-b026118eef13"), TrainingID = new Guid("eb0551e1-87ff-4e9e-8806-8be3b2413674") }
	  );
	}
  }
}
