using System;
using Xunit;

namespace CashReconciliation.Core.Tests
{
    public class DenominationTest
    {
		[Fact]
	    public void Serialize()
		{
			var denominations = new Denominations
			{
				default(Denomination),
				new Denomination("Penny", .01m),
				new Denomination("Nickle", .05m),
				new Denomination("Dime", .01m),
				new Denomination("Quarter", .25m),
				new Denomination("One", 1m),
				new Denomination("Two", 2m),
				new Denomination("Five", 5m),
				new Denomination("Ten", 10m),
				new Denomination("Twenty", 20m),
				new Denomination("Fifty", 50m),
				new Denomination("Ten", 10m),
				new Denomination("Hundred", 100m)
			};
			var service = new SerializeService();
			service.Serialize(denominations, @"C:\temp\denomination.xml");
		}

	    [Fact]
	    public void Deserialize()
	    {		    
		    var service = new SerializeService();
		    var result = service.Deserialize<Denominations>(@"C:\temp\denomination.xml");
	    }

	    [Fact]
	    public void Serialize2()
	    {
		    var penny = new Denomination("Penny", .01m);
		    var nickle = new Denomination("Nickle", .05m);
		    var dime = new Denomination("Dime", .01m);
		    var quarter = new Denomination("Quarter", .25m);
		    var one = new Denomination("One", 1m);
		    var two = new Denomination("Two", 2m);
		    var five = new Denomination("Five", 5m);
		    var ten = new Denomination("Ten", 10m);
		    var twenty = new Denomination("Twenty", 20m);
		    var fifty = new Denomination("Fifty", 50m);		    
		    var hundred = new Denomination("Hundred", 100m);
		    var reconciliation = new Reconciliation
		    {
			    ReconciliationDate = DateTime.Now,
			    StartingCashEntries = new CashEntries
			    {
				    new CashEntry(hundred, 0),
				    new CashEntry(fifty, 0),
					new CashEntry(twenty, 5),
				    new CashEntry(ten, 10),
				    new CashEntry(five, 20),
				    new CashEntry(one, 50),
				    new CashEntry(quarter, 40),
				    new CashEntry(dime, 40),
				    new CashEntry(nickle, 60),
				    new CashEntry(penny, 100),
			    },
			    EndingCashEntries = new CashEntries
			    {
				    new CashEntry(hundred, 1),
				    new CashEntry(fifty, 1),
				    new CashEntry(twenty, 10),
				    new CashEntry(ten, 4),
				    new CashEntry(five, 25),
				    new CashEntry(two, 1),
				    new CashEntry(one, 25),
				    new CashEntry(quarter, 30),
				    new CashEntry(dime, 50),
				    new CashEntry(nickle, 50),
				    new CashEntry(penny, 88),
			    }
		    };
		    var service = new SerializeService();
		    service.Serialize(reconciliation, $@"C:\temp\Reconciliation-{DateTime.Now:yyyyMMdd}.xml");
	    }

	    [Fact]
	    public void Deserialize2()
	    {		    
		    var service = new SerializeService();
		    var result = service.Deserialize<Reconciliation>($@"C:\temp\Reconciliation-{DateTime.Now:yyyyMMdd}.xml");
	    }
    }
}
