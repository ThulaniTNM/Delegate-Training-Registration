namespace Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO
{
    public class TrainingWriteDTO
    {
        public string TrainingName { get; set; }
        public string TrainingVenue { get; set; }
        public decimal TrainingCost { get; set; }
        public DateTime TrainingDate { get; set; }
        public DateTime TrainingRegistrationClosingDate { get; set; }
        public int AvailableSeats { get; set; }
    }
}
