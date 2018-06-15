namespace CashReconciliation.Core
{
	public interface IDenominaionMapper
	{
		Models.Denomination Map(Data.Entities.Denomination denomination);
		Data.Entities.Denomination Map(Models.Denomination denomination);
	}
}