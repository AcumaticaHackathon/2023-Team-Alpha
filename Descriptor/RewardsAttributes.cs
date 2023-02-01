using PX.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using CR = PX.Objects.CR;
using PX.Survey.Ext;


namespace AcumaticaRewards
{

	#region Reward

	public class RewardAttribute : PXCustomSelectorAttribute
	{
		public RewardAttribute()
			: base(typeof(Reward.rewardID),

			fieldList: new[]
			{
				typeof(Reward.rewardCD),
				typeof(Reward.description),
				typeof(Reward.requiredPoints)
			})
		{
			this.DescriptionField = typeof(Reward.description);
			this.SubstituteKey = typeof(Reward.rewardCD);
			this.CacheGlobal = true;

		}
		protected virtual IEnumerable GetRecords()
		{
			foreach (Reward pc in PXSelect<Reward, Where<True, Equal<True>>, OrderBy<Asc<Reward.rewardCD>>>.Select(this._Graph))
			{
				yield return pc;
			}
		}
	}
	#endregion

	#region RewardActivity

	public class RewardActivityAttribute : PXCustomSelectorAttribute
	{
		public RewardActivityAttribute()
			: base(typeof(RewardActivity.rewardActivityID),

			fieldList: new[]
			{
				typeof(RewardActivity.rewardActivityCD),
				typeof(RewardActivity.pointValue),
				typeof(RewardActivity.gradeforID)
			})
		{
			//this.DescriptionField = typeof(RewardActivity.description);
			this.SubstituteKey = typeof(RewardActivity.rewardActivityCD);
			this.CacheGlobal = true;

		}
		protected virtual IEnumerable GetRecords()
		{
			foreach (RewardActivity pc in PXSelect<RewardActivity, Where<True, Equal<True>>, OrderBy<Asc<RewardActivity.rewardActivityCD>>>.Select(this._Graph))
			{
				yield return pc;
			}
		}
	}
#endregion

	#region Survey

	public class SurveyAttribute : PXCustomSelectorAttribute
	{
		public SurveyAttribute()
			: base(typeof(Survey.surveyID),

			fieldList: new[]
			{
				typeof(Survey.surveyCD),
				typeof(Survey.surveyName),
				typeof(Survey.active)
			})
		{
			this.DescriptionField = typeof(Survey.surveyName);
			this.SubstituteKey = typeof(Survey.surveyCD);
			this.CacheGlobal = true;

		}
		protected virtual IEnumerable GetRecords()
		{
			foreach (Survey pc in PXSelect<Survey, Where<True, Equal<True>>, OrderBy<Asc<Survey.surveyCD>>>.Select(this._Graph))
			{
				yield return pc;
			}
		}
	}
	#endregion

	#region GradeForListAttribute
	public class GradeForListAttribute : PXIntListAttribute
	{
		public GradeForListAttribute()
			: base(
			new int[] { Completion, Accuracy },
			new string[] { Messages.Completion, Messages.Accuracy })
		{; }

		public const int Completion = 0;
		public const int Accuracy = 1;

	}
	#endregion

}
