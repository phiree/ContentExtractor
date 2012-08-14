// File: FilterRuleInfo.cs
// 2008-10-13: Bryant    Original Version
// 
// ===================================================================

using System;
//using System.Data;

namespace CE.Model
{
	/// <summary>
	/// <para>FilterRuleInfo Object</para>
	/// <para>Summary description for FilterRuleInfo.</para>
	/// <para><see cref="member"/></para>
	/// <remarks></remarks>
	/// </summary>
	[Serializable]
	public partial class FilterRuleInfo
	{
		#region Fields
		private int _id;
	//	private int _channelId;
		private int _orderId;
		private string _beginMark = String.Empty;
		private bool _includeBeginMark;
		private string _endMark = String.Empty;
		private bool _includeEndMark;
		private string _appendBefore = String.Empty;
		private string _appendAfter = String.Empty;
		private bool _enabled;
	//	private bool _isContent;
		private string _ruleName = String.Empty;
		#endregion
		
		#region Contructors
		public FilterRuleInfo()
		{
		}
		
		public FilterRuleInfo
		(
			int id,
			int channelId,
			int orderId,
			string beginMark,
			bool includeBeginMark,
			string endMark,
			bool includeEndMark,
			string appendBefore,
			string appendAfter,
			bool enabled,
			bool isContent,
			string ruleName
		)
		{
			_id               = id;
		//	_channelId        = channelId;
			_orderId          = orderId;
			_beginMark        = beginMark;
			_includeBeginMark = includeBeginMark;
			_endMark          = endMark;
			_includeEndMark   = includeEndMark;
			_appendBefore     = appendBefore;
			_appendAfter      = appendAfter;
			_enabled          = enabled;
			//_isContent        = isContent;
			_ruleName         = ruleName;
			
		}
		#endregion
		
		#region Public Properties
		
		public int id
		{
			get {return _id;}
			set {_id = value;}
		}

		

		public int OrderId
		{
			get {return _orderId;}
			set {_orderId = value;}
		}

		public string BeginMark
		{
			get {return _beginMark;}
			set {_beginMark = value;}
		}

		public bool IncludeBeginMark
		{
			get {return _includeBeginMark;}
			set {_includeBeginMark = value;}
		}

		public string EndMark
		{
			get {return _endMark;}
			set {_endMark = value;}
		}

		public bool IncludeEndMark
		{
			get {return _includeEndMark;}
			set {_includeEndMark = value;}
		}

		public string AppendBefore
		{
			get {return _appendBefore;}
			set {_appendBefore = value;}
		}

		public string AppendAfter
		{
			get {return _appendAfter;}
			set {_appendAfter = value;}
		}

		public bool Enabled
		{
			get {return _enabled;}
			set {_enabled = value;}
		}

	

		public string RuleName
		{
			get {return _ruleName;}
			set {_ruleName = value;}
		}
		#endregion
	}
}