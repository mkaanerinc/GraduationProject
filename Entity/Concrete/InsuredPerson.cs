using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    // InsuredPerson (sigortalı) class'ı veritabanındaki InsuredPersons tablosunun referansıdır.
    // Burada InsuredPersons tablosu Customers ve InsuredPersonRelationships tabloları ile Many to One ilişkidedir.
    public class InsuredPerson : IEntity
    {
        public int InsuredPersonId { get; set; }
        public int CustomerId { get; set; }
        public int InsuredPersonRelationshipId { get; set; }
        public string InsuredPersonFirstName { get; set; }
        public string InsuredPersonLastName { get; set; }
        public string InsuredPersonIdentityNo { get; set; }
        public bool InsuredPersonGender { get; set; }
        public DateTime InsuredPersonBirthdate { get; set; }
        public short InsuredPersonHeight { get; set; }
        public short InsuredPersonWeight { get; set; }
        public string InsuredPersonJob { get; set; }
        public string InsuredPersonEmail { get; set; }
        public string InsuredPersonGSM { get; set; }
        public string InsuredPersonCity { get; set; }
        public string InsuredPersonAddress { get; set; }
    }
}
