using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.EP;
using PX.Survey.Ext;
using System.Collections;

namespace AcumaticaRewards
{
    public class SurveyCollectorMaintExt : PXGraphExtension<SurveyCollectorMaint>
    {
        public static bool IsActive() => true;

        //public virtual IEnumerable submit(PXAdapter adapter)
        public delegate IEnumerable SubmitDelegate(PXAdapter adapter);
        [PXOverride]
        public virtual IEnumerable submit(PXAdapter adapter, SubmitDelegate baseMethod)
        {
            baseMethod(adapter);

            // Lookup if the survey is configured for points and award points

            SurveyCollector collector = Base.SurveyQuestions.Current;

            RewardActivity activity = SelectFrom<RewardActivity>
                .Where<RewardActivity.surveyID.IsEqual<SurveyCollector.surveyID.FromCurrent>>
                .View.Select(Base);

            if(activity != null)
            {
                
                //PXTrace.WriteInformation(string.Format("{0} Points to Award", activity.PointValue.ToString()));
                EmployeeRewardEntry graph = PXGraph.CreateInstance<EmployeeRewardEntry>();
                EPEmployee employee = graph.Employees.Search<EPEmployee.userID>(collector.UserID);
                if(employee?.BAccountID != null)
                {
                    graph.Employees.Current = employee;
                    graph.AddPoints((decimal) activity.PointValue, collector.CollectorID, SurveyID: collector.SurveyID);
                    graph.Actions.PressSave();                
                }
            }

            return adapter.Get();
        }
    }

}
