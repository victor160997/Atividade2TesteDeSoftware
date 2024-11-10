// using NUnit.Framework;
// using Moq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using MyProjectNamespace; // Substitua pelo namespace do seu projeto

// [TestFixture]
// public class RouteServiceTests
// {
//     private Mock<ISiteService> _mockSiteService;
//     private Mock<IAutorouteEntries> _mockAutorouteEntries;
//     private RouteService _routeService;

//     [SetUp]
//     public void Setup()
//     {
//         _mockSiteService = new Mock<ISiteService>();
//         _mockAutorouteEntries = new Mock<IAutorouteEntries>();
//         _routeService = new RouteService(_mockSiteService.Object, _mockAutorouteEntries.Object);
//     }

//     [Test]
//     public async Task GetContentItemIdFromRouteAsync_RootUrl_ReturnsHomeRouteContentItemId()
//     {
//         // Arrange
//         var siteSettings = new SiteSettings { HomeRoute = { ["contentItemId"] = "homeId" } };
//         _mockSiteService.Setup(s => s.GetSiteSettingsAsync()).ReturnsAsync(siteSettings);

//         var url = new PathString("/");

//         // Act
//         var result = await _routeService.GetContentItemIdFromRouteAsync(url);

//         // Assert
//         Assert.AreEqual("homeId", result);
//     }

//     [Test]
//     public async Task GetContentItemIdFromRouteAsync_ValidUrl_ReturnsContentItemId()
//     {
//         // Arrange
//         var entry = new AutorouteEntry { ContentItemId = "aboutUsId" };
//         _mockAutorouteEntries.Setup(a => a.TryGetEntryByPathAsync("/sobre-nos")).ReturnsAsync((true, entry));

//         var url = new PathString("/sobre-nos");

//         // Act
//         var result = await _routeService.GetContentItemIdFromRouteAsync(url);

//         // Assert
//         Assert.AreEqual("aboutUsId", result);
//     }

//     [Test]
//     public async Task GetContentItemIdFromRouteAsync_InvalidUrl_ReturnsNull()
//     {
//         // Arrange
//         _mockAutorouteEntries.Setup(a => a.TryGetEntryByPathAsync("/pagina-inexistente")).ReturnsAsync((false, null));

//         var url = new PathString("/pagina-inexistente");

//         // Act
//         var result = await _routeService.GetContentItemIdFromRouteAsync(url);

//         // Assert
//         Assert.IsNull(result);
//     }

//     [Test]
//     public async Task GetContentItemIdFromRouteAsync_EmptyUrl_ReturnsHomeRouteContentItemId()
//     {
//         // Arrange
//         var siteSettings = new SiteSettings { HomeRoute = { ["contentItemId"] = "homeId" } };
//         _mockSiteService.Setup(s => s.GetSiteSettingsAsync()).ReturnsAsync(siteSettings);

//         var url = new PathString("");

//         // Act
//         var result = await _routeService.GetContentItemIdFromRouteAsync(url);

//         // Assert
//         Assert.AreEqual("homeId", result);
//     }
// }
