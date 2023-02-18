using EnterpriseDotNet6.Contracts;
using EnterpriseDotNet6.API.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    internal class MockILogger
    {
        public static Mock<ILogger<OwnerController>> GetMock()
        {
            var mock = new Mock<ILogger<OwnerController>>();

            return mock;
        }
    }
}
