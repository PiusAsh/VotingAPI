using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingAPI.Models
{
    public class Candidates
    {
        [Key]
        public int Id { get; set; }
        public string CandidateName { get; set; }
        public string Party { get; set; }
        public int TotalVotes { get; set; }

    }
}
