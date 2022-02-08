using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    // InsuredPersonRelationshipDto class'ı veritabanındaki InsuredPersonRelationships tablosunun Data Transfer Object'tidir.
    public class InsuredPersonRelationshipDto : IDto
    {
        public int InsuredPersonRelationshipId { get; set; }
        public string InsuredPersonRelationshipName { get; set; }
    }
}
