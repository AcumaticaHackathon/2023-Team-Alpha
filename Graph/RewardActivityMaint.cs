using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace AcumaticaRewards
{
    public class RewardActivityMaint : PXGraph<RewardActivityMaint>
    {
        public PXSave<RewardActivity> Save;
        public PXCancel<RewardActivity> Cancel;

        public SelectFrom<RewardActivity>.View RewardActivities;
    }
}