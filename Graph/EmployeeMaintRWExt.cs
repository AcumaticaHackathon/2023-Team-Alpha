using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Common;
using PX.Objects.AP;
using PX.SM;
using PX.TM;
using System;
using PX.Data;
using PX.EP;
using PX.Objects.CS;
using PX.Objects.CR;
using PX.Objects.CA;
using PX.Objects.PM;
using CRLocation = PX.Objects.CR.Standalone.Location;
using PX.Objects.Common;
using PX.Objects.EP.DAC;
using PX.Data.BQL.Fluent;
using PX.Objects;
using PX.Objects.EP;

namespace AcumaticaRewards
{
  public class EmployeeMaintRWExt : PXGraphExtension<PX.Objects.EP.EmployeeMaint>
  {
        public static bool IsActive() { return true; }

        public SelectFrom<EmployeeRewardTransactions>
                        .Where<EmployeeRewardTransactions.contactID.IsEqual<EPEmployee.defContactID.FromCurrent>>.View RewardTransactions;

        #region Event Handlers

        #endregion
    }
}