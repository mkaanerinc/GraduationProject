using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    // InsuredPersonRelationship (sigortalının yakınlık derecesi) class'ı veritabanındaki InsuredPersonRelationships tablosunun referansıdır.
    public class InsuredPersonRelationship : IEntity
    {
        public int InsuredPersonRelationshipId { get; set; }
        public string InsuredPersonRelationshipName { get; set; }
    }
}
