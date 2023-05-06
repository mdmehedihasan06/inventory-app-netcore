using FluentAssertions;
using INVENTORY.Application.Service.Common;
using INVENTORY.Application.ServiceInterfaces.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.UnitTests.Service.Common
{
	[TestFixture]
	public class DateTimeProviderTest
	{
		private readonly IDateTimeProvider _dateTimeProvider;
		public DateTimeProviderTest(IDateTimeProvider dateTimeProvider) {
			_dateTimeProvider= dateTimeProvider;
		}
		// Public parameterless constructor
		public DateTimeProviderTest()
		{
			_dateTimeProvider = new DateTimeProvider();
		}
		[Test]
		public void GetCurrentDate_ReturnsCorrectDate()
		{
			// Arrange
			var expectedDate = DateTime.UtcNow;

			// Act
			var currentDate = _dateTimeProvider.UtcNow;

			// Assert
			currentDate.Should().BeCloseTo(expectedDate, TimeSpan.FromSeconds(1));
		}
	}
}
