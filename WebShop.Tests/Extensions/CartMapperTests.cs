
using DataAccess.Context.Entity;
using NUnit.Framework.Constraints;
using WebShop.Extensions;
using WebShop.Models;

namespace WebShop.Tests.Extensions
{
    internal class CartMapperTests
    {
        private CartMapper _cartMapper;

        [SetUp]
        public void Setup()
        {
            _cartMapper = new CartMapper();
        }

        [Test]
        public void ToModel_CartIsValid_ShouldSucceed()
        {
            // Arrange
            Cart cart = new Cart
            {
                Id = 1
            };

            // Act
            var result = _cartMapper.ToModel(cart);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(cart.Id, result.Id);
            CollectionAssert.AreEqual(result.CartItems, new List<CartItemModel>());
        }

        [Test]
        public void ToModel_CartIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange

            // Act
            ActualValueDelegate<object> testDelegate = () => _cartMapper.ToModel((Cart)null);

            // Assert
            Assert.That(testDelegate, Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void ToModel_CartIsWithoutId_ShouldSucceed()
        {
            // Arrange
            Cart cart = new Cart();

            // Act
            var result = _cartMapper.ToModel(cart);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(cart.Id, result.Id);
            CollectionAssert.AreEqual(result.CartItems, new List<CartItemModel>());
        }
    }
}
