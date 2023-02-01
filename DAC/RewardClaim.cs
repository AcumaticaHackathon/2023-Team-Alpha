using System;
using PX.Data;

namespace AcumaticaRewards
{
    [Serializable]
    [PXCacheName("RewardClaim")]
    public class RewardClaim : IBqlTable
    {
        #region RewardClaimID
        [PXDBIdentity(IsKey = true)]
        public virtual int? RewardClaimID { get; set; }
        public abstract class rewardClaimID : PX.Data.BQL.BqlInt.Field<rewardClaimID> { }
        #endregion

        #region RewardID
        [PXDBInt]
        [Reward]
        [PXUIField(DisplayName = "Reward ID")]
        public virtual int? RewardID { get; set; }
        public abstract class rewardID : PX.Data.BQL.BqlInt.Field<rewardID> { }
        #endregion

        #region IsProcessed
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Processed")]
        public virtual bool? IsProcessed { get; set; }
        public abstract class isProcessed : PX.Data.BQL.BqlBool.Field<isProcessed> { }
        #endregion

        #region ContactID
        [PXDBInt()]
        [PXUIField(DisplayName = "Contact ID")]
        public virtual int? ContactID { get; set; }
        public abstract class contactID : PX.Data.BQL.BqlInt.Field<contactID> { }
        #endregion

        #region PointValue
        [PXDBDecimal()]
        [PXUIField(DisplayName = "Point Value")]
        public virtual Decimal? PointValue { get; set; }
        public abstract class pointValue : PX.Data.BQL.BqlDecimal.Field<pointValue> { }
        #endregion

        #region ProcessedDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Processed Date")]
        public virtual DateTime? ProcessedDate { get; set; }
        public abstract class processedDate : PX.Data.BQL.BqlDateTime.Field<processedDate> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion

    }
}