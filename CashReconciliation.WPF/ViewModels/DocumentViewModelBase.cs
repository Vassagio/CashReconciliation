using System;
using System.Collections.Generic;
using Prism.Mvvm;

namespace CashReconciliation.WPF.ViewModels
{
	public abstract class DocumentViewModelBase : BindableBase, IEqualityComparer<DocumentViewModelBase>, IEquatable<DocumentViewModelBase>
	{
		public abstract string DisplayName { get; }

		public bool Equals(DocumentViewModelBase x, DocumentViewModelBase y) =>
			y != null &&
			x != null &&
			x.DisplayName.Equals(y.DisplayName);

		public int GetHashCode(DocumentViewModelBase obj) => obj.DisplayName.GetHashCode();

		public bool Equals(DocumentViewModelBase other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;

			return DisplayName == other.DisplayName;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;

			return obj is DocumentViewModelBase documentViewModel && Equals(documentViewModel);
		}

		public override int GetHashCode() => GetHashCode(this);
	}
}