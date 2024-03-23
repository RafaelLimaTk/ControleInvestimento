using ControleInvestimento.Business.Core.Notifications;
using ControleInvestimento.Business.Models.Asset.Services;
using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Business.Models.Transaction;
using Moq;

namespace ControleInvestimento.Tests.ServiceTests;

public class AssetServiceTests
{
    [Fact(DisplayName = "Atualizar ativo com sucesso")]
    [Trait("Categoria", "Asset Service")]
    public async Task UpdateAssetRepository_MustUpdateAssetInDatabase()
    {
        // Arrange
        var asset = CreateTestAssetWithTransactions();
        var assetRepository = SetupMockAssetRepository(asset);
        var assetService = new AssetService(assetRepository.Object, new Mock<INotifier>().Object);

        // Act and assert initial update
        await ActAndUpdateAssert(asset, assetService, assetRepository, 1);

        // Act by adding more transactions and update again
        AddTransactionsToAsset(asset, 100, 15, false, 3);
        await ActAndUpdateAssert(asset, assetService, assetRepository, 2);
    }

    [Fact(DisplayName = "Atualizar ativo com falha de validação")]
    [Trait("Categoria", "Asset Service")]
    public async Task UpdateAsset_ShouldNotUpdateWhenValidationFails()
    {
        // Arrange
        var asset = new Asset("", InvestmentCategory.Stocks, Guid.NewGuid()); 
        var assetRepository = new Mock<IAssetRepository>();
        var notifier = new Mock<INotifier>();
        var assetService = new AssetService(assetRepository.Object, notifier.Object);

        // Act
        await assetService.Update(asset);

        // Assert
        notifier.Verify(n => n.Handle(It.IsAny<Notification>()), Times.AtLeastOnce());
        assetRepository.Verify(a => a.Update(It.IsAny<Asset>()), Times.Never());
    }

    private Asset CreateTestAssetWithTransactions()
    {
        var asset = new Asset("Test Asset", InvestmentCategory.Stocks, Guid.NewGuid());
        AddTransactionsToAsset(asset, 80, 11, true, 3);
        return asset;
    }

    private void AddTransactionsToAsset(Asset asset, int value, decimal quantity, bool isBuy, int times)
    {
        var transaction = new Transaction(value, quantity, isBuy);
        for (int i = 0; i < times; i++)
        {
            asset.AddTransaction(transaction);
        }
    }

    private Mock<IAssetRepository> SetupMockAssetRepository(Asset asset)
    {
        var assetRepository = new Mock<IAssetRepository>();
        assetRepository.Setup(a => a.GetById(asset.Id)).ReturnsAsync(asset);
        assetRepository.Setup(a => a.Update(asset)).Returns(Task.CompletedTask);
        return assetRepository;
    }

    private async Task ActAndUpdateAssert(Asset asset, AssetService assetService, Mock<IAssetRepository> assetRepository, int updateTimes)
    {
        await assetService.Update(asset);
        assetRepository.Verify(a => a.Update(asset), Times.Exactly(updateTimes));
    }
}
