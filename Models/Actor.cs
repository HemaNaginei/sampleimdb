using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sampleimdb.Models
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        //[Display(Name="Movies")]
        //public virtual int MovieId {get;set;}
        //[JsonIgnore]
        //public virtual Movies? Movies { get; set; }
        public int? CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public bool DeleteFlag { get; set; }
        public int Status { get; set; }
    }
    public class Actor_DD
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }

    }
}
