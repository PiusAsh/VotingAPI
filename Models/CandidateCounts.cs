using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingAPI.Models
{
    public class CandidateCounts
    {
        [Key]
        public int Id { get; set; }
        public int Count  { get; set; }
    }
}
