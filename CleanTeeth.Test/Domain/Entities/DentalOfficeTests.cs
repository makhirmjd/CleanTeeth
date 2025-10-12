using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Test.Domain.Entities
{
    [TestClass]
    public class DentalOfficeTests
    {
        [TestMethod]
        public void Constructor_NullName_ThrowsBusinessRuleException()
        {
            Assert.Throws<BusinessRuleException>(() => new DentalOffice(name: default!));
        }

        [TestMethod]
        public void Constructor_ValidName_SetsPropertiesCorrectly()
        {
            // Arrange
            string name = "Happy Smiles Dental";
            // Act
            DentalOffice dentalOffice = new(name);
            // Assert
            Assert.AreNotEqual(Guid.Empty, dentalOffice.Id);
            Assert.AreEqual(name, dentalOffice.Name);
        }
    }
}
