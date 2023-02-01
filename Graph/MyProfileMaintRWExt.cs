using PX.Data;
using PX.Objects.CS;
using PX.SM;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using PX.Objects.CR;

using PX.Objects.EP;
using System;
using PX.Data.BQL.Fluent;
//using Microsoft.Extensions.Options;
//using PX.Api.Web.Infotips.Services;


namespace AcumaticaRewards
{
    public class MyProfileMaintRWExt : PXGraphExtension<MyProfileMaint>
    {
        public static bool IsActive()
        {
            return true;
        }

        #region Selects
        

        public PXSelect<EPEmployee, Where<EPEmployee.userID, Equal<Current<AccessInfo.userID>>>> CurrentEmployee;

        public SelectFrom<BAccount>
                        .InnerJoin<Contact>.On<BAccount.defContactID.IsEqual<EPEmployee.defContactID.FromCurrent>>.View CurrentBAccount;

        public SelectFrom<RewardClaim>
                        .Where<RewardClaim.contactID.IsEqual<BAccount.defContactID.FromCurrent>>.View RewardClaims;
        
        //public SelectFrom<EmployeeRewardTransactions>
        //                .InnerJoin<BAccount>.On<BAccount.defContactID.IsEqual<EmployeeRewardTransactions.contactID>>
        //                .Where<EmployeeRewardTransactions.contactID.IsEqual<BAccount.defContactID.FromCurrent>
        //                    .And<Reward.requiredPoints.IsLessEqual<BAccountRWExt.usrTotalRewardPoints.FromCurrent>>>.View RewardTransactions;
        public SelectFrom<EmployeeRewardTransactions>
                        .Where<EmployeeRewardTransactions.contactID.IsEqual<BAccount.defContactID.FromCurrent>>.View RewardTransactions;

        public PXSelect<Reward> RewardsPanel;




        #endregion

        #region Actions
        public PXAction<Users> Redeem;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Redeem rewards")]
        public virtual IEnumerable redeem(PXAdapter adapter)
        {
            if (RewardsPanel.AskExt(true) == WebDialogResult.OK)
            {
                using (PXTransactionScope tranScope = new PXTransactionScope())
                {
                    try
                    {
                        Reward reward = RewardsPanel.Current;
                        EPEmployee emp = CurrentEmployee.Select();

                        var rewardTxnObj = new EmployeeRewardTransactions
                        {
                            ContactID = emp.DefContactID,
                            CreatedDateTime = Base.Accessinfo.BusinessDate,
                            RewardActivityID = 50000 + reward.RewardID,
                            Points = -reward.RequiredPoints,
                            CompletionDateTime = Base.Accessinfo.BusinessDate
                        };

                        RewardTransactions.Insert(rewardTxnObj);

                        var rewardClaim = new RewardClaim()
                        {
                            RewardID = reward.RewardID,
                            ContactID = emp.DefContactID,
                            PointValue = reward.RequiredPoints
                        };

                        RewardClaims.Insert(rewardClaim);

                        Base.Actions.PressSave();

                        tranScope.Complete();
                    }
                    catch
                    {
                        tranScope.Dispose();
                    }
                }
            }
            return adapter.Get();
        }



        protected virtual void _(Events.RowSelected<Reward> e)
        {
            if (!(e.Row is Reward row)) return;

            RewardsPanel.AllowUpdate = false;
            RewardsPanel.AllowInsert = false;
        }

        protected virtual void _(Events.RowSelected<EPEmployee> e)
        {
            if (!(e.Row is EPEmployee row)) return;

            var baccountExt = row.GetExtension<BAccountRWExt>();
            //Redeem.SetEnabled(baccountExt.UsrTotalRewardPoints > 0);
        }



        protected virtual void BAccount_UsrTotalRewardPoints_FieldSelecting(PXCache sender, PXFieldSelectingEventArgs e, PXFieldSelecting InvokeBaseHandler)
        {
            InvokeBaseHandler?.Invoke(sender, e);
            EPEmployee emp = CurrentEmployee.Select();
            if (emp != null)
            {
                decimal? RewardTotal = RewardTransactions.Select().FirstTableItems.ToList().Select(x => x.Points).Sum();
                e.ReturnValue = RewardTotal;
            }
        }




        #endregion


    }

}
