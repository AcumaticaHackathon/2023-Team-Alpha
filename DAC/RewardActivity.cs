using System;
using PX.Data;
using PX.BusinessProcess.DAC;

namespace AcumaticaRewards
{
  [Serializable]
  [PXCacheName("RewardActivity")]
  public class RewardActivity : IBqlTable
  {
    #region RewardActivityID
    [PXDBIdentity(IsKey = true)]
    public virtual int? RewardActivityID { get; set; }
    public abstract class rewardActivityID : PX.Data.BQL.BqlInt.Field<rewardActivityID> { }
    #endregion

    #region RewardActivityCD
    [PXDBString(30, IsFixed = true, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Reward Activity ID")]
    public virtual string RewardActivityCD { get; set; }
    public abstract class rewardActivityCD : PX.Data.BQL.BqlString.Field<rewardActivityCD> { }
    #endregion    

    #region EventName
    [PXDBString(64, InputMask = "", IsUnicode = true)]
    [PXSelector(typeof(BPEvent.name), new System.Type[] { typeof(BPEvent.name), typeof(BPEvent.description), typeof(BPEvent.screenIdValue), typeof(BPEvent.active), typeof(BPEvent.type), typeof(BPEvent.eventID) })]
    [PXUIField(DisplayName = "Business Event Name", Visibility = PXUIVisibility.SelectorVisible)]
    public string EventName { get; set; }
    #endregion

    #region SurveyID
    [PXDBInt()]
    [PXUIField(DisplayName = "Survey ID")]
    [Survey]
    public virtual int? SurveyID { get; set; }
    public abstract class surveyID : PX.Data.BQL.BqlInt.Field<surveyID> { }
    #endregion

    #region GradeforID
    [PXDBInt()]
    [PXUIField(DisplayName = "Grade For:")]
    [PXDefault(0)]
    [GradeForList]
    public virtual int? GradeforID { get; set; }
    public abstract class gradeforID : PX.Data.BQL.BqlInt.Field<gradeforID> { }
    #endregion

    #region PointValue
    [PXDBDecimal()]
    [PXUIField(DisplayName = "Points Value")]
    public virtual Decimal? PointValue { get; set; }
    public abstract class pointValue : PX.Data.BQL.BqlDecimal.Field<pointValue> { }
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