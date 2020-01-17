using System;
using Shop.Lib.Entities;
using Shop.Lib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HowestShop.Tests
{
    [TestClass]
    public class ShopServiceTest
    {
        [TestMethod]
        public void AddNewProduct_ProductNameIsEmpty_ShouldThrowException()
        {
            // Arrange
            string name = "";
            Category category = new Category("TestCategory");
            string price = "1";
            ShopService shopService = new ShopService();

            try
            {
                // Act
                shopService.AddNewProduct(name, category, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, ShopService.AllFieldsAreRequiredMessage);
                return;
            }

            Assert.Fail("No exeption was thrown");
        }

        [TestMethod]
        public void AddNewProduct_CategoryIsEmpty_ShouldThrowException()
        {
            // Arrange
            string name = "NewProduct";
            Category category = null;
            string price = "1";
            ShopService shopService = new ShopService();

            try
            {
                // Act
                shopService.AddNewProduct(name, category, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, ShopService.AllFieldsAreRequiredMessage);
                return;
            }

            Assert.Fail("No exeption was thrown");
        }

        [TestMethod]
        public void AddNewProduct_PriceIsEmpty_ShouldThrowException()
        {
            // Arrange
            string name = "NewProduct";
            Category category = new Category("TestCategory");
            string price = "";
            ShopService shopService = new ShopService();

            try
            {
                // Act
                shopService.AddNewProduct(name, category, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, ShopService.AllFieldsAreRequiredMessage);
                return;
            }

            Assert.Fail("No exeption was thrown");
        }

        [TestMethod]
        public void AddNewProduct_PriceHasToBeANumber_ShouldThrowException()
        {
            // Arrange
            string name = "NewProduct";
            Category category = new Category("TestCategory");
            string price = "abc";
            ShopService shopService = new ShopService();

            try
            {
                // Act
                shopService.AddNewProduct(name, category, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, ShopService.NewProductPriceIsWrongMessage);
                return;
            }

            Assert.Fail("No exeption was thrown");
        }

        [TestMethod]
        public void AddNewProduct_PriceCannotBeZero_ShouldThrowException()
        {
            // Arrange
            string name = "NewProduct";
            Category category = new Category("TestCategory");
            string price = "0";
            ShopService shopService = new ShopService();

            try
            {
                // Act
                shopService.AddNewProduct(name, category, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, ShopService.NewProductPriceIsWrongMessage);
                return;
            }

            Assert.Fail("No exeption was thrown");
        }

        [TestMethod]
        public void AddNewProduct_PriceCannotBeLessThanZero_ShouldThrowException()
        {
            // Arrange
            string name = "NewProduct";
            Category category = new Category("TestCategory");
            string price = "-1";
            ShopService shopService = new ShopService();

            try
            {
                // Act
                shopService.AddNewProduct(name, category, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, ShopService.NewProductPriceIsWrongMessage);
                return;
            }

            Assert.Fail("No exeption was thrown");
        }

        [TestMethod]
        public void AddNewProduct_PriceCannotBeMoreThanMaximumPrice_ShouldThrowException()
        {
            // Arrange
            string name = "NewProduct";
            Category category = new Category("TestCategory");
            decimal maximumPrice = ShopService.MaximumPriceOfProduct;
            string price = (maximumPrice + 1).ToString();
            ShopService shopService = new ShopService();

            try
            {
                // Act
                shopService.AddNewProduct(name, category, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, ShopService.NewProductPriceIsWrongMessage);
                return;
            }

            Assert.Fail("No exeption was thrown");
        }

        [TestMethod]
        public void AddNewProduct_WithValidProduct_ShouldUpdateProductsList()
        {
            // Arrange
            string name = "NewProduct";
            Category category = new Category("TestCategory");
            string price = "1";
            ShopService shopService = new ShopService();
            int expected = shopService.ProductsInShop.Count + 1;

            // Act
            shopService.AddNewProduct(name, category, price);

            // Assert
            int actual = shopService.ProductsInShop.Count;
            Assert.AreEqual(expected, actual, "No product added");
        }

        [TestMethod]
        public void AddNewProduct_WithValidProduct_ShouldHaveSameNameAsInputName()
        {
            // Arrange
            string name = "NewProduct";
            Category category = new Category("TestCategory");
            string price = "1";
            ShopService shopService = new ShopService();
            string expected = name;

            // Act
            shopService.AddNewProduct(name, category, price);

            // Assert
            string actual = shopService.ProductsInShop[shopService.ProductsInShop.Count - 1].Name;
            Assert.AreEqual(expected, actual, "Productname is not the same as entered in the inputfield!");
        }

        [TestMethod]
        public void DeleteProduct_WithValidProduct_ShouldUpdateProductsList()
        {
            // Arrange
            ShopService shopService = new ShopService();

            for (int i = 0; i < 5; i++)
            {
                shopService.AddNewProduct($"test{i}", new Category("Test"), "100");
            }

            Product productToDelete = shopService.ProductsInShop[1];
            int expected = shopService.ProductsInShop.Count - 1;

            // Act
            shopService.DeleteProduct(productToDelete);

            // Assert
            int actual = shopService.ProductsInShop.Count;
            Assert.AreEqual(expected, actual, "Productlist has not been updated!");
        }

        [TestMethod]
        public void DeleteProduct_WhenNoProductIsSelected_ShouldThrowException()
        {
            // Arrange
            Product productToDelete = null;
            ShopService shopService = new ShopService();

            try
            {
                // Act
                shopService.DeleteProduct(productToDelete);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, ShopService.NoProductSelectedToDeleteMessage);
                return;
            }

            Assert.Fail("No exeption was thrown");
        }
    }
}
