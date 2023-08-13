using AutoMapper;
using FluentAssertions;
using Moq;
using PersonStatisticsAPI.Business.Managers;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Tests
{
    public class PersonShoudTest
    {

        [Test]
        public static void UpdatePerson_ReturnTrue_WhenItemIsUpdated()
        {
            //Pack itemData = new Pack { Id = 2, Name = "Ivan", Mail = "ivan@gmail.com", Phone = "5263784", Sex = "male" };
            //PackDto itemDtoData = new PackDto { Id = 2, Name = "Ivan", Mail = "ivan@gmail.com", Phone = "5263784", Sex = "male" };

            //var mockRepository = new Mock<IPersonRepository>();
            //mockRepository.Setup(repo => repo.Get(itemData.Id)).Returns(new PackDto { Id = 2, Name = "Ivan", Mail = "ivan@gmail.com", Phone = "5263784", Sex = "male" });

            //var mockMapper = new Mock<IMapper>();
            //mockMapper.Setup(mapper => mapper.Map<PackDto, Pack>(itemDtoData)).Returns(new Pack { Id = itemDtoData.Id, Name = itemDtoData.Name, Mail = itemDtoData.Mail, Phone = itemDtoData.Phone, Sex = itemDtoData.Sex });
            //var itemManager = new PersonManager(mockRepository.Object, mockMapper.Object);

            //HttpModelResult response = itemManager.Update(itemData, 2);

            //response.Should().NotBeNull();
            //response.HttpStatus.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}