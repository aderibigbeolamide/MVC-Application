using MVCVottingApp.Data.ViewModel.ResponseModel;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Interface.Services;
using MVCVottingApp.Model;
using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Implementation.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;

        public VoteService(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public async Task<BaseResponse> CastVoteAsync(int VoterId)
        {
            var vote = await _voteRepository.GetAsync(x => x.VoterId == VoterId);
            if (vote != null)
            {
                vote.Contestant.VoteCount++;
                await _voteRepository.UpdateAsync(vote);
            }
            else
            {
                await _voteRepository.AddAsync(new Vote
                {
                    VoterId = VoterId,
                    ContestantId = 1
                });
            }
            return new BaseResponse
            {
                Success = true,
                Message = "Vote casted successfully"
            };
        }

        public async Task<VotesResponseModel> GetAllVotesAsync()
        {
            var vote = await _voteRepository.GetAllAsync();
            if (vote == null)
            {
                return new VotesResponseModel
                {
                    Success = false,
                    Message = "No vote found"
                };
            }
            return new VotesResponseModel
            {
                Data = vote.Select(x => new VoteVM 
                {
                    ContestantId = x.ContestantId,
                    ElectionId = x.ElectionId,
                    VoterId = x.VoterId,
                    ContestantName = x.ContestantName,
                    ElectionName = x.ElectionName
                }).ToList(),
                Success = true,
                Message = "Votes retrieved successfully"
            };
        }

        public async Task<VoteResponseModel> GetHighestVoteByContestantIdAsync()
        {
            var vote = await _voteRepository.GetAllAsync();
            return new VoteResponseModel
            {
                Data = new VoteVM
                {
                    ContestantId = vote.OrderByDescending(x => x.Contestant.VoteCount).FirstOrDefault().ContestantId,
                    ContestantName = vote.OrderByDescending(x => x.Contestant.VoteCount).FirstOrDefault().ContestantName,
                    ElectionId = vote.OrderByDescending(x => x.Contestant.VoteCount).FirstOrDefault().ElectionId,
                    ElectionName = vote.OrderByDescending(x => x.Contestant.VoteCount).FirstOrDefault().ElectionName,
                    VoterId = vote.OrderByDescending(x => x.Contestant.VoteCount).FirstOrDefault().VoterId
                },
                Success = true,
                Message = "Highest vote retrieved successfully"
            };
        }
    }
}