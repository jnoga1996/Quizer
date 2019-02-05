using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Quizer.DataAccessLayer.Entities;
using Quizer.DataAccessLayer.Repositories.Abstract;

namespace Quizer.Tests
{
    [TestFixture]
    public class CategoryRepositoryTests
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly Mock<IRepository<Category>> _mock;

        public CategoryRepositoryTests()
        {
            _mock = new Mock<IRepository<Category>>();

            List<Category> categories = new List<Category>
            {
                new Category {Id = 1, Name = "Mathematics"},
                new Category {Id = 2, Name = "Sports"}
            };

            _mock.Setup(x => x.GetAll()).Returns(categories);

            _mock.Setup(x => x.Get(1)).Returns(categories.First(x => x.Id == 1));
            _mock.Setup(x => x.Get(2)).Returns(categories.First(x => x.Id == 2));
            _mock.Setup(x => x.Get(It.Is<int>(i => i > 2 || i < 1))).Returns((Category)null);

            _mock.Setup(x => x.Create(It.IsAny<Category>()));
            _mock.Setup(x => x.Create(null)).Throws<ArgumentNullException>();

            _mock.Setup(x => x.Delete(It.IsAny<Category>()));
            _mock.Setup(x => x.Delete(null)).Throws<ArgumentNullException>();

            _mock.Setup(x => x.Update(It.IsAny<Category>()));
            _mock.Setup(x => x.Update(null)).Throws<ArgumentNullException>();

            _categoryRepository = _mock.Object;
        }

        [Test]
        public void ShouldReturnAllCategoriesWhenRepositoryIsNotEmpty()
        {
            const int expectedCount = 2;

            int count = _categoryRepository.GetAll().Count();

            Assert.IsNotEmpty(_categoryRepository.GetAll());
            Assert.AreEqual(expectedCount, count);
        }
        
        [Test]
        public void ShouldReturnZeroCategoriesWhenRepositoryIsEmpty()
        {
            var mock = new Mock<IRepository<Category>>();
            mock.Setup(x => x.GetAll()).Returns(new List<Category>());
            var emptyRepository = mock.Object;

            const int expectedCount = 0;

            int count = emptyRepository.GetAll().Count();

            Assert.IsEmpty(emptyRepository.GetAll());
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void ShouldCreateCategoryIfItIsValid()
        {
            Category category = new Category {Id = 3, Name = "New category"};

            _categoryRepository.Create(category);

            Assert.IsNotNull(category);
            _mock.Verify(x => x.Create(category), Times.Once);
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWhenTryingToCreateNullCategory()
        {
            Category category = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _categoryRepository.Create(category));

            Assert.IsInstanceOf<ArgumentNullException>(ex);
            _mock.Verify(x => x.Create(category), Times.Once);
        }

        [Test]
        public void ShouldDeleteCategoryIfItIsValid()
        {
            Category category = new Category { Id = 3, Name = "New category" };

            _categoryRepository.Delete(category);

            Assert.IsNotNull(category);
            _mock.Verify(x => x.Delete(category), Times.Once);
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWhenTryingToDeleteNullCategory()
        {
            Category category = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _categoryRepository.Delete(category));

            Assert.IsInstanceOf<ArgumentNullException>(ex);
            _mock.Verify(x => x.Delete(category), Times.Once);
        }

        [Test]
        public void ShouldUpdateCategoryIfItIsValid()
        {
            Category category = new Category { Id = 3, Name = "New category" };

            _categoryRepository.Update(category);

            Assert.IsNotNull(category);
            _mock.Verify(x => x.Update(category), Times.Once);
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWhenTryingToUpdateNullCategory()
        {
            Category category = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _categoryRepository.Update(category));

            Assert.IsInstanceOf<ArgumentNullException>(ex);
            _mock.Verify(x => x.Update(category), Times.Once);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void ShouldReturnCategoryWhenIdIsValid(int id)
        {
            Category category = _categoryRepository.Get(id);

            Assert.IsNotNull(category);

        }

        [Test]
        [TestCase(-2)]
        [TestCase(200)]
        public void ShouldReturnNullWhenCategoryIdIsNotValid(int id)
        {
            Category category = _categoryRepository.Get(id);

            Assert.IsNull(category);
        }
    }
}
