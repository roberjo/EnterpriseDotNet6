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
using System.Net;

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

        [Fact]
        public void GivenAnIdOfAnExistingOwner_WhenGettingOwnerById_ThenOwnerReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = MockILogger.GetMock();
            var ownerController = new OwnerController(repositoryWrapperMock.Object, mapper, logger.Object);
            var id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
            var result = ownerController.GetOwnerById(id) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<OwnerDto>(result.Value);
            Assert.NotNull(result.Value as OwnerDto);
        }

        [Fact]
        public void GivenAnIdOfANonExistingOwner_WhenGettingOwnerById_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = MockILogger.GetMock();
            var ownerController = new OwnerController(repositoryWrapperMock.Object, mapper, logger.Object);

            var id = Guid.Parse("f4f4e3bf-afa6-4399-87b5-a3fe17572c4d");
            var result = ownerController.GetOwnerById(id) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public void GivenValidRequest_WhenCreatingOwner_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = MockILogger.GetMock();
            var ownerController = new OwnerController(repositoryWrapperMock.Object, mapper, logger.Object);

            var owner = new OwnerForCreationDto()
            {
                Address = "TestAddress",
                Name = "TestName",
                DateOfBirth = new DateTime(1994, 7, 25)
            };
            var result = ownerController.CreateOwner(owner) as ObjectResult;

            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result!.StatusCode);
            Assert.Equal("OwnerById", (result as CreatedAtRouteResult)!.RouteName);
        }
    }
}