using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingAPI.Context;
using VotingAPI.Models;

namespace VotingAPI.Controllers
{
    public class VoteController : Controller
    {
        private readonly VoteDBContext _DBContext;
        public VoteController(VoteDBContext voteDBContext)
        {
            _DBContext = voteDBContext;
        }



        [HttpPost("RegisterCandidate")]
        public async Task<IActionResult> RegisterCandidate([FromBody] Candidates account)
        {

            if (account == null)
            {
                return BadRequest(new { Message = "Something went wrong" });
            }
            else
            {



                await _DBContext.Candidates.AddAsync(account);
                await _DBContext.SaveChangesAsync();
                return Ok(new
                {
                    Message = "Candidate Registered Successfully",
                    account
                });
            }
        }
        [HttpPost("CandidateCount")]
        public async Task<IActionResult> CandidateCount([FromBody] Candidates counter)
        {

            if (counter == null)
            {
                return BadRequest(new { Message = "Something went wrong" });
            }
            else
            {
                var vote = new Candidates()
                {
                    TotalVotes = counter.TotalVotes + 1
                };
                
                await _DBContext.Candidates.AddAsync(counter);
                await _DBContext.SaveChangesAsync();
                return Ok(new
                {
                    Message = "Voted Successfully",
                    counter
                });
            }
        }

        [HttpGet]
[Route("GetAllCandidates")]
public async Task<IActionResult> GetAllCandidates()
        {
            return Ok(await _DBContext.Candidates.ToListAsync());
        }

        [HttpGet]
        [Route("GetCandidateById")]
        public async Task<IActionResult> GetCandidateById(int Id)
        {
            var user = await _DBContext.Candidates.FirstOrDefaultAsync(x => x.Id == Id);
            if (user == null)
            {
                return NotFound(new { Message = "Candidate Not Found" });
            }
            else
            {
                return Ok(user);
            }
        }


        [HttpPut]
        [Route("UpdateCandidate")]
        public async Task<IActionResult> UpdateCandidate([FromBody]int Id, Candidates userObj)
        {
            var user = await _DBContext.Candidates.FindAsync(Id);
            if (user == null)
            {
                return NotFound(new { Message = "Candidate Not Found"});
            }
            else
            {
                user.CandidateName = userObj.CandidateName;
                user.Party = userObj.Party;

                await _DBContext.SaveChangesAsync();

                return Ok(new { Message = "Updated Successfully", user });
            }
        }

        [HttpDelete]
        [Route("DeleteCandidate")]

        public async Task<IActionResult> DeleteCandidate(int Id)
        {
            var user = await _DBContext.Candidates.FindAsync(Id);

            if (user == null)
            {
                return NotFound();
            }

            _DBContext.Candidates.Remove(user);
            await _DBContext.SaveChangesAsync();

            return Ok(new { Candidate = user.CandidateName, Message = "Candidate Deleted Successfully" });

        }

    }
}
