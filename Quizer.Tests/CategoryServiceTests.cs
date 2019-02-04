using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Quizer.DataAccessLayer.Entities;
using Quizer.Services.Abstract;
using Quizer.Services.Concrete;

namespace Quizer.Tests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private Mock<ICategoryService> mockCategoryService;
        private  ICategoryService _categoryService;
        private IList<Category> _categories;

        [OneTimeSetUp]
        public void SetUp()
        {
            mockCategoryService = new Mock<ICategoryService>();
            _categories = new List<Category>
                {
                    new Category {Id = 1, Name = "Mathematics"},
                    new Category {Id = 2, Name = "Sports"},
                    new Category {Id = 3, Name = "General knowledge"}
                };

            mockCategoryService.Setup(x => x.GetAll()).Returns(_categories);

            mockCategoryService.Setup(x => x.Get(1)).Returns(_categories.First(x => x.Id == 1));
            mockCategoryService.Setup(x => x.Get(2)).Returns(_categories.First(x => x.Id == 2));
            mockCategoryService.Setup(x => x.Get(It.Is<int>(i => i > 3 || i < 1))).Returns((Category)null);

            mockCategoryService.Setup(x => x.Create(It.IsAny<Category>())).Returns(true);
            mockCategoryService.Setup(x => x.Create(null)).Returns(false);

            mockCategoryService.Setup(x => x.Delete(It.IsAny<Category>())).Returns(true);
            mockCategoryService.Setup(x => x.Delete(null)).Returns(false);

            _categoryService = mockCategoryService.Object;
        }

        [Test]
        [TestCase(1, "Mathematics")]
        [TestCase(2, "Sports")]
        public void ShouldReturnCategoryWhenIdIsValid(int id, string categoryName)
        {
            Category expectedFirstCategory = new Category {Id = id, Name = categoryName};

            Category firstCategory = _categoryService.Get(id);

            Assert.AreEqual(expectedFirstCategory.Id, firstCategory.Id, "Actual and expected Id values are different.");
            Assert.AreEqual(expectedFirstCategory.Name, firstCategory.Name, "Actual and expected Name values are different.");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(4)]
        public void ShouldReturnNullWhenCategoryIdIsInvalid(int id)
        {
            Category category = _categoryService.Get(id);

            Assert.IsNull(category);
        }

        [Test]
        public void ShouldReturnAllCategoriesWhenRepositoryIsNotEmpty()
        {
            int expectedNumberOfCategories = 3;

            int numberOfCategories = _categoryService.GetAll().Count();

            Assert.AreEqual(expectedNumberOfCategories, numberOfCategories);
        }

        [Test]
        public void ShouldCreateCategoryIfIsValid()
        {
            Category category = new Category {Id = 4, Name = "New category"};

            bool result = _categoryService.Create(category);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldNotCreateCategoryIfItIsNull()
        {
            bool result = _categoryService.Create(null);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void ShouldDeleteCategoryIfItExists()
        {
            Category category = new Category {Id = 1, Name = "Mathematics"};

            bool result = _categoryService.Delete(category);
            
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldNotDeleteCategoryIfItIsNull()
        {
            Category category = null;

            bool result = _categoryService.Delete(category);

            Assert.IsNull(category);
            Assert.AreEqual(false, result);
        }
    }
}
