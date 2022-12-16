using System.ComponentModel.DataAnnotations;

namespace BenchAPI.Models
{
    public class BenchResource
    {
        [Key]
        public Guid BenchId { get; set; }
        public Guid PartnerId { get; set; }
        public int NoOfResource { get; set; }
        public string YearsOfExperince { get; set; }
        public string SkillSet { get; set; }
        public double RatePerHrUSD { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set;}
    }
    
}
