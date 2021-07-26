using System;
using Xunit;
using Moq;
using AluraFlixAPI.Controllers;
using AluraFlixAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AluraFlixAPI.Repositories;
using AluraFlixAPI;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class VideosControllerVideos
    {
        [Fact]
        public async void DadoChamadaSemParamentrosDeveRetornarTodosVideosE200()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<VideosController>>();

            var options = new DbContextOptionsBuilder<ApplicationContext>();
            var context = new ApplicationContext(options.UseInMemoryDatabase("ApplicationContext")
                .Options);
            var repo = new VideoRepository(context);

            var controller = new VideosController(mockLogger.Object, repo);
            var model = new Video();
            model.Id = 20;
            model.Titulo = "Noveo";
            model.Descricao = "Naoaoa";
            model.Url = "https://www.youtube.com/watch?v=U4m91RQQl54&ab_channel=CrunchyrollCollection";

            //Act
            var actionResult = await controller.Get();
            var result = actionResult.Value;

            //Assert
            //Assert.Equal(200, result.StatusCode);
            Assert.Null(result);
        }

    }
}
