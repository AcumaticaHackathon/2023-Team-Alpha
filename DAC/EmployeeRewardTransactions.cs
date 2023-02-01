using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;


namespace AcumaticaRewards
{
    [Serializable]
    [PXCacheName("Employee Reward Transactions")]
    public class EmployeeRewardTransactions : IBqlTable
    {
        #region ContactID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Contact ID")]
        [PXSelector(typeof(Search<Contact.contactID>),
            DirtyRead = true)]
        public virtual int? ContactID { get; set; }
        public abstract class contactID : PX.Data.BQL.BqlInt.Field<contactID> { }
        #endregion

        #region RewardActivityID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Reward Activity ID")]
        [RewardActivity]

        public virtual int? RewardActivityID { get; set; }
        public abstract class rewardActivityID : PX.Data.BQL.BqlInt.Field<rewardActivityID> { }
        #endregion

        #region Points
        [PXDBInt()]
        [PXUIField(DisplayName = "Points")]
        public virtual int? Points { get; set; }
        public abstract class points : PX.Data.BQL.BqlInt.Field<points> { }
        #endregion

        #region CompletionDateTime
        [PXDBDate()]
        [PXUIField(DisplayName = "Completion Date Time")]
        public virtual DateTime? CompletionDateTime { get; set; }
        public abstract class completionDateTime : PX.Data.BQL.BqlDateTime.Field<completionDateTime> { }
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