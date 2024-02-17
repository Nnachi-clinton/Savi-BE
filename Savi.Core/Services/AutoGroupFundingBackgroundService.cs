using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using Savi.Model.Enums;

namespace Savi.Core.Services
{
    public class AutoGroupFundingBackgroundService : IAutoGroupFundingBackgroundService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupSavingsMembersRepository _groupSavingsMembersRepository;
        private readonly IWalletServices _walletServices;

        public AutoGroupFundingBackgroundService(IUnitOfWork unitOfWork, IGroupSavingsMembersRepository groupSavingsMembersRepository, IWalletServices walletServices)
        {
            _unitOfWork = unitOfWork;
            _groupSavingsMembersRepository = groupSavingsMembersRepository;
            _walletServices = walletServices;
        }

        public async Task<bool> AutoGroup()
        {
            var allGroups = _unitOfWork.GroupRepository.GetAll();
            ArgumentNullException.ThrowIfNull(allGroups, nameof(allGroups));
            var groups = new List<Group>();
            foreach (var group in allGroups)
            {
                if (group.GroupStatus == GroupStatus.OnGoing && group.NextRunTime.Date == DateTime.Today)
                {
                    groups.Add(group);
                }
            }
            ArgumentNullException.ThrowIfNull(groups, nameof(groups));
            foreach (var group in groups)
            {
                var postionToCredit = await _groupSavingsMembersRepository.GetNextPositionToPay(group.Id);
                var memberToCredit = await _groupSavingsMembersRepository.FindAsync2(x=>x.GroupSavingsId == group.Id && x.Positions == postionToCredit);
                var MembersToDebit = await _groupSavingsMembersRepository.FindAsync(x => x.GroupSavingsId == group.Id && x.Positions != postionToCredit);
                var walletToCredit =  _walletServices.GetUserWalletAsync(memberToCredit.UserId);
                var walletsToDebit = new List<WalletDto>();
                foreach (var wallet in MembersToDebit)
                {
                    var debit = _walletServices.GetUserWalletAsync(wallet.UserId).Result;
                    walletsToDebit.Add(debit);
                }
            }
        }
    }
}
