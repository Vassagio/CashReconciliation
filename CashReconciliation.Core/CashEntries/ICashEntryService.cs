﻿using System.Collections.Generic;

namespace CashReconciliation.Core.CashEntries
{
	public interface ICashEntryService
	{
		IEnumerable<CashEntry> Get();
		void Add(CashEntry cashEntry);
		void Remove(CashEntry cashEntry);
		CashEntry Update(CashEntry cashEntry);
	}
}