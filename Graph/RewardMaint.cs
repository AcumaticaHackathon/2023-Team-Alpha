using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace AcumaticaRewards
{
    public class RewardMaint : PXGraph<RewardMaint>
    {
        public PXSave<Reward> Save;
        public PXCancel<Reward> Cancel;

        public SelectFrom<Reward>.View Rewards;
    }
}