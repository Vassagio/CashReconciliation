using System;
using Moq;

namespace CashReconciliation.Implementation.Mocks
{
	public class MockTimeProvider : ITimeProvider
	{
		private readonly Mock<ITimeProvider> _mock = new Mock<ITimeProvider>();

		public DateTime Now => _mock.Object.Now;

		public MockTimeProvider NowReturns(DateTime now)
		{
			_mock.Setup(m => m.Now).Returns(now);
			return this;
		}

		public void VerifyNowCalled(int times = 1) =>
			_mock.Verify(m => m.Now, Times.Exactly(times));

		public void VerifyNowNotCalled() =>
			_mock.Verify(m => m.Now, Times.Never);
	}
}