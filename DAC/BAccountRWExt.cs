using PX.Data.BQL.Fluent;
using PX.Data.BQL;
using PX.Data.EP;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data;
using PX.Objects.AP;
using PX.Objects.AR;
using PX.Objects.CM;
using PX.Objects.CR.MassProcess;
using PX.Objects.CR.Workflows;
using PX.Objects.CR;
using PX.Objects.CS.DAC;
using PX.Objects.CS;
using PX.Objects.EP;
using PX.Objects.GL.DAC;
using PX.Objects.GL;
using PX.Objects.PO;
using PX.Objects.TX;
using PX.Objects;
using PX.SM;
using PX.TM;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace AcumaticaRewards
{
    // Acuminator disable once PX1011 InheritanceFromPXCacheExtension [Justification]
    public class BAccountRWExt : PXCacheExtension<PX.Objects.CR.BAccount>
  {
        public static bool IsActive() { return true; }

        #region UsrTotalRewardPoints
        [PXDBDecimal]
        [PXUIField(DisplayName="Total Reward Points")]

        public virtual Decimal? UsrTotalRewardPoints { get; set; }
        public abstract class usrTotalRewardPoints : PX.Data.BQL.BqlDecimal.Field<usrTotalRewardPoints> { }
        #endregion
  }
}