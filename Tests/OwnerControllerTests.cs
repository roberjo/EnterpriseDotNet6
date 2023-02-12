using Contracts;
using Tests.Mocks;
using AutoMapper;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnterpriseDotNet6.API;
using EnterpriseDotNet6.API.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.Json;

namespace Tests
{
    public class OwnerControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void WhenGettingAllOwners_ThenAllOwnersReturn()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = MockILogger.GetMock();
            var ownerController = new OwnerController(repositoryWrapperMock.Object, mapper, logger.Object);

            var result = ownerController.GetAllOwners() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<OwnerDto>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<OwnerDto>);
        }
    }
}