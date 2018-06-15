using Moq;

namespace CashReconciliation.Data.Implementation.Mocks
{
	public class MockSerializeService : ISerializeService
	{
		private readonly Mock<ISerializeService> _mock = new Mock<ISerializeService>();

		public T Deserialize<T>(string fileName) => _mock.Object.Deserialize<T>(fileName);

		public void Serialize<T>(T obj, string fileName) => _mock.Object.Serialize(obj, fileName);

		public MockSerializeService DeserializeReturns<T>(T returnValue)
		{
			_mock.Setup(m => m.Deserialize<T>(It.IsAny<string>())).Returns(returnValue);
			return this;
		}

		public void VerifyDeserializeCalled<T>(string fileName, int times = 1) =>
			_mock.Verify(m => m.Deserialize<T>(fileName), Times.Exactly(times));

		public void VerifyDeserializeNotCalled<T>() =>
			_mock.Verify(m => m.Deserialize<T>(It.IsAny<string>()), Times.Never);

		public void VerifySerializeCalled<T>(T obj, string fileName, int times = 1) =>
			_mock.Verify(m => m.Serialize(obj, fileName), Times.Exactly(times));

		public void VerifySerializeCalled<T>() =>
			_mock.Verify(m => m.Serialize(It.IsAny<T>(), It.IsAny<string>()), Times.Never);
	}
}