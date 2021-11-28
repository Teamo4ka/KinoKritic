using System;
using System.Threading.Tasks;
using KinoKritic.BLL.Dtos;
using KinoKritic.BLL.Interfaces;
using KinoKritic.WEB.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace KinoKritic.WEB.Tests.Controllers
{
    [TestFixture]
    public class MediaControllerTests
    {
        private  MediaController _mediaController;
        private readonly Mock<IMediaService> _mediaService;

        public MediaControllerTests()
        {
            _mediaService = new Mock<IMediaService>();
            _mediaController = new MediaController(_mediaService.Object);
        }

        [Test]
        public async Task GetAllApi_WhenCalled_ReturnView()
        {
            _mediaService.Setup(media => media.GetAllAsync())
                .ReturnsAsync(new MediaDto[] {new MediaDto()});

            var result = await _mediaController.GetAllApi();

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
        [Test]
        public async Task DetailsApi_WhenCalled_ReturnView()
        {
            _mediaService.Setup(media => media.GetByIdAsync(Guid.Empty))
                .ReturnsAsync(new MediaDto()
                {
                    Annotation = "Annotation"
                });

            var result = await _mediaController.DetailsApi(Guid.Empty);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Create_WhenCalled_RedirectToGetAll()
        {
            var result = await _mediaController.Create(new MediaDto());
            
            Assert.That(result.ActionName, Is.EqualTo("GetAll"));
        }
    }
}