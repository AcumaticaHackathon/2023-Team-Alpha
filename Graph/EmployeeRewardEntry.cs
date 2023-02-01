using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.EP;

namespace AcumaticaRewards
{
    public class EmployeeRewardEntry : PXGraph<EmployeeRewardEntry>
    {
        public SelectFrom<EPEmployee>.View Employees;

        public SelectFrom<EmployeeRewardTransactions>
            .Where<EmployeeRewardTransactions.contactID.IsEqual<EPEmployee.defContactID.FromCurrent>>
            .View Transactions;

        public virtual void AddPoints(decimal points, int? ActivityID, int? SurveyID = null)
        {
            EPEmployee employee = Employees.Current;
            if(employee?.BAccountID != null)
            {
                EmployeeRewardTransactions trx = new EmployeeRewardTransactions() {
                    ContactID = employee.DefContactID,
                    RewardActivityID = ActivityID,
                    CompletionDateTime = Accessinfo.BusinessDate
                };

                EmployeeRewardTransactions testTrx = Transactions.Search<EmployeeRewardTransactions.contactID, EmployeeRewardTransactions.rewardActivityID>(trx.ContactID, trx.RewardActivityID);

                if(testTrx == null)
                {
                    trx = Transactions.Insert(trx);
                    trx.Points = (int?)points;
                    Transactions.Update(trx);
                    Actions.PressSave();
                }

            }
        }
    }

}
